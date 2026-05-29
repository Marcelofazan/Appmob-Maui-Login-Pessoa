using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobile.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; } = string.Empty; 
        public string CnpjCpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class PessoaResponse
    {
        //public List<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
    }
}
