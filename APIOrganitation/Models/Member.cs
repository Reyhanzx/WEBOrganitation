using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIOrganitation.Models
{
    [Table("tb_m_member")]
    public class Member
    {
        [Key, Column("member nim", TypeName = "nchar(5)")]
        public string Nim { get; set; }
        [Required, Column("name"), MaxLength(255)]
        public string Name { get; set; }
        [Required, Column("major"), MaxLength(255)]
        public string Major { get; set; }
        [Required, Column("birth date")]
        public DateTime BirthDate { get; set; }
        [Required, Column("title name"), MaxLength(255)]
        public string TitleName { get; set; }
        [Required, Column("phone number"), MaxLength(255)]
        public string PhoneNumber { get; set; }
        [Required, Column("address"), MaxLength(255)]
        public string Address { get; set; }
        [Required, Column("email"), MaxLength(255)]
        public string Email { get; set; }

        //cardinality
        [JsonIgnore]
        public Account? Account { get; set; }
    }
}
