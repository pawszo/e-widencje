using System;
using System.ComponentModel.DataAnnotations;

namespace e_widencje.Models
{
    public class ExciseEvidence : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [RegularExpression(@"[\d\.\-\s]{4,}")]
        public string CommodityCode { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public DateTime DateOfShipment { get; set; }

        public string HandOverAddress { get; set; }

        public string ReferenceNumber { get; set; }

        public string InternalShipmentDocumentId { get; set; }

        [Required]
        public DateTime DocumentDate { get; set; }

        public string MonthlySummaryPropan { get; set; }

        public string MonthlySummaryButan { get; set; }

        public string ExtraDetails { get; set; }
    }
}
