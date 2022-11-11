using Fluxor;
using Fluxor.Persist.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.SideBarUseCase
{
    public class SideBarFeature : Feature<SideBarState>
    {
        public const string FeatureKey = "SideBar";
        public override string GetName() => FeatureKey;

        protected override SideBarState GetInitialState() => new SideBarState();
    }
}
