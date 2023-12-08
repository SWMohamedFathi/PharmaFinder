using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{
    public class ReadPrescriptionService : IReadPrescriptionService
    {
        private readonly IMedicineService _medicineService;
        public ReadPrescriptionService(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }
        public List<string> ExtractWordsFromPDF(Stream file)
        {
            var wordsList = new List<string>();

            using (PdfReader reader = new PdfReader(file))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string content = PdfTextExtractor.GetTextFromPage(reader, i);
                    content = content.Replace("\n", " ");
                    string[] words = content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    wordsList.AddRange(words);
                }
            }

            return wordsList;
        }

        public List<Medicine> FindMatchingMedicines(List<string> words)
        {
            List<Medicine> allMedicines = _medicineService.GetAllMedicines();
            List<Medicine> matchingMedicines = new List<Medicine>();

            foreach (Medicine medicine in allMedicines)
            {
                if (words.Any(word => word.Equals(medicine.Medicinename, StringComparison.InvariantCultureIgnoreCase)))
                {
                    matchingMedicines.Add(medicine);
                }
            }

            return matchingMedicines;
        }
    }
}