using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using JwtAuthAPI.Repository;
using JwtAuthAPI.Models.BankModel;

namespace JwtAuthAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {

        private readonly DepositRepository _repository;

        public DepositController(DepositRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        // GET All Deposit
        [HttpGet]
        public async Task<List<Deposit>> Get()
        {
            return await _repository.GetAll();
        }

        // Get By DepositID
        [HttpGet("{id}")]
        public async Task<ActionResult<Deposit>> Get(int depositID)
        {
            var response = await _repository.GetByDeposotId(depositID);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/Deposits
        [HttpPost]
        public async Task<string> Post([FromBody] Deposit deposit)
        {
            string data = await _repository.InsertDeposit(deposit);
            return data;
        }

        //// --- PUT 
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string deposit)
        //{

        //}

        // DELETE Deposit
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteByDepositId(id);
        }
    }
}

