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
    public class TransactionController : ControllerBase
    {
        public ITransactionServices  _transactionServices { get; set; }
        public IUserAccountService _userAccountService { get; set; }
        public TransactionController(ITransactionServices transactionServices, IUserAccountService userAccountService)
        {
            _transactionServices = transactionServices;
            _userAccountService = userAccountService;
        }
        [HttpGet]
        public async Task<IActionResult> getTransactions()
        {
            try
            {
                return  Ok(await _transactionServices.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> getTransactionById(int id)
        {
            try
            {
                return Ok(await _transactionServices.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
        {
            try
            {
                return Ok(await _transactionServices.Add(transaction));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
