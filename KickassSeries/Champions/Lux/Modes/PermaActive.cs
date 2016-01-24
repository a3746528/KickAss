using EloBuddy;
using EloBuddy.SDK;
using Settings = KickassSeries.Champions.Lux.Config.Modes.Misc;

namespace KickassSeries.Champions.Lux.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            if (R.IsReady() && Settings.KillStealR && Player.Instance.ManaPercent >= Settings.KillStealMana)
            {
                var targetR = TargetSelector.GetTarget(R.Range, DamageType.Magical);
                if (targetR == null || targetR.IsZombie || targetR.HasUndyingBuff()) return;

                if (targetR.Health <= SpellDamage.GetRealDamage(SpellSlot.R, targetR))
                {
                    R.Cast(R.GetPrediction(targetR).CastPosition);
                }
            }
        }
    }
}
