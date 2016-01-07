using EloBuddy;
using EloBuddy.SDK;

namespace KickassSeries.Champions.Jinx.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public static uint Qrange;
        public override void Execute()
        {
            Qrange = (uint)Player.Instance.GetAutoAttackRange();
        }
    }
}
