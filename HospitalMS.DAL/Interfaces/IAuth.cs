using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL.Interfaces
{
    public interface IAuth<RET>
    {
        RET Authenticate(string Username, string Password);
    }
}
