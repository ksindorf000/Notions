using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Notions.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string TeaserText { get; set; }
        public string ImgUrl { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }

    //db Context
    public class BlogPostContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}