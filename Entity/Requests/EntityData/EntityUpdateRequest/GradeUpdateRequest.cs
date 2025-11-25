using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityUpdateRequest
{
    public class GradeUpdateRequest
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
