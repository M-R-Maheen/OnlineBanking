using JwtAuthAPI.Models.BankModel;
using JwtAuthAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace JwtAuthAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository _repository;

        public AccountController(AccountRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        // GET All Account
        [HttpGet]
        public async Task<List<Account>> Get()
        {
            return await _repository.GetAll();
        }

        // Get By AccountID
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> Get(int accountID)
        {
            var response = await _repository.GetByDeposotId(accountID);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST Account
        [HttpPost]
        public async Task<string> Post([FromBody] Account account)
        {
            string data = await _repository.CreateNewAccount(account);
            return data;
        }

        //// --- PUT 
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string account)
        //{

        //}

        // DELETE Account
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteByAccountID(id);
        }
    }

}
