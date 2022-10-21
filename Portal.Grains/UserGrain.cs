using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains
{
    public class UserGrain : Interfaces.Internal.IUserGrain
    {
        public Task Create(UserId id, Username username, FirstName firstName, LastName lastName)
        {

        }
    }
}
