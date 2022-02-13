using StardewModdingAPI;
using StardewModdingAPI.Enums;
using ContentPatcher;

using ImagEd.Framework;


namespace ImagEd {
    public class ModEntry : Mod {
        private RecolorToken recolorToken_;
        public override void Entry(IModHelper helper) {
            recolorToken_ = new RecolorToken(this.Helper, this.Monitor);

            helper.Events.GameLoop.GameLaunched += (sender, e) => {
                var api = this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
                api.RegisterToken(this.ModManifest, "Recolor", recolorToken_);
            };

            // Enable when basic save loaded, disable when returned to title.
            // Note the we can't simply use GameLoop.SaveLoaded because it's too late
            // for editing stuff like LooseSprites/emojis at this point.
            helper.Events.Specialized.LoadStageChanged += (sender, e) => {
                if (e.NewStage == LoadStage.SaveLoadedBasicInfo) {
                    recolorToken_.Enabled = true;
                }
            };
            helper.Events.GameLoop.ReturnedToTitle += (sender, e) => recolorToken_.Enabled = false;
        }
    }
}
