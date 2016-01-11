using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Jinx.Config.Modes.Flee;

namespace KickassSeries.Champions.Jinx.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (Settings.UseW && W.IsReady())
            {
                var enemy =
                    EntityManager.Heroes.Enemies.FirstOrDefault(
                        t => W.IsInRange(t) && t.IsValidTarget() && !Player.Instance.IsInAutoAttackRange(t));

                if (enemy != null)
                {
                    var prediction = W.GetPrediction(enemy);

                    if (prediction.HitChancePercent >= Settings.WPredPercentage)
                    {
                        W.Cast(prediction.CastPosition);
                    }
                }
            }

            if (Settings.UseE && E.IsReady())
            {
                var enemy =
                    EntityManager.Heroes.Enemies.FirstOrDefault(
                        t =>
                            E.IsInRange(t) && t.IsValidTarget() && t.IsMelee &&
                            t.IsInAutoAttackRange(Player.Instance));

                if (enemy != null)
                {
                    var prediction = E.GetPrediction(enemy);

                    if (prediction.HitChancePercent >= Settings.EPredPercentage)
                    {
                        E.Cast(prediction.CastPosition);
                    }
                }
            }
        }
    }
}

