using RestWithASP_NET5.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET5.Model
{
    [Table("Filme")]
	public class Filme : BaseEntity
	{
		[Column("name")]
        public string Name { get; set; }
		[Column("gender")]
        public string Gender { get; set; }
		[Column("director")]
		public string Director { get; set; }
    }
}
