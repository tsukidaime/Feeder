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

namespace Feeder.Features.Post.Queries.GetPostsByText
{
    public class GetPostsByTextQueryHandler : IRequestHandler<GetPostsByTextQuery, List<PostDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPostsByTextQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PostDto>> Handle(GetPostsByTextQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Posts.Where(post => post.Summary.Contains(request.Text) || post.Title.Contains(request.Text)).Select(post=>_mapper.Map<PostDto>(post));
            return await result.ToListAsync();
        }
    }
}