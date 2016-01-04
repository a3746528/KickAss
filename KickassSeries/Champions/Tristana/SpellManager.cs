using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace KickassSeries.Champions.Tristana
{
    public static class SpellManager
    {
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Targeted E { get; private set; }
        public static Spell.Skillshot R { get; private set; }

        static SpellManager()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 800, SkillShotType.Linear, 250, int.MaxValue, 85)
            {
                AllowedCollisionCount = int.MaxValue
            };
            W = new Spell.Skillshot(SpellSlot.W, 825, SkillShotType.Circular, 250 , int.MaxValue, 20)
            {
                AllowedCollisionCount = int.MaxValue
            };
            E = new Spell.Targeted(SpellSlot.E, 550);
            R = new Spell.Skillshot(SpellSlot.R, 700, SkillShotType.Circular, 250, 1200, 500)
            {
                AllowedCollisionCount = int.MaxValue
            };
        }

        public static void Initialize()
        {
            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        private static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if(!sender.IsMe)return;

            E = new Spell.Targeted(SpellSlot.E, 543 + 7 * (uint)Player.Instance.Level);
        }
    }
}
