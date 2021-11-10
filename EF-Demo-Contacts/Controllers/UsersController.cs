using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Classes;
using BL.Interfaces;
using DAL.Interfaces;
using DAL.Classes;
using DAL.Models;
//בשביל חיבור צד הקליינט והסרבר
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;

namespace EF_Demo_Contacts.Controllers
{
    //בשביל חיבור צד הקליינט והסרבר
    [EnableCors()]


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserBL userBL;

        public UsersController(IUserBL _userBL)
        {
            userBL = _userBL;
        }

        [HttpPost("AddUser")]
        public async Task<List<TblUsers>> AddUserAsync(DataOfUser data)
        {
            await this.userBL.AddUserAsync(data.u, data.c);
            return await userBL.GetAllUsersAsync();
        }

        [HttpDelete("DeleteUser/{email}")]
        public async Task<List<TblUsers>> DeleteUserAsync(string email)
        {
            await this.userBL.DeleteUserAsync(email);
            return await userBL.GetAllUsersAsync();
        }

        [HttpGet("GetAllUsers")]
        public async Task<List<TblUsers>> GetAllUsersAsync()
        {
            return await this.userBL.GetAllUsersAsync();
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<TblUsers> GetUserByEmailAsync(string email)
        {
            return await this.userBL.GetUserByEmailAsync(email);
        }

        [HttpPut("UpdateUser")]
        public async Task<List<TblUsers>> UpdateUserAsync(TblUsers s)
        {
            await this.userBL.UpdateUserAsync(s);
            return await this.userBL.GetAllUsersAsync();
        }
    }
}
