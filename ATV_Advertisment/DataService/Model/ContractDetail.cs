namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractDetail")]
    public partial class ContractDetail
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductName { get; set; }

        public int DurationSecond { get; set; }

        public string JSONSchedule { get; set; }

        public int StatusId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? LastUpdateBy { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? DeleteBy { get; set; }
    }
}
