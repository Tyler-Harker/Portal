using Fluxor;
using Fluxor.Persist.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.UserUseCase
{
    public class UserFeature : Feature<UserState>
    {
        public const string FeatureKey = "User";
        public override string GetName() => FeatureKey;

        protected override UserState GetInitialState() => new UserState(null, null);
    }
}

