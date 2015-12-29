using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;


using Settings = KickassSeries.Champions.Twitch.Config.Modes.Combo;
using Other = KickassSeries.Champions.Twitch.Config.Modes.Other;

namespace KickassSeries.Champions.Twitch.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (Settings.UseQ && Q.IsReady() && !QActive && PlayerMana >= Other.MinQMana)
            {
                var enemiesAround = EntityManager.Heroes.Enemies.Any(e => e.IsValidTarget(2500.0f));
                if (enemiesAround)
                {
                    Q.Cast();
                }
            }
            if (Settings.UseE && E.IsReady() && PlayerMana >= Other.MinEMana)
            {
                var enemy =
                    EntityManager.Heroes.Enemies
                        .FirstOrDefault(e => e.IsValidTarget(E.Range) && EStacks(e) >= Settings.MinEStacks);
                if (enemy != null)
                {
                    E.Cast();
                }
            }
            if (Settings.UseR && R.IsReady() && PlayerMana >= Other.MinRMana)
            {
                var enemiesAround =
                    EntityManager.Heroes.Enemies
                        .Count(e => e.IsValidTarget(1000.0f));
                if (enemiesAround >= Settings.MinREnemies)
                {
                    R.Cast();
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

