using BankingApp.Models;
using BankingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        public IUserAccountService _userAccountService { get; set; }
        public UserAccountsController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        [HttpGet]
        public async Task<IActionResult> getUserAccounts()
        {
            try
            {
                return  Ok(await _userAccountService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> getUserById(int id)
        {
            try
            {
                return Ok(await _userAccountService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAccount([FromBody] UserAccount userAccount)
        {
            try
            {
                return Ok(await _userAccountService.Add(userAccount));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
