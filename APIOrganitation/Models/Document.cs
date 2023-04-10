using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIOrganitation.Models
{
    [Table("tb_m_document")]
    public class Document
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("member_nim", TypeName = "nchar(5)")]
        public string MemberNim { get; set; }
        [Required, Column("name"), MaxLength(255)]
        public string Name { get; set; }
        [Required, Column("date")]
        public DateTime Date { get; set; }
        [Column("file"), MaxLength(255)]
        public string? File { get; set; }
        [Required, Column("document type")]
        public int DocumentTypeId { get; set; }
        [Required, Column("description"), MaxLength(255)]
        public string Information { get; set; }

        //cardinality
        [JsonIgnore]
        [ForeignKey(nameof(MemberNim))]
        public Account? Account { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(DocumentTypeId))]
        public DocumentType? DocumentType { get; set; }
    }
}
