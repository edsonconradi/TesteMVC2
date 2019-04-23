using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Models
{
    public class Cliente
    {
        public Cliente(int id, string nome, string cNPJ, string telefone)
        {
            Id = id;
            Nome = nome;
            CNPJ = cNPJ;
            Telefone = telefone;             
        }

        public Cliente()
        {           
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get;  set; }
        public string Telefone { get; set; }      
      
    }

}
