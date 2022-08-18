using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Category
    {
        public Category()
        {
            Copies = new HashSet<Copy>();
            Pages = new HashSet<Page>();
        }

        public int Id{ get; set; }
        public int? RefId { get; set; }
        public string? Name { get; set; }
        public string? Alias { get; set; }

        public virtual ICollection<Copy> Copies { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
