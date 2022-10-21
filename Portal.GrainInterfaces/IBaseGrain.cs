using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.GrainInterfaces
{
    public interface IBaseGrain
    {
        Task Deactivate();
        Task Reactivate();
        Task<bool> IsActive();
    }
}
