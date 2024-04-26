using System;
using System.Collections.Generic;

namespace IFMS_Master_Backend.DAL.Entities
{
    public partial class SubMajorHead
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public short? MajorHeadId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
