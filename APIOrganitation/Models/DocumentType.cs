using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIOrganitation.Models
{
    [Table("tb_m_document_type")]
    public class DocumentType
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("type"), MaxLength(255)]
        public string Type { get; set; }

        //cardinality
        [JsonIgnore]
        public ICollection<Document>? Documents { get; set; }
    }
}
