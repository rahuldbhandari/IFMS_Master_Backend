﻿using IFMS_Master_Backend.DAL;

namespace IFMS_Master_Backend.BAL.Interfaces
{
    public interface IMinorHeadService
    {
        Task<ICollection<MinorHeadModel>> getAllMinorHead();
        Task<MinorHeadModel> GetMinorHeadById(int Id);
        Task<MinorHeadModel> CreateMinorHead(MinorHeadModel hed);
        //Task<MinorHeadModel> CreateMinorHead(MinorHeadModel hed);
        Task<bool> DeleteMinorHead(int Id);
        Task<bool> UpdateMinorHead(int Id, MinorHeadModel headData);

    }
}
