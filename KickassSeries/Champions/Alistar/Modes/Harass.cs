﻿using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Alistar.Config.Modes.Harass;

namespace KickassSeries.Champions.Alistar.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            if (target == null || target.IsZombie) return;

            if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW)
            {
                W.Cast(target);
            }

            if (Q.IsReady() && target.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                Q.Cast();
            }
        }
    }
}
