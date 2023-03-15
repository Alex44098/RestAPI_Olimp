using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICheckAuthorization
    {
        public Task<bool> Check(string login, string password);
    }
}
