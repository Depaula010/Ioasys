using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestWithASP_NET5.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        [JsonIgnore]
        public long Id { get; set; }
    }
}
