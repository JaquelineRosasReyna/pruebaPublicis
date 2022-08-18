using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Copys
    {
        public int? Id { get; set; }
        public string Medio { get; set; }
        public string Fecha { get; set; }
        public string Marca { get; set; }
        public string Producto { get; set; }
        public string Version { get; set; }
        public string Programa { get; set; }
        public DateTime Hora { get; set; }
        public string Vehiculo { get; set; }
        public string Anunciante { get; set; }
        public string Tema { get; set; }
        public ML.Categories Categories { get; set; }
        public bool? Processing { get; set; }
        public string File { get; set; }
        public List<object> Copies { get; set; }
        public string Action { get; set; }  
     

    }
}
    