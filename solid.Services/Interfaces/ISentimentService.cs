using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using solid.Models.ViewModels;

namespace solid.Services.Interfaces
{
    public interface ISentimentService
    {
        Task<List<SentimentModel>> GetAllSentiments();
        Task<SentimentModel> CreateSentiment(SentimentModel sentimentModel);
    }
}
