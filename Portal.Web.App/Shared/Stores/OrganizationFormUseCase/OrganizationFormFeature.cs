using Fluxor;
using Fluxor.Persist.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationFormUseCase
{
    public class OrganizationFormFeature : Feature<OrganizationFormState>
    {
        public const string FeatureKey = "OrganizationForm";
        public override string GetName() => FeatureKey;

        protected override OrganizationFormState GetInitialState() => new OrganizationFormState();
    }
}
