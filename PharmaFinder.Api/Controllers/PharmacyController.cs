using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpGet]
        [Route("GetAllPharmacies")]
        public List<Pharmacy> GetAllPharmacies()
        {
            return _pharmacyService.GetAllPharmacies();
        }

        [HttpGet]
        [Route("GetPharmacyById/{id}")]
        public Pharmacy GetPharmacyById(decimal id)
        {
            return _pharmacyService.GetPharmacyById(id);
        }

        [HttpPost]
        [Route("CreatePharmacy")]
        public IActionResult CreatePharmacy(Pharmacy pharmacy)
        {
            _pharmacyService.CreatePharmacy(pharmacy);
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdatePharmacy")]
        public IActionResult UpdatePharmacy( Pharmacy pharmacy)
        {
            _pharmacyService.UpdatePharmacy(pharmacy);
            return Ok();
        }

        [HttpDelete]
        [Route("DeletePharmacy/{id}")]
        public IActionResult DeletePharmacy(decimal id)
        {
            _pharmacyService.DeletePharmacy(id);
            return Ok();
        }


        [HttpPost]
        [Route("SearchPharmacyName")]
        public List<PharmacyNameSearch> SearchPharmacyName(PharmacyNameSearch search)
        {
            return _pharmacyService.SearchPharmacyName(search);
        }


    }
}
