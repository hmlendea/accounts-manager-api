using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using AccountsManager.Api.Mapping;
using AccountsManager.Api.Models;
using AccountsManager.DataAccess.DataObjects;
using AccountsManager.DataAccess.Repositories;

namespace AccountsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SteamAccountsController : ControllerBase
    {
        readonly IAccountsRepository<SteamAccountEntity> repository;

        public SteamAccountsController(IAccountsRepository<SteamAccountEntity> repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<SteamAccount> steamAccounts = repository.GetAll().ToApiModels();

            return Ok(steamAccounts);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            SteamAccount steamAccount = new SteamAccount();
            steamAccount.Username = "testus";
            steamAccount.Password = "testassword";
            steamAccount.EmailAddress = "testus@test.com";
            steamAccount.Country = "RO";

            return Ok(steamAccount);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
