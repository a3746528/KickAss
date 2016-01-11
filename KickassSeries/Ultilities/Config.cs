using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberHidesStaticFromOuterClass

namespace KickassSeries.Ultilities
{
    internal static class Config
    {
        private const string MenuName = "KA Ultilities";

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("KA Ultilities");
            Menu.AddLabel("Made By: MarioGK", 50);

            Types.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Types
        {
            private static readonly Menu RecallTrackerMenu, SpellTrackerMenu;

            static Types()
            {
                RecallTrackerMenu = Menu.AddSubMenu("Recall Tracker");
                RecallTracker.Initialize();

                SpellTrackerMenu = Menu.AddSubMenu("Spell Tracker");
                SpellTracker.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class RecallTracker
            {
                private static readonly CheckBox _turnOff;

                public static bool TurnOff
                {
                    get { return _turnOff.CurrentValue; }
                }

                static RecallTracker()
                {
                    RecallTrackerMenu.AddGroupLabel("RecallTracker");
                    _turnOff = RecallTrackerMenu.Add("turnoffrecalltracker", new CheckBox("Turn off recall tracker ?", false));
                }

                public static void Initialize()
                {
                }
            }

            public static class SpellTracker
            {
                private static readonly CheckBox _turnOff;
                private static readonly CheckBox _drawEnemies;
                private static readonly CheckBox _drawAllies;

                public static bool TurnOff
                {
                    get { return _turnOff.CurrentValue; }
                }

                public static bool DrawEnemies
                {
                    get { return _drawEnemies.CurrentValue; }
                }

                public static bool DrawAllies
                {
                    get { return _drawAllies.CurrentValue; }
                }

                static SpellTracker()
                {
                    SpellTrackerMenu.AddGroupLabel("SpellTracker");
                    _turnOff = SpellTrackerMenu.Add("turnoffspelltracker", new CheckBox("Turn Off Spell Tracker ?" ,false));
                    _drawEnemies = SpellTrackerMenu.Add("drawenemiesid", new CheckBox("Draw Enemies ?"));
                    _drawAllies = SpellTrackerMenu.Add("drawalliesid", new CheckBox("Draw Allies ?"));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}


