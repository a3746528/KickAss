﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Corki.Config.Modes.LaneClear;

namespace KickassSeries.Champions.Corki.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.IsValidTarget(Q.Range));

            if (minion == null) return;

            if (Q.IsReady() && minion.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                Q.Cast(minion);
            }

            if (W.IsReady() && minion.IsValidTarget(W.Range) && Settings.UseW)
            {
                W.Cast(minion);
            }

            if (E.IsReady() && minion.IsValidTarget(E.Range) && Settings.UseE && Player.Instance.IsFacing(minion))
            {
                E.Cast(minion);
            }
        }
    }
}
