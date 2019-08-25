namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Duration")]
    public partial class Duration
    {
        public int Id { get; set; }

        public int Length { get; set; }

        public int? StatusId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? LastUpdateBy { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? DeleteBy { get; set; }
    }
}
