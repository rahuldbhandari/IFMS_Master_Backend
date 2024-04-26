using System;
using System.Collections.Generic;

namespace IFMS_Master_Backend.DAL
{
    public partial class MinorHeadModel
    {
        
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public int? SubMajorId { get; set; }
        
    }
}
