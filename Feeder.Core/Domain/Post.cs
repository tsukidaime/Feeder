using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feeder.Core.Domain
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = default!;

        public string Summary { get; set; } = default!;

        public DateTime PublicationDate { get; set; }

        public string Url { get; set; } = default!;

    }
}
