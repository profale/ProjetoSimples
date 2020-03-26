using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSimples.Presentation.API.Models.Request
{
    public class OperadoraRequestModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}