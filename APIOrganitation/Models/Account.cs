using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIOrganitation.Models
{
    [Table("tb_m_accounts")]
    public class Account
    {
        [Key, Column("member_nim", TypeName = "nchar(5)")]
        public string MemberNim { get; set; }
        [Required, Column("password"), MaxLength(255)]
        public string Password { get; set; }

        //cardinalitty
        [JsonIgnore]
        public ICollection<AccountRole>? AccountRoles { get; set; }
        [JsonIgnore]
        public Member? Member { get; set; }
    }
}
