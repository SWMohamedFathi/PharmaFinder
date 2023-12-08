using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;
using PharmaFinder.Infra.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadPrescriptionController : ControllerBase
    {
        private readonly IReadPrescriptionService _prescriptionReadService;

        public ReadPrescriptionController(IReadPrescriptionService readPrescriptionService)
        {
            _prescriptionReadService = readPrescriptionService;
        }

        [HttpPost("ReadPrescription")]
        public IActionResult ReadPrescription(IFormFile file)
        {
            try
            {
                if (file == null || file.Length <= 0)
                    return BadRequest("Invalid file or empty content.");

                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;

                    List<String> extractedPdf = _prescriptionReadService.ExtractWordsFromPDF(stream);
                    List<Medicine> medicines = _prescriptionReadService.FindMatchingMedicines(extractedPdf);
                    
                    return Ok(medicines);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}

