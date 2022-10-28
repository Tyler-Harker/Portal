using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.UserOrganizationUseCase
{
    public class UserOrganizationFeature : Feature<UserOrganizationState>
    {
        public const string FeatureKey = "UserOrganization";
        public override string GetName() => FeatureKey;

        protected override UserOrganizationState GetInitialState() => new UserOrganizationState(null, null, false, null);
    }
}
