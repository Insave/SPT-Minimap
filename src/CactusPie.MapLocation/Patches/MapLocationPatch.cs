using System.Reflection;
using Aki.Reflection.Patching;
using Comfort.Common;
using EFT;

namespace CactusPie.MapLocation.Patches
{
    public sealed class MapLocationPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(GameWorld).GetMethod("OnGameStarted", BindingFlags.Public | BindingFlags.Instance);
        }

        [PatchPostfix]
        public static void PatchPostFix()
        {
            GameWorld gameWorld = Singleton<GameWorld>.Instance;
            MapLocationPlugin.MapLocationLogger.LogError("Patch: Creating Controller");

            if (gameWorld == null)
            {
                return;
            }

            gameWorld.gameObject.AddComponent<MapLocationController>();
        }
    }
}