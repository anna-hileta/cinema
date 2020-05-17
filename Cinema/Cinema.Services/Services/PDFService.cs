using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Cinema.Services.PDF;
using Cinema.Services.PDF.Documents;
using Cinema.Services.PDF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Services.Services
{
    public class PDFService : IPDFService
    {
        public async Task<byte[]> DecesionCreatePDFAsync(Check pdfData)
        {
            IPDFSettings pdfSettings = new PDFSettings()
            {
                Title = string.Format("Check")
            };
            IPDFCreator creator = new PDFCreator(new MovieCheck(pdfData, pdfSettings));
            return await Task.Run(() => creator.GetPDFBytes());
        }
        public async Task<byte[]> DecesionCreatePDFAsyncForFood(FoodcourtCheck pdfData)
        {
            IPDFSettings pdfSettings = new PDFSettings()
            {
                Title = string.Format("Check")
            };
            IPDFCreator creator = new PDFCreator(new FoodCheck(pdfData, pdfSettings));
            return await Task.Run(() => creator.GetPDFBytes());
        }
    }
}
