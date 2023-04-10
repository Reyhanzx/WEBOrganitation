using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIOrganitation.Models;

[Table("tb_m_Departement")]
public class Department
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name"), MaxLength(255)]
    public string Name { get; set; }

    //cardinality
    [JsonIgnore]
    public ICollection<WorkProgram>? WorkPrograms { get; set; }
}
