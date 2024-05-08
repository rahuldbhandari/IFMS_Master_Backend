namespace IFMS_Master_Backend.Models
{
    public class SubMajorHeadModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public short? MajorHeadId { get; set; }
    }
}
