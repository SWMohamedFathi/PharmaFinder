using iTextSharp.text.pdf;
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
        [HttpGet]
        [Route("GetPharmacyCount")]
        public int GetPharmacyCount()
        {
            return _pharmacyService.GetPharmacyCount();
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


        [HttpGet]
        [Route("GetAllMedcineInPharmmacy/{id}")]
        public List<GetAllMedicineInPharmacy> GetAllMedcineInPharmmacy(decimal id)
        {
            return _pharmacyService.GetAllMedcineInPharmmacy(id);
        }
        [HttpGet]
        [Route("GetAllOrdersInPharmmacy/{id}")]
        public List<Order> GetAllOrdersInPharmmacy(decimal id)
        {
            return _pharmacyService.GetAllOrdersInPharmmacy(id);
        }

        [HttpGet]
        [Route("GetMedicineCountInPharmacy/{id}")]
        public int GetMedicineCountInPharmacy(decimal id)
        {
            return _pharmacyService.GetMedicineCountInPharmacy(id);
        }

        [HttpGet]
        [Route("SalesPharmacy/{id}")]
        public int SalesPharmacy(decimal id)
        {
            return _pharmacyService.SalesPharmacy(id);
        }
        [HttpPost]
        [Route("GetAllOrderMedsByOrderIdInPharmacy/{pharmacyId}/{orderId}")]
        public List<GetAllOrderMedsByOrderIdInPharmacy> GetAllOrderMedsByOrderIdInPharmacy(decimal pharmacyId, decimal orderId)
        {
            // Use 'pharmacyId' and 'orderId' in your logic
            return _pharmacyService.GetAllOrderMedsByOrderIdInPharmacy(pharmacyId, orderId);
        }

        [HttpPost]
        [Route("SalesSearch")]
        public List<SalesSearchInPharmacy> SalesSearch(SalesSearch2 search)
        {
            return _pharmacyService.SalesSearch(search);
        }






    }
}
