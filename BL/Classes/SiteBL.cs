using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using DAL.Interfaces;
using DAL.Classes;
using DAL.Models;
using BL.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace BL.Classes
{
    public class SiteBL : ISiteBL
    {
        ISiteDAL siteDAL;

        public SiteBL(ISiteDAL _siteDAL)
        {
            this.siteDAL = _siteDAL;
        }
        public async Task AddSiteAsync(TblSites s)
        {
            await this.siteDAL.AddSiteAsync(s);
        }

        public async Task DeleteSiteAsync(int id)
        {
            await this.siteDAL.DeleteSiteAsync(id);
        }

        public async Task<List<TblSites>> GetAllSitesAsync()
        {
            return await this.siteDAL.GetAllSitesAsync();
        }

        public async Task<TblSites> GetSiteByIdAsync(int id)
        {
            return await this.siteDAL.GetSiteByIdAsync(id);
        }

        public async Task UpdateSiteAsync(TblSites s)
        {
            await this.siteDAL.UpdateSiteAsync(s);
        }
    }
}
