using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infra.Mvc.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
    }
}