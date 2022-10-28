using Fluxor;
using Fluxor.Persist.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.OrganizationMsalCase
{
    public class OrganizationMsalFeature : Feature<OrganizationMsalState>
    {
        public const string FeatureKey = "OrganizationMsal";
        public override string GetName() => FeatureKey;

        protected override OrganizationMsalState GetInitialState() => new OrganizationMsalState(false, null);
    }
}
