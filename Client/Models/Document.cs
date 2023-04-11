using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
public class Document
{
    public int Id { get; set; }
    public string MemberNim { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string? File { get; set; }
    public int DocumentTypeId { get; set; }
    public string Information { get; set; }
}
