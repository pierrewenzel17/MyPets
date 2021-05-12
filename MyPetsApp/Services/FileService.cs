using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPetsApp.WebServices;
using MyPetsCore.DTOs;

namespace MyPetsApp.Services
{
    public class FileService
    {
        public FileService()
        {
            
        }

        public async Task<InvestigationDocumentDto> CreateFile(byte[] file)
        {
            InvestigationDocumentDto doc = new(null, file);
            DocumentWebService dws = new();
            doc = await dws.CreateDocumentAsync(doc);
            return doc;
        }
    }
}
