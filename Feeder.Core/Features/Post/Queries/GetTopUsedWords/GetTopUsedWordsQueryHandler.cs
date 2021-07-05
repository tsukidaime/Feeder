using AutoMapper;
using MediatR;
using Feeder.Data;
using Feeder.Infrastructure.Exceptions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Feeder.Core.Dto;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Feeder.Features.Post.Queries.GetTopUsedWords
{
    public class GetTopUsedWordsQueryHandler : IRequestHandler<GetTopUsedWordsQuery, List<string>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTopUsedWordsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<string>> Handle(GetTopUsedWordsQuery request, CancellationToken cancellationToken)
        {
            var uniqueWords = new Dictionary<string, int>();
            foreach (var post in _context.Posts)
            {
                var words = post.Summary.Split(' ');
                foreach (var word in words)
                {
                    var wordLower = word.ToLower();
                    if (!uniqueWords.Keys.Contains(wordLower))
                        uniqueWords.Add(wordLower, 0);
                    uniqueWords[wordLower] += words.Where(x => x == wordLower).Count();
                }
            }
            return await Task.Run(() => {
                return uniqueWords.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key).ToList();
            });
        }
    }
}