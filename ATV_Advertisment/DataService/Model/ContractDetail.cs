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

        public int ContractId { get; set; }

        [Required]
        [StringLength(80)]
        public string ProductName { get; set; }

        public int DurationSecond { get; set; }

        public double Discount { get; set; }

        public bool IsApplyDiscount { get; set; }

        [StringLength(10)]
        public string Cost { get; set; }

        public double TotalCost { get; set; }

        public string JSONSchedule { get; set; }

        public int StatusId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int? LastUpdateBy { get; set; }
    }
}
