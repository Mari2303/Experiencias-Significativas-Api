using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Email.Interfaces
{
    public interface IEmailService
    {
        Task SendExperiencesEmail(string emailReceptor, string recoveryCode);
    }
}
