using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;


namespace BL.Interfaces
{
    public interface ISiteBL
    {
        Task<List<TblSites>> GetAllSitesAsync();
        Task<TblSites> GetSiteByIdAsync(int id);
        Task AddSiteAsync(TblSites s);
        Task UpdateSiteAsync(TblSites s);
        Task DeleteSiteAsync(int id);
    }
}
