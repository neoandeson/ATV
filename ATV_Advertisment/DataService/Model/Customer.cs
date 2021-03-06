namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone1 { get; set; }

        [StringLength(14)]
        public string Phone2 { get; set; }

        [StringLength(14)]
        public string Fax { get; set; }

        [StringLength(11)]
        public string TaxCode { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerTypeId { get; set; }

        public int StatusId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? LastUpdateBy { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? DeleteBy { get; set; }
    }
}
