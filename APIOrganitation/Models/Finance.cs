using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIOrganitation.Models
{
    [Table("tb_m_Finance")]
    public class Finance
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("name"), MaxLength(255)]
        public string Name { get; set; }
        [Required, Column("member_nim", TypeName = "nchar(5)")]
        public string MemberNim { get; set; }
        [Required, Column("date")]
        public DateTime Date { get; set; }
        [Required, Column("Incoming Funds")]
        public int IncomingFunds { get; set; }
        [Column("Outcoming Funds")]
        public int? OutcomingFunds { get; set; }
        [Required, Column("total Funds")]
        public int TotalFunds { get; set; }
        [Required, Column("informattion"), MaxLength(255)]
        public string Information { get; set; }

        //cardinality
        [JsonIgnore]
        [ForeignKey(nameof(MemberNim))]
        public Account? Account { get; set; }
    }
}
