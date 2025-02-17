using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using solid.Models.ViewModels;
using solid.Repositories.Entities;

namespace solid.Repositories.Interfaces
{
    public interface ISentimentRepository
    {
        Task<List<Sentiment>> GetAllSentiments();
        Task AddSentimentAsync(Sentiment sentiment);
    }
}
