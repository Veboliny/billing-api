using back_facturation_api.Classes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace back_facturation_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculeController : ControllerBase
    {
        private readonly ILogger<VehiculeController> _logger;

        public VehiculeController(ILogger<VehiculeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetVehicule")]
        public IEnumerable<Vehicule> Get()
        {
            yield return new Vehicule
            {
                Marque = "AUDI A4",
                Annee = 2024,
                Prix = 23000,
                DateMiseEnCirculation = DateOnly.FromDateTime(DateTime.Now)
            };
        }
    }
}