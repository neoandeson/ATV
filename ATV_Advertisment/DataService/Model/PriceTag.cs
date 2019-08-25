namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PriceTag")]
    public partial class PriceTag
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int StatusId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? LastUpdateBy { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? DeleteBy { get; set; }
    }
}
