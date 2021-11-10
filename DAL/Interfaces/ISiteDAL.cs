using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISiteDAL
    {
        Task<List<TblSites>> GetAllSitesAsync();
        Task<TblSites> GetSiteByIdAsync(int id);
        Task AddSiteAsync(TblSites s);
        Task UpdateSiteAsync(TblSites s);
        Task DeleteSiteAsync(int id);
    }
}
