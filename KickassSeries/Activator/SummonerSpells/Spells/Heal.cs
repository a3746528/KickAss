using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KickassSeries.Activator.DMGHandler;

using Misc = KickassSeries.Activator.Config.Types.Settings;
using Settings = KickassSeries.Activator.Config.Types.SummonerSpells;

namespace KickassSeries.Activator.SummonerSpells.Spells
{
    internal class Heal
    {
        public static Spell.Active SummonerHeal;
        public static void Initialize()
        {
            SetHealtSlot();
        }

        public static void Execute()
        {
            if (Player.Instance.IsInShopRange() ||
                Player.Instance.CountAlliesInRange(Misc.RangeEnemy) < Misc.EnemyCount && !SummonerHeal.IsReady() ||
                SummonerSpells.Initialize.lastSpell + 1500 >= Environment.TickCount || !Settings.UseHeal)
                return;
            var ally =
                EntityManager.Heroes.Allies.OrderByDescending(a => a.Health)
                    .FirstOrDefault(a => a.IsValidTarget(SummonerHeal.Range));
            if (ally.InDanger())
            {
                SummonerHeal.Cast();
                SummonerSpells.Initialize.lastSpell = Environment.TickCount;
            }
        }

        private static void SetHealtSlot()
        {
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("heal"))
                SummonerHeal = new Spell.Active(SpellSlot.Summoner1, 830);
            else if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("heal"))
                SummonerHeal = new Spell.Active(SpellSlot.Summoner2, 830);
        }
    }
}
