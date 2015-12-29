using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Twitch.Config.Modes.Other;
namespace KickassSeries.Champions.Twitch.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            // KillSteal
            if (Settings.KsE && E.IsReady())
            {
                var enemy = EntityManager.Heroes.Enemies.FirstOrDefault(e => e.IsValidTarget(E.Range) && e.TotalShieldHealth() < Damages.EDamage(e));
                if (enemy != null)
                {
                    if (!enemy.HasBuffOfType(BuffType.SpellImmunity) && !enemy.HasBuffOfType(BuffType.SpellShield))
                    {
                        E.Cast();
                    }
                }
            }
            
            // Automatic Q usage
            if (Settings.AutoQ && Q.IsReady() && !QActive && !Player.Instance.IsRecalling())
            {
                var enemiesNear =
                    EntityManager.Heroes.Enemies.Count(e => !e.IsDead && e.Health > 0 && e.IsVisible && e.Distance(Player.Instance) < 1500);
                if (enemiesNear >= Settings.AutoQMinEnemies)
                {
                    Q.Cast();
                }
            }
        }
    }
}
