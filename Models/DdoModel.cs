namespace IFMS_Master_Backend.Models
{
    public class DdoModel
    {
        public string TreasuryCode { get; set; } = null!;
        public short? TreasuryMstId { get; set; }
        public string Code { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public int? DesignationMstId { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
