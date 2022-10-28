using Fluxor;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Fluxor.Store.UserUseCase
{
    [FeatureState]
    public class UserState
    {
        public Username Username { get; }
        public UserState() 
        {
            Username = new Username(new Email("test@test.com"));
        }
        public UserState(Username username)
        {

        }
    }
}
