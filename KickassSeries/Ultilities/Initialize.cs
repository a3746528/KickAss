using EloBuddy;

namespace KickassSeries.Ultilities
{
    internal class Initialize
    {
        public static void Init()
        {
            Config.Initialize();

            Trackers.RecallTracker.Initialize();

            Trackers.SpellsTracker.Initialize();

            Trackers.WardTracker.Initialize();

            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(System.EventArgs args)
        {
            //SkinHack.Execute();
        }
    }
}
