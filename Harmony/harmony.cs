using System.Reflection;
using HarmonyLib;


namespace Harmony {

    public class SpawnInPlace : IModApi {
        public void InitMod(Mod _modInstance) {
            Log.Out("Patching Harmony code from {0} into game assembly.", GetType());
            var harmony = new HarmonyLib.Harmony(GetType().ToString());
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(QuestJournal))]
    [HarmonyPatch("FailAllActivatedQuests")]
    public class SpawnInPlace_QuestJournal_FailAllActivatedQuests_Prefix {
        private static bool Prefix(QuestJournal __instance) {
            // Disable quest failure for death by skipping over the method entirely
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerMoveController))]
    [HarmonyPatch("findSpawnPosition")]
    public class SpawnInPlace_PlayerMoveController_findSpawnPosition_Prefix : PlayerMoveController {
        private static bool Prefix(PlayerMoveController __instance, ref SpawnPosition __result, EntityPlayer ___entityPlayerLocal, bool _bSpawnAtBedRoll) {
            // Spawn at current position on death
            if (GameManager.Instance.IsEditMode() && __instance.respawnReason != RespawnType.Died) {
                return true;
            }
            int x = Utils.Fastfloor(___entityPlayerLocal.position.x);
            int y = Utils.Fastfloor(___entityPlayerLocal.position.y);
            int z = Utils.Fastfloor(___entityPlayerLocal.position.z);
            IChunk chunkFromWorldPos = GameManager.Instance.World.GetChunkFromWorldPos(x, y, z);
            if (chunkFromWorldPos != null) {
                if (___entityPlayerLocal.position.y == Constants.cStartPositionPlayerInLevel.y) {
                    ___entityPlayerLocal.position.y = chunkFromWorldPos.GetHeight(ChunkBlockLayerLegacy.CalcOffset(x, z)) + 1;
                }
                __result = new SpawnPosition(___entityPlayerLocal.GetPosition(), ___entityPlayerLocal.rotation.y);
            }
            return false;
        }
    }

}