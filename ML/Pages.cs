using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class pages
    {
        public int Id { get; set; }
        public string Medio { get; set; }
        public DateTime Fecha { get; set; }
        public ML.Categories Categories { get; set; }
        public int Spots { get; set; }
        public string Src_link { get; set; }
        public bool Processing { get; set; }
        public List<object> Page { get; set; }
    }
}
