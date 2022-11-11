using Fluxor;
using Fluxor.Persist.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationRolesTableUseCase
{
    public class OrganizationRolesTableFeature : Feature<OrganizationRolesTableState>
    {
        public const string FeatureKey = "OrganizationRolesTable";
        public override string GetName() => FeatureKey;

        protected override OrganizationRolesTableState GetInitialState() => new OrganizationRolesTableState();
    }
}
