using IFMS_Master_Backend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace IFMS_Master_Backend.DAL.Interfaces
{
    public interface ITreasuryRepo : IRepository<Treasury>

    {
        /*public  Task<ICollection<Treasury>> GetTreasuryDetail();*/
    }
    
    
}
