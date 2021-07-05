using MediatR;
using System;
using Feeder.Core.Dto;
using System.Collections.Generic;

namespace Feeder.Features.Post.Queries.GetPostsByDateRange
{
    public record GetPostsByDateRangeQuery(DateTime From, DateTime To) : IRequest<List<PostDto>>;
}