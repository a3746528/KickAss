using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Twitch.Config.Modes.LaneClear;
using Other = KickassSeries.Champions.Twitch.Config.Modes.Other;

namespace KickassSeries.Champions.Twitch.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (Settings.UseQ && Q.IsReady() && PlayerMana >= Other.MinEMana)
            {
                Q.Cast();
            }

            if (Settings.UseE && E.IsReady() && PlayerMana >= Other.MinEMana)
            {
                var minionCount =
                    EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, PlayerPos, E.Range)
                        .Count(m => m.IsValidTarget() && EStacks(m) >= 1);
                if (minionCount >= Settings.MinETargets)
                {
                    E.Cast();
                }
            }
            if (Settings.UseW && W.IsReady() && PlayerMana >= Other.MinWMana)
            {
                var minions =
                    EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, PlayerPos, W.Range)
                        .Where(m => m.IsValidTarget());
                var position = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(minions, W.Width, (int)W.Range);
                if (position.HitNumber >= Settings.MinWTargets)
                {
                    W.Cast(position.CastPosition);
                }
            }
        }
    }
}
