using Microsoft.VisualBasic;

namespace ConexaoCodeFirst.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal Income {  get; set; }
        public DateFormat BirthDate { get; set; }
        public string Cpf {  get; set; }
    }
}
