using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models
{
    public class AccountRole
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int RoleId { get; set; }
    }
}
