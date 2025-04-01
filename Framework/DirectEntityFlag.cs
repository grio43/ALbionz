﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVESharpCore.Framework
{
    public enum DirectEntityFlag
    {
        version = 5,
        mouseOver = 1,
        selected = 2,
        activeTarget = 3,
        targeting = 4,
        targeted = 5,
        lookingAt = 6,
        threatTargetsMe = 7,
        threatAttackingMe = 8,
        flagOutlaw = 9,
        flagDangerous = 10,
        flagSameFleet = 11,
        flagSamePlayerCorp = 12,
        flagAtWarCanFight = 13,
        flagSameAlliance = 14,
        flagStandingHigh = 15,
        flagStandingGood = 16,
        flagStandingNeutral = 17,
        flagStandingBad = 18,
        flagStandingHorrible = 19,
        flagIsWanted = 20,
        flagAgentInteractable = 21,
        gbEnemySpotted = 22,
        gbTarget = 23,
        gbHealShield = 24,
        gbHealArmor = 25,
        gbHealCapacitor = 26,
        gbWarpTo = 27,
        gbNeedBackup = 28,
        gbAlignTo = 29,
        gbJumpTo = 30,
        gbInPosition = 31,
        gbHoldPosition = 32,
        gbTravelTo = 33,
        gbJumpBeacon = 34,
        gbLocation = 35,
        flagWreckAlreadyOpened = 36,
        flagWreckEmpty = 37,
        flagWarpScrambled = 38,
        flagWebified = 39,
        flagECMd = 40,
        flagSensorDampened = 41,
        flagTrackingDisrupted = 42,
        flagTargetPainted = 43,
        flagAtWarMilitia = 44,
        flagSameMilitia = 45,
        flagEnergyLeeched = 46,
        flagEnergyNeut = 47,
        flagNoStanding = 48,
        flagAlliesAtWar = 49,
        flagSuspect = 50,
        flagCriminal = 51,
        flagLimitedEngagement = 52,
        flagHasKillRight = 53,
        flagWarpScrambledMWD = 54,
        flagGuidanceDisrupted = 55,
        flagRemoteTracking = 56,
        flagEnergyTransfer = 57,
        flagSensorBooster = 58,
        flagECCMProjector = 59,
        flagRemoteHullRepair = 60,
        flagRemoteArmorRepair = 61,
        flagShieldTransfer = 62,
        multiSelected = 63,
        selectedForNavigation = 64,
        flagForcedOn = 65,
        flagSameNpcCorp = 66,
    }
}
