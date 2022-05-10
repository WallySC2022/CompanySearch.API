using System.ComponentModel.DataAnnotations.Schema;

namespace CompanySearch.Models
{
    public class Company
    {
        public string? Nome { get; set; }

        public string? Uf { get; set; }

        public string? Telefone { get; set; }

        public string? Email { get; set; }

        public string? Situacao { get; set; }
    }
}
