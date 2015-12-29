using System.Linq;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Twitch.Config.Modes.LaneClear;
using Other = KickassSeries.Champions.Twitch.Config.Modes.Other;

namespace KickassSeries.Champions.Twitch.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (Settings.UseQ && Q.IsReady() && PlayerMana >= Other.MinEMana)
            {
                Q.Cast();
            }

            if (Settings.UseE && E.IsReady() && PlayerMana >= Other.MinEMana)
            {
                var monstersCount =
                    EntityManager.MinionsAndMonsters.GetJungleMonsters(PlayerPos, E.Range)
                        .Count(m => m.IsValidTarget() && EStacks(m) >= 6);
                if (monstersCount >= Settings.MinETargets)
                {
                    E.Cast();
                }
            }
            if (Settings.UseW && W.IsReady() && PlayerMana >= Other.MinWMana)
            {
                var monsters =
                    EntityManager.MinionsAndMonsters.GetJungleMonsters(PlayerPos, W.Range)
                        .Where(m => m.IsValidTarget());
                var position = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(monsters, W.Width, (int)W.Range);
                
                    W.Cast(position.CastPosition);
            }
        }
    }
}
