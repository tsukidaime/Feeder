﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feeder.Parser
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Url { get; set; }
    }
}
