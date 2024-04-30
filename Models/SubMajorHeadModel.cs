using System;
using System.Collections.Generic;

namespace IFMS_Master_Backend.DAL
{
    public partial class SubMajorHeadModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public short? MajorHeadId { get; set; }
        
    }
}
