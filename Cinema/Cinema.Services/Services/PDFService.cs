using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services.Services
{
    /*
    public class PDFService : IPDFService
    {
        public async Task<byte[]> DecesionCreatePDFAsync(Decesion pdfData)
        {
            IPDFSettings pdfSettings = new PDFSettings()
            {
                Title = string.Format("Рішення {0}", pdfData.Organization.OrganizationName)
            };
            IPDFCreator creator = new PDFCreator(new DecisionDocument(pdfData, pdfSettings));
            return await Task.Run(() => creator.GetPDFBytes());
        }
    }
    */
}
