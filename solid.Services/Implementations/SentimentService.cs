using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using solid.Models.ViewModels;
using solid.Repositories.Entities;
using solid.Repositories.Interfaces;
using solid.Services.Interfaces;

namespace solid.Services
{
    public class SentimentService : ISentimentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _geminiApiKey;
        private readonly ISentimentRepository _sentimentRepo;
        private readonly IMapper _mapper;

        public SentimentService(ISentimentRepository sentimentRepo, IMapper mapper)
        {
            _httpClient = new HttpClient();
            _geminiApiKey = "YOUR_GEMINI_API_KEY"; // Replace with actual API Key
            _sentimentRepo = sentimentRepo;
            _mapper = mapper;
        }

        public async Task<List<SentimentModel>> GetAllSentiments()
        {
            List<Sentiment> sentiments = await _sentimentRepo.GetAllSentiments();
            List<SentimentModel> sentimentModels = _mapper.Map<List<SentimentModel>>(sentiments);

            return sentimentModels;
        }

        public async Task<SentimentModel> CreateSentiment(SentimentModel sentimentModel)
        {
            if (string.IsNullOrWhiteSpace(sentimentModel.Text))
                throw new ArgumentException("Input text cannot be empty.");

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = $"Analyze the sentiment of this text and return both a label ('Positive', 'Negative', or 'Neutral') and a sentiment score between -1.0 (very negative) and 1.0 (very positive): {sentimentModel.Text}"
                            }
                        }
                    }
                }
            };

            var requestUri = $"https://generativelanguage.googleapis.com/v1/models/gemini-pro:generateContent?key={_geminiApiKey}";
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(requestUri, content);

            if (!response.IsSuccessStatusCode)
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Gemini API Error: {response.StatusCode} - {errorResponse}");
            }

            string responseString = await response.Content.ReadAsStringAsync();
            using JsonDocument jsonDoc = JsonDocument.Parse(responseString);

            if (!jsonDoc.RootElement.TryGetProperty("candidates", out JsonElement candidates) || candidates.GetArrayLength() == 0)
            {
                throw new Exception("Unexpected Gemini API response format: Missing 'candidates'");
            }

            // ✅ Extract the API response text
            string result = candidates[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString()
                ?.Trim()
                .ToLower();

            // ✅ Extract label and score using pattern matching
            string sentimentLabel = "Neutral"; // Default
            float sentimentScore = 0; // Default score

            if (result.Contains("positive"))
                sentimentLabel = "Positive";
            else if (result.Contains("negative"))
                sentimentLabel = "Negative";

            // ✅ Extract numerical score from the response using regex
            var scoreMatch = System.Text.RegularExpressions.Regex.Match(result, @"-?\d+(\.\d+)?");
            if (scoreMatch.Success)
            {
                sentimentScore = float.Parse(scoreMatch.Value);
            }

            var resultSentiment = new SentimentModel
            {
                TextId = Guid.NewGuid(),
                Text = sentimentModel.Text,
                Prediction = sentimentLabel == "Positive",
                SentimentScore = sentimentScore,
                SentimentLabel = sentimentLabel
            };

            var sentimentEntity = _mapper.Map<Sentiment>(resultSentiment);
            await _sentimentRepo.AddSentimentAsync(sentimentEntity);

            return resultSentiment;
        }
    }
}
