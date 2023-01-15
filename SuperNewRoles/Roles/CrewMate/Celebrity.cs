using SuperNewRoles.Mode;
using System.Timers;
using UnityEngine;

namespace SuperNewRoles.Roles.Crewmate;
class Celebrity
{
    private static Timer timer;

    /// <summary>
    /// 試合中に変動しない「タスクフェイズ中に画面を光らせるか」の条件を取得する。
    /// SHRでない且つ スターがアサインされ 且つ設定が有効ならtrueになる。
    /// </summary>
    private static bool IsFirstDecisionAboutFlash()
    {
        if (ModeHandler.IsMode(ModeId.SuperHostRoles)) return false;
        if (RoleClass.Celebrity.ViewPlayers.Count <= 0) return false;
        if (!CustomOptionHolder.CelebrityIsTaskPhaseFlash.GetBool()) return false;
        return true;
    }
    /// <summary>
    /// 試合中に変動する「タスクフェイズ中に画面を光らせるか」の条件を取得する。
    /// タイマーの有効、無効の設定に使用している。
    /// </summary>
    private static bool EnabledSetting()
    {
        // スターが死んでいても発光し 且つ スターがSKされてもスターの能力を失わない設定の場合 trueを返す。
        if (!CustomOptionHolder.CelebrityIsFlashWhileAlivingOnly.GetBool() && RoleClass.Celebrity.ChangeRoleView) return true;

        // スターが存在し、生きているなら trueを返す
        foreach (PlayerControl p in RoleClass.Celebrity.CelebrityPlayer)
        {
            if (p.IsAlive()) return true;
        }

        // スターがSKされてもスターの能力を失わない設定の時
        if (RoleClass.Celebrity.ChangeRoleView)
        {
            // SKスターが生存しているなら trueを返す
            foreach (PlayerControl p in RoleClass.Celebrity.CelebrityPlayer)
            {
                if (p.IsAlive()) return true;
            }
        }

        // スターが死んでも発光し スターがSKされた時スターの能力を失う設定 の場合
        if (!CustomOptionHolder.CelebrityIsFlashWhileAlivingOnly.GetBool() && !RoleClass.Celebrity.ChangeRoleView)
        {
            // スターが死亡している場合trueを返す
            foreach (PlayerControl p in RoleClass.Celebrity.CelebrityPlayer)
            {
                if (p.IsDead()) return true;
            }
        }

        Logger.Info("スターの輝きが現れる条件を満たしませんでした。「あなたたちは 真の闇におちるのです」", "CelebrityFlash");
        return false;
    }
    public static void WrapUp()
    {
        if (IsFirstDecisionAboutFlash()) CelebrityTimerSet();
    }

    /// <summary>
    /// タイマーをセットする
    /// </summary>
    private static void CelebrityTimerSet()
    {
        timer = new Timer(RoleClass.Celebrity.FlashTime);
        timer.Elapsed += (source, e) =>
        {
            Seer.ShowFlash(Color.yellow);
            Logger.Info($"{RoleClass.Celebrity.FlashTime / 1000}s 経過した為発光しました。「走れ、光よ！」", "CelebrityFlash");
        };
        bool enabled = EnabledSetting();
        timer.AutoReset = enabled;
        timer.Enabled = enabled;
        if (!enabled) return;
        Logger.Info($"{RoleClass.Celebrity.FlashTime}[ミリ秒]にタイマーセット ", "CelebrityFlash");
    }
    public static void TimerStop()
    {
        if (timer != null)
        {
            timer.Stop();
            Logger.Info("発光用タイマーを止めました。", "CelebrityFlash");
        }
    }
}
