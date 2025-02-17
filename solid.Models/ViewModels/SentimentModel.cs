using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid.Models.ViewModels
{
    public class SentimentModel
    {
        public Guid TextId { get; set; }
        public string Text { get; set; }

        public bool Prediction { get; set; }
        public float SentimentScore { get; set; }

        public string SentimentLabel { get; set; }

    }
}
