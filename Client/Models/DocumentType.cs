using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
public class DocumentType
{
    public int Id { get; set; }
    public string Type { get; set; }
}
