using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Interfaces.Internal
{
    public interface IUserGrain : Public.IUserGrain
    {
        Task Create(UserId id, Username username, FirstName firstName, LastName lastName);
    }
}
