using System;
using EloBuddy;
using KickassSeries.Activator.Maps.Twistedtreeline.DMGHandler;

namespace KickassSeries.Activator
{
    public static class Activator
    {
        public static int lastUsed;
        public static void Init()
        {
            DamageHandler.Initialize();

            EventsManager.Initialize();

            switch (Game.MapId)
            {
                case GameMapId.CrystalScar:
                    //Maps.CrystalScar.Config.Initialize();
                    //Game.OnUpdate += CrystalScar;
                    break;
                case GameMapId.TwistedTreeline:
                    //Maps.Twistedtreeline.Config.Initialize();
                    //Game.OnUpdate += TwistedTreeline;
                    break;
                case GameMapId.SummonersRift:
                    Maps.Summoner.Config.Initialize();
                    //Game.OnUpdate += SummonerRift;
                    break;
                case GameMapId.HowlingAbyss:
                    //Maps.HowlingAbyss.Config.Initialize();
                    //Game.OnUpdate += HowlingAbyss;
                    break;
            }

            SummonerSpells.Initialize.Init();
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
