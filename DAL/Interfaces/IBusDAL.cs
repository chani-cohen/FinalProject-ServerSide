﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Threading.Tasks;


namespace DAL.Interfaces
{
    public interface IBusDAL
    {
        Task<List<TblBusses>> GetAllBussesAsync();
        Task<TblBusses> GetBusByCmBusAsync(string cmBus);
        Task AddBusAsync(TblBusses b);
        Task UpdateBusAsync(TblBusses b);
        Task DeleteBusAsync(string cmBus);
    }
}
