using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Routing.Store
{
    public abstract class BaseState
    {
        public bool IsLoading { get; }
        public string? CurrentErrorMessage { get; }
        public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);
        public BaseState(bool isLoading, string? currentErrorMessage) => (IsLoading, CurrentErrorMessage) = (isLoading, currentErrorMessage);
    }
}
