using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

using Settings = KickassSeries.Activator.Config.Types.Settings;

namespace KickassSeries.Activator.DMGHandler
{
    public static class DamageHandler
    {
        public static bool ReceivingAA;
        public static bool ReceivingSkillShot;
        public static bool ReceivingSpell;
        public static bool ReceivingDangSpell;

        public static void Initialize()
        {
            Obj_AI_Base.OnBasicAttack += Obj_AI_Base_OnBasicAttack;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
        }

        private static void Obj_AI_Base_OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {

        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
           
            //Targetted spell
 
        }

        #region Extensions

        public static bool InDanger(this AIHeroClient hero)
        {
            if (ReceivingDangSpell)
            {
                return true;
            }
            if (ReceivingSpell || ReceivingAA || ReceivingSkillShot)
            {
                if (Player.Instance.HealthPercent < Settings.HealthDanger)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion Extensions
    }
}
