using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Page
    {
        public int Id { get; set; }
        public string? Medio { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCategory { get; set; }
        public int? Spots { get; set; }
        public string? SrcLink { get; set; }
        public bool? Processing { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }
    }
}
