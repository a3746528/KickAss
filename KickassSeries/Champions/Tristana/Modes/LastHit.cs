using System.Linq;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Tristana.Config.Modes.LaneClear;

namespace KickassSeries.Champions.Tristana.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
        }
    }
}
