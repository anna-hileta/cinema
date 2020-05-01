using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services.PDF.Interfaces
{
    internal interface IPDFCreator
    {
        byte[] GetPDFBytes();
    }
}
