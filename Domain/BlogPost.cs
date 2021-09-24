using System;

namespace Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public DateTime Date { get; set; }
    }
}
