using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Entity/Requests/EntityData/EntityCreateRequest/DocumentCreateRequest.cs
namespace Entity.Requests.EntityData.EntityCreateRequest
========
namespace Entity.Requests.EntityData.EntityUpdateRequest
>>>>>>>> HU-24-dev:Entity/Requests/EntityData/EntityUpdateRequest/DocumentUpdateRequest.cs
{
    public class DocumentCreateRequest
    {
        public string Name { get; set; } = string.Empty;
   
        public string UrlLink { get; set; } = string.Empty;
        public string UrlPdf { get; set; }  = string.Empty;
        public string UrlPdfExperience { get; set; }  = string.Empty;


    }
}
