using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.StringComparer;

using StardewModdingAPI;
using ContentPatcher;

using Newtonsoft.Json.Linq;

using ImagEd.Framework;


namespace ImagEd {
    public class ModEntry : Mod {
        public override void Entry(IModHelper helper) {
            helper.Events.GameLoop.GameLaunched += (sender, e) => {
                var api = this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
                api.RegisterToken(this.ModManifest, "Recolor", new RecolorToken(this.Helper, this.Monitor));
            };
        }
    }
}
