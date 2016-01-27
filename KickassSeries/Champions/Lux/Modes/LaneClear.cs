using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Lux.Config.Modes.LaneClear;

namespace KickassSeries.Champions.Lux.Modes
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

            var minions =
               EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                   Player.Instance.Position, E.Range, false).ToArray();
            if (minions.Length == 0) return;

            var location = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(minions, E.Width, (int)E.Range);

            if (Settings.UseE && Settings.LaneMana <= Player.Instance.ManaPercent && location.HitNumber >= Settings.ECount)
            {
                E.Cast(location.CastPosition);
            }
        }
    }
}
