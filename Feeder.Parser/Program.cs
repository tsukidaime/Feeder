using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Feeder.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseRSS("https://st.zakon.kz/rss/rss_all.xml");
        }

        public static void ParseRSS(string url)
        {
            SyndicationFeed feed = null;

            try
            {
                using (var reader = XmlReader.Create(url))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            catch { } // TODO: Deal with unavailable resource.

            if (feed != null)
            {
                foreach (var element in feed.Items)
                {
                    using (var context = new AppDbContext())
                    {
                        context.Posts.Add(new Post
                        {
                            Title = element.Title.Text,
                            Summary = element.Summary.Text,
                            PublicationDate = element.PublishDate.LocalDateTime,
                            Url = element.Id
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
