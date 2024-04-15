using System.ComponentModel.DataAnnotations;

namespace CrudAluno.Models
{
    public class Aluno
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Curso { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
