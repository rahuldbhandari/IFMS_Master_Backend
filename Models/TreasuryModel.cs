namespace IFMS_Master_Backend.Models
{
    public class TreasuryModel
    {
        public int Id { get; set; }
        public string DistrictName { get; set; } = null!;
        public short? DistrictCode { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
