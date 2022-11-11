using Orleans;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Interfaces.Public
{
    public interface IUserGrain : IGrainWithGuidKey
    {
        public Task<UserTableData> GetTableData();
    }
}
