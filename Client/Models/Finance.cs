using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
public class Finance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MemberNim { get; set; }
    public DateTime Date { get; set; }
    public int IncomingFunds { get; set; }
    public int? OutcomingFunds { get; set; }
    public int TotalFunds { get; set; }
    public string Information { get; set; }
}
