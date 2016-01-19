namespace KickassSeries.Activator.SummonerSpells
{
    internal class Initialize : Extensions
    {
        public static int lastSpell;

        public static void Init()
        {
            if (HasSpell("summonersmite"))
            {
                Spells.Smite.Initialize();
            }

            if (HasSpell("summonerheal"))
            {
                Spells.Heal.Initialize();
            }

            if (HasSpell("summonerbarrier"))
            {
                Spells.Barrier.Initialize();
            }

            if (HasSpell("summonerexhaust"))
            {
                //TODO EXHAUST
            }

            if (HasSpell("summonerghost"))
            {
                Spells.Ghost.Initialize();
            }
        }

        public static void Execute()
        {
            if (HasSpell("summonersmite"))
            {
                Spells.Smite.Execute();
            }

            if (HasSpell("summonerheal"))
            {
                Spells.Heal.Execute();
            }

            if (HasSpell("summonerbarrier"))
            {
                Spells.Barrier.Execute();
            }
        }
    }
}
