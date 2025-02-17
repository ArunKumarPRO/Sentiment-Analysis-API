using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using solid.Models.ViewModels;
using solid.Repositories.Entities;

namespace solid.Services
{
    public class AutoMapping:Profile
    {
        public AutoMapping() {
            CreateMap<SentimentModel, Sentiment>().ReverseMap();
        }

    }
}
