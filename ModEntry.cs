using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Extensions;
using StardewValley.Locations;
using xTile.Layers;
using HarmonyLib;
using PassableDescents.Patches;

namespace PassableDescents {
    internal class ModEntry : Mod {

        public override void Entry(IModHelper helper) {

            var harmony = new Harmony(ModManifest.UniqueID);

            harmony.Patch(
                original: AccessTools.Method(typeof(MineShaft), "doCreateLadderDown"),
                postfix: new HarmonyMethod(typeof(MineShaftPatch), nameof(MineShaftPatch.DoCreateLadder_Postfix))
            );
            harmony.Patch(
                original: AccessTools.Method(typeof(MineShaft), "doCreateLadderAt"),
                postfix: new HarmonyMethod(typeof(MineShaftPatch), nameof(MineShaftPatch.DoCreateLadderAt_Postfix))
            );
        }

    }
}
