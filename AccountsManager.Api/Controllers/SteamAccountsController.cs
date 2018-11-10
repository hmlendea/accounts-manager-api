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

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<SteamAccount> steamAccounts = repository.GetAll().ToApiModels();

            return Ok(steamAccounts);
        }

        [HttpGet("{username}")]
        public ActionResult<string> Get(string username)
        {
            SteamAccount steamAccount = repository.Get(username).ToApiModel();

            return Ok(steamAccount);
        }

        [HttpPost]
        public void Post([FromBody] SteamAccount steamAccount)
        {
            repository.Add(steamAccount.ToDataObject());
        }

        [HttpPut("{username}")]
        public void Put(string username, [FromBody] SteamAccount steamAccount)
        {
            repository.Update(username, steamAccount.ToDataObject());
        }

        [HttpDelete("{username}")]
        public void Delete(string username)
        {
            repository.Remove(username);
        }
    }
}
