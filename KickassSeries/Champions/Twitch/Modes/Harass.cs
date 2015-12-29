using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

using Settings = KickassSeries.Champions.Twitch.Config.Modes.Harass;
using Other = KickassSeries.Champions.Twitch.Config.Modes.Other;

namespace KickassSeries.Champions.Twitch.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            if (Settings.UseE && E.IsReady() && PlayerMana >= Other.MinEMana)
            {
                var enemy =
                    EntityManager.Heroes.Enemies.FirstOrDefault(
                        e => e.IsValidTarget(E.Range) && EStacks(e) >= Settings.MinEStacks);
                if (enemy != null)
                {
                    E.Cast();
                }
            }
            if (Settings.UseW && W.IsReady() && PlayerMana >= Other.MinWMana)
            {
                var enemy = TargetSelector.GetTarget(W.Range, DamageType.True);
                if (enemy != null && enemy.IsValidTarget(W.Range))
                {
                    var pred = W.GetPrediction(enemy);
                    if (pred.HitChance >= HitChance.Medium)
                    {
                        W.Cast(pred.CastPosition);
                    }
                }
            }
        }
    }
}
