namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductScheduleShow")]
    public partial class ProductScheduleShow
    {
        public int Id { get; set; }

        public int ContractDetailId { get; set; }

        [Required]
        [StringLength(1)]
        public string SessionCode { get; set; }

        [Required]
        [StringLength(50)]
        public string SessionName { get; set; }

        [Required]
        [StringLength(10)]
        public string ShowDate { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string TimeSlot { get; set; }

        public int TimeSlotLength { get; set; }

        public double Cost { get; set; }

        public double Discount { get; set; }

        public double TotalCost { get; set; }
    }
}
