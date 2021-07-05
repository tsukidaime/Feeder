using MediatR;
using System;
using Feeder.Core.Dto;
using System.Collections.Generic;

namespace Feeder.Features.Post.Queries.GetTopUsedWords
{
    public record GetTopUsedWordsQuery() : IRequest<List<string>>;
}