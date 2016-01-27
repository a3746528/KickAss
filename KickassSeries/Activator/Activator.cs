using System;
using EloBuddy;
using KickassSeries.Activator.DMGHandler;

namespace KickassSeries.Activator
{
    public static class Activator
    {
        public static int lastUsed;
        public static void Init()
        {
            Config.Initialize();

            

            SummonerSpells.Initialize.Init();

            DamageHandler.Initialize();

            EventsManager.Initialize();

            switch (Game.MapId)
            {
                case GameMapId.CrystalScar:
                    Game.OnUpdate += CrystalScar;
                    break;
                case GameMapId.TwistedTreeline:
                    Game.OnUpdate += TwistedTreeline;
                    break;
                case GameMapId.SummonersRift:
                    Game.OnUpdate += SummonerRift;
                    break;
                case GameMapId.HowlingAbyss:
                    Game.OnUpdate += HowlingAbyss;
                    break;
            }
        }

        private static void CrystalScar(EventArgs args)
        {
            Maps.Summoner.Items.Defensive.Execute();
            Maps.Summoner.Items.Offensive.Execute();
            Maps.Summoner.Items.Consumables.Execute();

            SummonerSpells.Initialize.Execute();
        }

        private static void TwistedTreeline(EventArgs args)
        {
            Maps.Summoner.Items.Defensive.Execute();
            Maps.Summoner.Items.Offensive.Execute();
            Maps.Summoner.Items.Consumables.Execute();

            SummonerSpells.Initialize.Execute();
        }

        private static void SummonerRift(EventArgs args)
        {
            Maps.Summoner.Items.Defensive.Execute();
            Maps.Summoner.Items.Offensive.Execute();
            Maps.Summoner.Items.Consumables.Execute();

            SummonerSpells.Initialize.Execute();
        }

        private static void HowlingAbyss(EventArgs args)
        {
            Maps.Summoner.Items.Defensive.Execute();
            Maps.Summoner.Items.Offensive.Execute();
            Maps.Summoner.Items.Consumables.Execute();

            SummonerSpells.Initialize.Execute();
        }
    }
}
