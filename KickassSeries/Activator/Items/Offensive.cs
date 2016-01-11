using System;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Activator.Config.Types.OffensiveItems;
using Misc = KickassSeries.Activator.Config.Types.Settings;

namespace KickassSeries.Activator.Items
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class Offensive : Ids
    {
        private static int LastItemUsed;

        public static void Execute()
        {
            if (LastItemUsed > Environment.TickCount) return;

            var target = TargetSelector.GetTarget(900, DamageType.Mixed);

            if (Player.Instance.IsRecalling() || Player.Instance.IsInShopRange() || target == null ||
                !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) return;

            if (Settings.Bilgewater && BilgewaterCutlass.IsOwned() && BilgewaterCutlass.IsReady())
            {
                if (Settings.BilgewaterMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.BilgewaterTargetHp)
                {
                    BilgewaterCutlass.Cast(target);
                    LastItemUsed = Environment.TickCount + Misc.DelayBetweenOff;
                }
            }

            if (Settings.Blade && BladeOfTheRuinedKing.IsOwned() && BladeOfTheRuinedKing.IsReady())
            {
                if (Settings.BladeMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.BladeTargetHp)
                {
                    BladeOfTheRuinedKing.Cast(target);
                    LastItemUsed = Environment.TickCount + Misc.DelayBetweenOff;
                }
            }

            if (Settings.Tiamat && Tiamat.IsOwned() && Tiamat.IsReady())
            {
                if (Settings.TiamatMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.TiamatTargetHp && Misc.AACancel ? EventsManager.CanAACancel : Tiamat.IsReady())
                {
                    Tiamat.Cast();
                    LastItemUsed = Environment.TickCount + Misc.DelayBetweenOff;
                }
            }

            if (Settings.Hydra && Hydra.IsOwned() && Hydra.IsReady())
            {
                if (Settings.HydraMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.HydraTargetHp && Misc.AACancel ? EventsManager.CanAACancel : Hydra.IsReady())
                {
                    Hydra.Cast();
                    LastItemUsed = Environment.TickCount + Misc.DelayBetweenOff;
                }
            }

            if (Settings.Titanic && TitanicHydra.IsOwned() && TitanicHydra.IsReady())
            {
                if (Settings.TitanicMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.TitanicTargetHp && Misc.AACancel ? EventsManager.CanAACancel : TitanicHydra.IsReady())
                {
                    TitanicHydra.Cast();
                    LastItemUsed = Environment.TickCount + Misc.DelayBetweenOff;
                }
            }

            if (Settings.Youmuu && Youmuu.IsOwned() && Youmuu.IsReady())
            {
                if (Settings.YoumuuMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.YoumuuTargetHp)
                {
                    Youmuu.Cast();
                    LastItemUsed = Environment.TickCount + Misc.DelayBetweenOff;
                }
            }

            if (Settings.Hextech && Hextech.IsOwned() && Hextech.IsReady())
            {
                if (Settings.HextechMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.HextechTargetHp)
                {
                    Hextech.Cast(target);
                    LastItemUsed = Environment.TickCount + Misc.DelayBetweenOff;
                }
            }
        }
    }
}
