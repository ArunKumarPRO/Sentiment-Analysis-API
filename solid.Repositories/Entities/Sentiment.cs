using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid.Repositories.Entities
{
    public class Sentiment
    {
        [Key] 
        public Guid TextId { get; set; }
        public string Text { get; set; }

        public bool Prediction {  get; set; }
        public float SentimentScore { get; set; }

        public string SentimentLabel { get; set; }
    }
}
