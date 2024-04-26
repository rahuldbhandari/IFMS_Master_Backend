using System;
using System.Collections.Generic;

namespace IFMS_Master_Backend.DAL.Entities
{
    public partial class Treasury
    {
        public int Id { get; set; }
        public string DistrictName { get; set; } = null!;
        public short? DistrictCode { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool? IsDeleted { get; set; }
    }
}
