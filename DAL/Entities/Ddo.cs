using System;
using System.Collections.Generic;

namespace IFMS_Master_Backend.DAL.Entities
{
    public partial class Ddo
    {
        public int Id { get; set; }
        public string TreasuryCode { get; set; } = null!;
        public short? TreasuryMstId { get; set; }
        public string Code { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public int? DesignationMstId { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public bool? IsDelete { get; set; }
    }
}
