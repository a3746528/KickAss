using System;
using EloBuddy;
using KickassSeries.Activator.DMGHandler;
using KickassSeries.Activator.Items;

namespace KickassSeries.Activator
{
    public static class Activator
    {
        public static int lastUsed;
        public static void Init()
        {
            Config.Initialize();

            Game.OnUpdate += Game_OnUpdate;

            SummonerSpells.Initialize.Init();

            DamageHandler.Initialize();

            EventsManager.Initialize();
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            Defensive.Execute();
            Offensive.Execute();
            Consumables.Execute();

            SummonerSpells.Initialize.Execute();
        }
    }
}
