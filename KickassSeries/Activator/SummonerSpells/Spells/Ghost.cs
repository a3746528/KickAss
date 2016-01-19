using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KickassSeries.Activator.DMGHandler;

namespace KickassSeries.Activator.SummonerSpells.Spells
{
    internal class Ghost
    {
        public static Spell.Active SummonerGhost;
        public static void Initialize()
        {
            var ghost = Player.Instance.Spellbook.Spells.FirstOrDefault(spell => spell.Name.Contains("ghost"));
            if (ghost != null)
            {
                SummonerGhost = new Spell.Active(ghost.Slot);
            }
        }

        private static void Execute()
        {
            if (!SummonerGhost.IsReady() || Activator.lastUsed >= Environment.TickCount) return;

            if (Player.Instance.InDanger(30))
            {
                SummonerGhost.Cast();
                Activator.lastUsed = Environment.TickCount + 500;
            }
        }
    }
}
