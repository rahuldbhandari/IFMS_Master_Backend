namespace IFMS_Master_Backend.Models
{
    public class SubDetailHeadModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public int? DetailHeadId { get; set; }
    }
}
