﻿using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = KickassSeries.Activator.Config.Types.OffensiveItems;
using Misc = KickassSeries.Activator.Config.Types.Settings;

namespace KickassSeries.Activator.Maps.Twistedtreeline.Items
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class Offensive : Summoner.Items.Ids
    {
        public static void Execute()
        {
            if (Activator.lastUsed > Environment.TickCount) return;

            var target = TargetSelector.GetTarget(1000, DamageType.Mixed);

            if (target != null && !Player.Instance.IsRecalling() &&
                (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) ||
                 Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear)))
            {
                if (Settings.Bilgewater && BilgewaterCutlass.IsOwned() && BilgewaterCutlass.IsReady() &&
                    target.IsValidTarget(BilgewaterCutlass.Range))
                {
                    if (target.HealthPercent < Settings.BilgewaterTargetHp)
                    {
                        BilgewaterCutlass.Cast(target);
                        Activator.lastUsed = Environment.TickCount + Misc.DelayBetweenOff;
                    }
                }

                if (Settings.Blade && BladeOfTheRuinedKing.IsOwned() && BladeOfTheRuinedKing.IsReady() &&
                    target.IsValidTarget(BladeOfTheRuinedKing.Range))
                {
                    if (Settings.BladeMyHp > Player.Instance.HealthPercent &&
                        target.HealthPercent < Settings.BladeTargetHp)
                    {
                        BladeOfTheRuinedKing.Cast(target);
                        Activator.lastUsed = Environment.TickCount + Misc.DelayBetweenOff;
                    }
                }

                var minions = EntityManager.MinionsAndMonsters.EnemyMinions.Count(m => m.IsValidTarget(Tiamat.Range));
                if (Settings.Tiamat && Tiamat.IsOwned() && Tiamat.IsReady() && target.IsValidTarget(Tiamat.Range) ||
                    minions > 2)
                {
                    if (target.HealthPercent < Settings.TiamatTargetHp && Misc.AACancel
                        ? EventsManager.CanAACancel
                        : Tiamat.IsReady())
                    {
                        Tiamat.Cast();
                        Activator.lastUsed = Environment.TickCount + Misc.DelayBetweenOff;
                    }
                }

                if (Settings.Hydra && Hydra.IsOwned() && Hydra.IsReady() && target.IsValidTarget(Hydra.Range) ||
                    minions > 2)
                {
                    if (target.HealthPercent < Settings.HydraTargetHp && Misc.AACancel
                        ? EventsManager.CanAACancel
                        : Hydra.IsReady())
                    {
                        Hydra.Cast();
                        Activator.lastUsed = Environment.TickCount + Misc.DelayBetweenOff;
                    }
                }

                if (Settings.Titanic && TitanicHydra.IsOwned() && TitanicHydra.IsReady() &&
                    target.IsValidTarget(TitanicHydra.Range) || minions > 2)
                {
                    if (target.HealthPercent < Settings.TitanicTargetHp && Misc.AACancel
                        ? EventsManager.CanAACancel
                        : TitanicHydra.IsReady())
                    {
                        TitanicHydra.Cast();
                        Activator.lastUsed = Environment.TickCount + Misc.DelayBetweenOff;
                    }
                }

                if (Settings.Youmuu && Youmuu.IsOwned() && Youmuu.IsReady() && target.IsValidTarget(Youmuu.Range))
                {
                    if (target.HealthPercent < Settings.YoumuuTargetHp)
                    {
                        Youmuu.Cast();
                        Activator.lastUsed = Environment.TickCount + Misc.DelayBetweenOff;
                    }
                }

                if (Settings.Hextech && Hextech.IsOwned() && Hextech.IsReady() && target.IsValidTarget(Hextech.Range))
                {
                    if (target.HealthPercent < Settings.HextechTargetHp)
                    {
                        Hextech.Cast(target);
                        Activator.lastUsed = Environment.TickCount + Misc.DelayBetweenOff;
                    }
                }
            }
        }
    }
}