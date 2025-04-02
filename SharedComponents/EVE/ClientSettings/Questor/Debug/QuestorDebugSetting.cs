using System;

namespace SharedComponents.EVE.ClientSettings
{
    [Serializable]
    public class QuestorDebugSetting
    {

        public QuestorDebugSetting()
        {

        }
        public bool DebugBuyAmmo { get; set; } = false;
        public bool DebugActivateGate { get; set; } = false;
        public bool DebugActivateWeapons { get; set; } = false;
        public bool DebugAddDronePriorityTarget { get; set; } = false;
        public bool DebugAddPrimaryWeaponPriorityTarget { get; set; } = false;
        public bool DebugAgentInteractionReplyToAgent { get; set; } = false;
        public bool DebugArm { get; set; } = false;
        public bool DebugCleanup { get; set; } = false;
        public bool DebugClearPocket { get; set; } = false;
        public bool DebugCombat { get; set; } = false;
        public bool DebugDecline { get; set; } = false;
        public bool DebugDefense { get; set; } = false;
        public bool DebugDoneAction { get; set; } = false;
        public bool DebugDrones { get; set; } = false;
        public bool DebugEntityCache { get; set; } = false;
        public bool DebugFittingMgr { get; set; } = false;
        public bool DebugGetBestTarget { get; set; } = false;
        public bool DebugGetBestDroneTarget { get; set; } = false;
        public bool DebugGotobase { get; set; } = false;
        public bool DebugHangars { get; set; } = false;
        public bool DebugKillTargets { get; set; } = false;
        public bool DebugKillAction { get; set; } = false;
        public bool DebugLoadScripts { get; set; } = false;
        public bool DebugLootWrecks { get; set; } = false;
        public bool DebugNavigateOnGrid { get; set; } = false;
        public bool DebugMoveTo { get; set; } = false;
        public bool DebugOverLoadWeapons { get; set; } = false;
        public bool DebugPanic { get; set; } = false;
        public bool DebugPreferredPrimaryWeaponTarget { get; set; } = false;
        public bool DebugReloadAll { get; set; } = false;
        public bool DebugReloadorChangeAmmo { get; set; } = false;
        public bool DebugSalvage { get; set; } = false;
        public bool DebugSpeedMod { get; set; } = false;
        public bool DebugTargetCombatants { get; set; } = false;
        public bool DebugTargetWrecks { get; set; } = false;
        public bool DebugTractorBeams { get; set; } = false;
        public bool DebugTraveler { get; set; } = false;
        public bool DebugUndockBookmarks { get; set; } = false;
        public bool DebugUnloadLoot { get; set; } = false;
        public bool DebugWatchForActiveWars { get; set; } = false;
        public bool DebugEvEOnFrame { get; set; } = false;
    }
}