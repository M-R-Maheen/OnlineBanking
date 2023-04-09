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
    public class BalanceController : ControllerBase
    {
        private readonly BalanceRepository _repository;

        public BalanceController(BalanceRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        // GET All Balance Data in list
        [HttpGet]
        public async Task<List<Balance>> Get()
        {
            return await _repository.GetAll();
        }

        // Get By BalanceID
        [HttpGet("{id}")]
        public async Task<ActionResult<Balance>> Get(int balanceID)
        {
            var response = await _repository.GetByBalanceId(balanceID);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST Balance
        [HttpPost]
        public async Task<string> Post([FromBody] Balance balance)
        {
            string data = await _repository.InsertBalance(balance);
            return data;
        }

        //// --- PUT 
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string balance)
        //{

        //}

        // DELETE Balance
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteByBalanceId(id);
        }
    }

}
