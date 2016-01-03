using System.Collections.Generic;
using EloBuddy;

namespace KickassSeries.Activator.DMGHandler
{
    public class DangerousSpell
    {
        public DangerousSpell(Champion _hero, SpellSlot slot)
        {
            Slot = slot;
            Hero = _hero;
        }

        public SpellSlot Slot;
        public Champion Hero;
    }

    public class DangerousSpells
    {
        public static List<DangerousSpell> Spells = new List<DangerousSpell>
        {
            new DangerousSpell(Champion.Annie, SpellSlot.R),
            new DangerousSpell(Champion.Caitlyn, SpellSlot.R),
            new DangerousSpell(Champion.Darius, SpellSlot.R),
            new DangerousSpell(Champion.Malphite, SpellSlot.R),
            new DangerousSpell(Champion.Zed, SpellSlot.R),
            new DangerousSpell(Champion.Yasuo, SpellSlot.R),
            new DangerousSpell(Champion.Syndra, SpellSlot.R),
            new DangerousSpell(Champion.Ahri, SpellSlot.E),
            new DangerousSpell(Champion.Amumu, SpellSlot.R),
            new DangerousSpell(Champion.Ashe, SpellSlot.R),
            new DangerousSpell(Champion.Braum, SpellSlot.R),
            new DangerousSpell(Champion.Gnar, SpellSlot.R),
            new DangerousSpell(Champion.Gragas, SpellSlot.R),
            new DangerousSpell(Champion.Lux, SpellSlot.R),
            new DangerousSpell(Champion.Lux, SpellSlot.Q),
            new DangerousSpell(Champion.Varus, SpellSlot.R),
            new DangerousSpell(Champion.Veigar, SpellSlot.E),
            new DangerousSpell(Champion.Nami, SpellSlot.R),
            new DangerousSpell(Champion.Nami, SpellSlot.Q),
            new DangerousSpell(Champion.Sona, SpellSlot.R),
            new DangerousSpell(Champion.Shen, SpellSlot.E),
            new DangerousSpell(Champion.Riven, SpellSlot.R),
            new DangerousSpell(Champion.Blitzcrank, SpellSlot.Q),
            new DangerousSpell(Champion.Blitzcrank, SpellSlot.R),
            new DangerousSpell(Champion.Morgana, SpellSlot.Q),
            new DangerousSpell(Champion.Morgana, SpellSlot.R),
            new DangerousSpell(Champion.Vayne, SpellSlot.E),
            new DangerousSpell(Champion.Pantheon, SpellSlot.W),
            new DangerousSpell(Champion.Garen, SpellSlot.R),
            new DangerousSpell(Champion.JarvanIV, SpellSlot.R),
            new DangerousSpell(Champion.Mordekaiser, SpellSlot.R),
            new DangerousSpell(Champion.Vladimir, SpellSlot.R),
            new DangerousSpell(Champion.Ezreal, SpellSlot.R)
        };
    }
}
