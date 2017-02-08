using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notions.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}