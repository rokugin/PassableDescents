using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Locations;
using xTile.Tiles;

namespace PassableDescents.Patches;

static class MineShaftPatch {

    public static void DoCreateLadder_Postfix(MineShaft __instance, Point point) {
        DelayedAction delayedAction = new DelayedAction(200);
        delayedAction.behavior = () => {
            int X = point.X;
            int Y = point.Y;
            Tile tile = Game1.currentLocation.map.GetLayer("Buildings").Tiles[X, Y];

            tile.Properties.Add("Passable", "T");
        };
        Game1.delayedActions.Add(delayedAction);
    }

    public static void DoCreateLadderAt_Postfix(Vector2 p) {
        int X = (int)p.X;
        int Y = (int)p.Y;
        Tile tile = Game1.currentLocation.map.GetLayer("Buildings").Tiles[X, Y];

        tile.Properties.Add("Passable", "T");
    }

}
