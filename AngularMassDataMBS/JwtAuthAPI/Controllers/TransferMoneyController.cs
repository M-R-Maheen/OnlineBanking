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
    public class TransferMoneyController : ControllerBase
    {

        private readonly TransferMoneyRepository _repository;

        public TransferMoneyController(TransferMoneyRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        // GET All TransferMoney
        [HttpGet]
        public async Task<List<TransferMoney>> Get()
        {
            return await _repository.GetAll();
        }

        // Get By TransferMoneyID
        [HttpGet("{id}")]
        public async Task<ActionResult<TransferMoney>> Get(int transferMoneyID)
        {
            var response = await _repository.GetByTransferMoneyID(transferMoneyID);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/TransferMoney
        [HttpPost]
        public async Task<string> Post([FromBody] TransferMoney transferMoney)
        {
            string data = await _repository.InsertTransferMoney(transferMoney);
            return data;
        }

        //// --- PUT 
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string transferMoney)
        //{

        //}

        // DELETE TransferMoney
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteByTransferMoneyID(id);
        }
    }
}
