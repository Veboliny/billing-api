using back_facturation_api.Classes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace back_facturation_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetClient")]
        public IEnumerable<Client> Get()
        {
            yield return new Client
            {
                Nom = "Leterme",
                Prenom = "Thomas",
                Age = 23,
                DateNaissance = DateOnly.FromDateTime(DateTime.Now)
            };
        }
    }
}