using System.ComponentModel.DataAnnotations;

namespace SpongeBob.Models
{
    public class Home
    {
        public Guid Id { get; set; } //Id первый первичный ключ 
        public string HomeType { get; set; }
    }
}
