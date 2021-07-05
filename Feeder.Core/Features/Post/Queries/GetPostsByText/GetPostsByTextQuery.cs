using MediatR;
using System;
using Feeder.Core.Dto;
using System.Collections.Generic;

namespace Feeder.Features.Post.Queries.GetPostsByText
{
    public record GetPostsByTextQuery(string Text) : IRequest<List<PostDto>>;
}