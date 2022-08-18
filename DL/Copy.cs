using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Copy
    {
        public int Id { get; set; }
        public string? Medio { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Marca { get; set; }
        public string? Producto { get; set; }
        public string? Version { get; set; }
        public string? Programa { get; set; }
        public DateTime? Hora { get; set; }
        public string? Vehiculo { get; set; }
        public string? Anunciante { get; set; }
        public string? Tema { get; set; }
        public int? IdCategory { get; set; }
        public bool? Processing { get; set; }
        public string? File { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }
        public string CategoryName { get; set; }
    }
}
