using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using solid.Repositories.Entities;
using solid.Repositories.Interfaces;


namespace solid.Repositories.Implementations
{
    public class SentimentRepository : ISentimentRepository
    {
        private readonly AppDbContext _context;

        public SentimentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Sentiment>> GetAllSentiments()
        {
            return await _context.Sentiments.ToListAsync();
        }
        public async Task AddSentimentAsync(Sentiment sentiment)
        {

            await _context.Sentiments.AddAsync(sentiment);
            await _context.SaveChangesAsync();
        }
    }
}
