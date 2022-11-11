using Fluxor;
using Fluxor.Persist.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationUsersTableUseCase
{
    public class OrganizationUsersTableFeature : Feature<OrganizationUsersTableState>
    {
        public const string FeatureKey = "OrganizationUsersTable";
        public override string GetName() => FeatureKey;

        protected override OrganizationUsersTableState GetInitialState() => new OrganizationUsersTableState();
    }
}
