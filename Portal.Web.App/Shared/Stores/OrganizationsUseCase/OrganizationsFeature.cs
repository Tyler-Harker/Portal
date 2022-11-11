using Fluxor;
using Fluxor.Persist.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationsUseCase
{
    public class OrganizationsFeature : Feature<OrganizationsState>
    {
        public const string FeatureKey = "Organizations";
        public override string GetName() => FeatureKey;

        protected override OrganizationsState GetInitialState() => new OrganizationsState(new Portal.Domain.ValueObjects.SkipTake());
    }
}
