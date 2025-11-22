using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Entity/Requests/EntityData/EntityUpdateRequest/LeaderUpdateRequest.cs
namespace Entity.Requests.EntityData.EntityUpdateRequest
========
namespace Entity.Requests.EntityData.EntityDetailRequest
>>>>>>>> HU-24-dev:Entity/Requests/EntityData/EntityDetailRequest/LeaderDetailRequest.cs
{
    public class LeaderUpdateRequest
    {
        public string NameLeaders { get; set; } = string.Empty;
        public string IdentityDocument { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public uint Phone { get; set; }
    }
}
