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
        }
    }
}
