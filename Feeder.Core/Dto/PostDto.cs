using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feeder.Core.Dto
{
    public record PostDto(Guid Id, string Title, string Summary, DateTime PublicationDate, string Url);
}
