using Portal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores
{
    public interface ITableState<TDataType>
    {
        Page<TDataType>? Page { get; }
        bool IsLoading { get; }
    }
}
