using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Interfaces.Models;

public interface IIndexed
{
    // Table with an index.
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

}