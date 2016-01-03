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
            if (Player.Instance.InDanger())
            {
                Chat.Print("Player in danger = " + Player.Instance.InDanger());
            }

            //Defensive.Execute();
            //Offensive.Execute();
            //Consumables.Execute();
        }
    }
}
