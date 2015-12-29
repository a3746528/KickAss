using EloBuddy.SDK;
using EloBuddy;

namespace KickassSeries.Champions.Twitch.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Active Q
        {
            get { return SpellManager.Q; }
        }
        protected Spell.Skillshot W
        {
            get { return SpellManager.W; }
        }
        protected Spell.Active E
        {
            get { return SpellManager.E; }
        }
        protected Spell.Active R
        {
            get { return SpellManager.R; }
        }

        protected float PlayerHealth
        {
            get { return Player.Instance.HealthPercent; }
        }

        protected float PlayerMana
        {
            get { return Player.Instance.ManaPercent; }
        }

     protected SharpDX.Vector3 PlayerPos
        {
            get { return Player.Instance.Position; }
        }
        protected bool RActive
        {
            get { return Player.Instance.HasBuff("TwitchFullAutomatic"); }
        }

        protected bool QActive
        {
            get { return Player.Instance.HasBuff("TwitchHideInShadows"); }
        }

        protected int EStacks(Obj_AI_Base target)
        {
            return SpellManager.EStacks(target);
        }


        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
