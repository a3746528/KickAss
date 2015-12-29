using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using Other = KickassSeries.Champions.Twitch.Config.Modes.Other;

namespace KickassSeries.Champions.Twitch
{
    internal static class EventsManager
    {
        #region Getting Spells from SpellManager
        static Spell.Active Q
        {
            get { return SpellManager.Q; }
        }

        static Spell.Skillshot W
        {
            get { return SpellManager.W; }
        }
        #endregion Getting Spells from SpellManager

        public static void Initialize()
        {
            Gapcloser.OnGapcloser += GapcloserOnOnGapcloser;
            Spellbook.OnCastSpell += OnRecall;
        }

        private static void OnRecall(Spellbook sender, SpellbookCastSpellEventArgs args)
        {
            // Stealth Recall
            if (Other.StealthRecall && args.Slot == SpellSlot.Recall && !SpellManager.QActive && SpellManager.Q.IsReady() && !Player.Instance.IsInShopRange())
            {
                Q.Cast();
            }
        }

        private static void GapcloserOnOnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (Other.GapcloserUseW && sender.IsEnemy && W.IsReady() && sender.IsValidTarget() && e.End.Distance(Player.Instance) <= 200.0f)
            {
                var pred = W.GetPrediction(sender);
                if (pred.HitChance >= EloBuddy.SDK.Enumerations.HitChance.Medium)
                {
                    W.Cast(pred.CastPosition);
                }
            }
        }
    }
}
