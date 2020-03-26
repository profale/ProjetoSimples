using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSimples.Presentation.API.Models.Request
{
    public class ContatoRequestModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cor { get; set; }
        public DateTime Data { get; set; }
        public string Serial { get; set; }
        public int IdOperadora { get; set; }
        //public OperadoraRequestModel Operadora { get; set; }
    }
}