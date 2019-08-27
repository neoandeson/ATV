namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        public int Id { get; set; }

        public double? PriceRate { get; set; }

        public double? Dicount { get; set; }

        public int StatusId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int? LastUpdateBy { get; set; }
    }
}
