using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores
{
    public interface IFormState<TData>
    {
        TData? Model { get; }
        bool IsLoading { get; }
    }
}
