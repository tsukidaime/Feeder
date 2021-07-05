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

namespace Feeder.Features.Post.Queries.GetPostsByDateRange
{
    public class GetPostsByTextQueryHandler : IRequestHandler<GetPostsByDateRangeQuery, List<PostDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPostsByTextQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PostDto>> Handle(GetPostsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Posts.Where(post => post.PublicationDate >= request.From 
                && post.PublicationDate <= request.To).Select(post=>_mapper.Map<PostDto>(post));
            return await result.ToListAsync();
        }
    }
}