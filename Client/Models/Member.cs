using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
public class Member
{
    public string Nim { get; set; }
    public string Name { get; set; }
    public string Major { get; set; }
    public DateTime BirthDate { get; set; }
    public string TitleName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}
