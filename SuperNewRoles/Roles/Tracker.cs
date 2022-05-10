using HarmonyLib;
using Hazel;
using System;
using SuperNewRoles.Patches;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperNewRoles.Buttons;
using SuperNewRoles.CustomOption;
using SuperNewRoles.CustomRPC;

namespace SuperNewRoles.Roles
{
    class Tracker
    {

        public static bool isTracker(PlayerControl Player)
        {
            if (RoleClass.Tracker.TrackerPlayer.IsCheckListPlayerControl(Player))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //î≠êMã@ÇÃêßå‰
        //public static bool UsedTracker = false;

        public static void IsTrackerTrackPlayerButtonStart()
        {
            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CustomRPC.TrackerUsedTracker, Hazel.SendOption.Reliable, -1);
            writer.Write(RoleClass.Tracker.CurrentTarget.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            RPCProcedure.TrackerUsedTracker(RoleClass.Tracker.CurrentTarget.PlayerId);
        }

        public static void EndMeeting_TrackerTrackPlayerButton()
        {
            HudManagerStartPatch.TrackerTrackPlayerButton.MaxTimer = RoleClass.Tracker.CorpsesTrackingCooldown;
            if (RoleClass.Tracker.ResetTargetAfterMeeting) RoleClass.Tracker.ResetTracked();
        }


        //éÄëÃí«ê’ÇÃêßå‰
        //public static bool CanTrackCorpses = false;//éÄëÃÇí«ê’Ç≈Ç´ÇÈ
    }
}