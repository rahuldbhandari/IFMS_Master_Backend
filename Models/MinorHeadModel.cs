namespace IFMS_Master_Backend.Models
{
    public class MinorHeadModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public int? SubMajorId { get; set; }
    }
}
