using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace PharmaFinder.Api.Controllers
{
   
    [ApiController]
    public class ReportPDFController : ControllerBase
    {
        private async Task<IActionResult> DownloadFile(string filename)
        {
            var DownloadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "GeneratedReportPDF", filename);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(DownloadFilePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(DownloadFilePath);
            return File(bytes, contentType, Path.GetFileName(DownloadFilePath));
        }


        [HttpGet]
        [Route("GeneratePDFfromURL")]

        public async Task<IActionResult> GeneratePDFfromURL(string URLlink)
        {
            var renderer = new ChromePdfRenderer();
            var pdf = renderer.RenderUrlAsPdf(URLlink);
            string PDFfilename = DateTime.Now.Ticks.ToString() + ".pdf";
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "GeneratedReportPDF", PDFfilename));

            return await DownloadFile(PDFfilename);
        }

        [HttpGet]
        [Route("GeneratePDFfromFile")]

        public async Task<IActionResult> GeneratePDFfromFile()
        {
            string PDFfilename = DateTime.Now.Ticks.ToString() + ".pdf";

            var renderer = new ChromePdfRenderer();
            var pdf = renderer.RenderHtmlFileAsPdf(@"C:\Users\Amjad\source\repos\SWMohamedFathi\PharmaFinder\PharmaFinder.Api\UploadReport\\index.html");
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "GeneratedReportPDF", PDFfilename));

            return await DownloadFile(PDFfilename);
        }

        [HttpGet]
        [Route("GeneratePDFfromhtml")]

        public async Task<IActionResult> GeneratePDFfromhtml()
        {
            string PDFfilename = DateTime.Now.Ticks.ToString() + ".pdf";

            var renderer = new ChromePdfRenderer();
            var pdf = renderer.RenderHtmlAsPdf("<h1>Monthly Report</h1>");
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "GeneratedReportPDF", PDFfilename));

            return await DownloadFile(PDFfilename);
        }
    }
}
