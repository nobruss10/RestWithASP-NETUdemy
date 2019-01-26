using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Model
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public long? Id { get; set; }
    }
}
