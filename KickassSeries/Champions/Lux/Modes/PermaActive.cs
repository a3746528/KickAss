using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Lux.Config.Modes.Misc;
using DMG = KickassSeries.Activator.Maps.Twistedtreeline.DMGHandler.DamageHandler;

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
            
            if (Q.IsReady() && Settings.KillStealQ && Player.Instance.ManaPercent >= Settings.KillStealMana)
            {
                var targetQ = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
                if (targetQ == null || targetQ.IsZombie || targetQ.HasUndyingBuff()) return;

                if (targetQ.Health <= SpellDamage.GetRealDamage(SpellSlot.Q, targetQ) &&
                    !targetQ.IsInAutoAttackRange(Player.Instance) && targetQ.Health > 80)
                {
                    Q.Cast(Q.GetPrediction(targetQ).CastPosition);
                }
            }
            
            if (E.IsReady() && Settings.KillStealE && Player.Instance.ManaPercent >= Settings.KillStealMana)
            {
                var targetE = TargetSelector.GetTarget(E.Range, DamageType.Magical);
                if (targetE == null || targetE.IsZombie || targetE.HasUndyingBuff()) return;

                if (targetE.Health <= SpellDamage.GetRealDamage(SpellSlot.E, targetE) &&
                    !targetE.IsInAutoAttackRange(Player.Instance) && targetE.Health > 80)
                {
                    E.Cast(E.GetPrediction(targetE).CastPosition);
                }
            }
            
            if (R.IsReady() && Settings.KillStealR && Player.Instance.ManaPercent >= Settings.KillStealMana)
            {
                var targetR = TargetSelector.GetTarget(R.Range, DamageType.Magical);
                if (targetR == null || targetR.IsZombie || targetR.HasUndyingBuff()) return;

                if (targetR.Health <= SpellDamage.GetRealDamage(SpellSlot.R, targetR) &&
                    !targetR.IsInAutoAttackRange(Player.Instance) && targetR.Health > 150)
                {
                    if (targetR.HasBuffOfType(BuffType.Snare) || targetR.HasBuffOfType(BuffType.Stun))
                    {
                        R.Cast(targetR.Position);
                    }
                    else
                    {
                        R.Cast(R.GetPrediction(targetR).CastPosition);
                    }
                }
            }
        }
    }
}
