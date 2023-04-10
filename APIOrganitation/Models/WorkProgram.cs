using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIOrganitation.Models;

[Table("tb_m_workprogram")]
public class WorkProgram
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name"), MaxLength(50)]
    public string Name { get; set; }
    [Required, Column("member_nim", TypeName = "nchar(5)")]
    public string MemberNim { get; set; }
    [Required, Column("department id")]
    public int DepartmentId { get; set; }
    [Required, Column("satrt date")]
    public DateTime Start_Date { get; set; }
    [Required, Column("end date")]
    public DateTime End_Date { get; set; }
    [Required, Column("budget")]
    public int Budget { get; set; }
    [Required, Column("Description"), MaxLength(255)]
    public string Description { get; set; }

    //cardinality
    [JsonIgnore]
    [ForeignKey(nameof(MemberNim))]
    public Account? Account { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(DepartmentId))]
    public Department? Department { get; set; }
}
