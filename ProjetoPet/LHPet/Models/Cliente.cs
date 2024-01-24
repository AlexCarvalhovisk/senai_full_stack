using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LHPet.Models
{
    [Table ("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public int Nome { get; set; }

        [Column("CPF")]
        [Display(Name = "CPF")]
        public int CPF { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public int Email { get; set; }

        [Column("Paciente")]
        [Display(Name = "Paciente")]
        public int Paciente { get; set; }
    }
}
