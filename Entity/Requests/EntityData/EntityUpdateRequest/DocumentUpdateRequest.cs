using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Entity/Requests/EntityData/EntityUpdateRequest/DocumentUpdateRequest.cs



namespace Entity.Requests.EntityData.EntityUpdateRequest

========
namespace Entity.Requests.EntityData.EntityCreateRequest
>>>>>>>> 9772023a4adec7d6575e146a5cb956bfd3d03eff:Entity/Requests/EntityData/EntityCreateRequest/DocumentCreateRequest.cs
{
    public class DocumentUpdateRequest
    {
        public string Name { get; set; } = string.Empty;
        public string UrlLink { get; set; } = string.Empty;
        public string UrlPdf { get; set; } = string.Empty;
        public string UrlPdfExperience { get; set; } = string.Empty;


    }
}
