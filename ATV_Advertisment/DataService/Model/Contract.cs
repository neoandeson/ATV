namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contract")]
    public partial class Contract
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ContractTypeId { get; set; }

        public double Discount { get; set; }

        public double TotalCost { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndaDate { get; set; }

        public int StatusId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int? LastUpdateBy { get; set; }
    }
}
