using System;
using EloBuddy;
using KickassSeries.Activator.DMGHandler;
using KickassSeries.Activator.Items;

namespace KickassSeries.Activator
{
    public static class Activator
    {
        public static void Init()
        {
            Config.Initialize();

            Game.OnTick += Game_OnTick;

            SummonerSpells.Initialize.Init();

            DamageHandler.Initialize();
        }

        private static void Game_OnTick(EventArgs args)
        {
            SummonerSpells.Initialize.Execute();
            Defensive.Execute();
            Offensive.Execute();
            Consumables.Execute();
        }
    }
}
