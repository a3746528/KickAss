using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace KickassSeries.Champions.Twitch
{
    public static class SpellManager
    {
        public static Spell.Active Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Active E { get; private set; }
        public static Spell.Active R { get; private set; }
        public static Spell.Active Recall { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Active(SpellSlot.Q);

            W = new Spell.Skillshot(SpellSlot.W, 900, SkillShotType.Circular, 250, 1400, 275);
            W.AllowedCollisionCount = int.MaxValue;

            E = new Spell.Active(SpellSlot.E, 1200);

            R = new Spell.Active(SpellSlot.R, 850);

            Recall = new Spell.Active(SpellSlot.Recall);
        }

        public static bool RActive
        {
            get { return Player.Instance.HasBuff("TwitchFullAutomatic"); }
        }

        public static bool QActive
        {
            get { return Player.Instance.HasBuff("TwitchHideInShadows"); }
        }

        public static int EStacks(Obj_AI_Base target)
        {
            var twitchECount = 0;
            for (var i = 1; i < 7; i++)
            {
                if (ObjectManager.Get<Obj_GeneralParticleEmitter>()
                .Any(e => e.Position.Distance(target.ServerPosition) <= 55 &&
                e.Name == "twitch_poison_counter_0" + i + ".troy"))
                {
                    twitchECount = i;
                }
            }
            return twitchECount;
        }

        public static void Initialize()
        {
        }
    }
}
