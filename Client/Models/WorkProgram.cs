using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
public class WorkProgram
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MemberNim { get; set; }
    public int DepartmentId { get; set; }
    public DateTime Start_Date { get; set; }
    public DateTime End_Date { get; set; }
    public int Budget { get; set; }
    public string Description { get; set; }
}
