using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Lux.Config.Modes.Misc;
using DMG = KickassSeries.Activator.DMGHandler.DamageHandler;

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
            if (W.IsReady() && Settings.WDefense && Player.Instance.Mana >= Settings.WMana)
            {
                if (DMG.ReceivingSkillShot || DMG.ReceivingSpell || DMG.ReceivingDangSpell)
                {
                    W.Cast(Player.Instance);
                }
            }

            if (R.IsReady() && Settings.KillStealR && Player.Instance.ManaPercent >= Settings.KillStealMana)
            {
                var targetR = TargetSelector.GetTarget(R.Range, DamageType.Magical);
                if (targetR == null || targetR.IsZombie || targetR.HasUndyingBuff()) return;

                if (targetR.Health <= SpellDamage.GetRealDamage(SpellSlot.R, targetR) &&
                    !targetR.IsInAutoAttackRange(Player.Instance) && targetR.Health > 150)
                {
                    R.Cast(R.GetPrediction(targetR).CastPosition);
                }
            }
        }
    }
}
