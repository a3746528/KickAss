using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace KickassSeries.Champions.Jinx
{
    public static class SpellManager
    {
        public static Spell.Active Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot R { get; private set; }

        static SpellManager()
        {
            //Need to finish
            Q = new Spell.Active(SpellSlot.Q, Modes.PermaActive.Qrange);
            //Q radius = 150
            W = new Spell.Skillshot(SpellSlot.W, 1500, SkillShotType.Linear, 250, 90);
            E = new Spell.Skillshot(SpellSlot.E, 1000, SkillShotType.Linear, 250, 1530, 60);
            R = new Spell.Skillshot(SpellSlot.R, 410, SkillShotType.Circular, 250, 1200, 30);
        }

        public static void Initialize()
        {
        }
    }
}
