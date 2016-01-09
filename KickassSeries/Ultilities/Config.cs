using EloBuddy.SDK;
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
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("KA Ultilities");
            Menu.AddLabel("Made By: MarioGK", 50);

            // Initialize the modes
            Types.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Types
        {
            private static readonly Menu RecallTrackerMenu, SpellTrackerMenu;
            //public static readonly Menu SkinHackMenu ;

            static Types()
            {
                RecallTrackerMenu = Menu.AddSubMenu("Recall Tracker");
                RecallTracker.Initialize();

                SpellTrackerMenu = Menu.AddSubMenu("Spell Tracker");
                SpellTracker.Initialize();

                //SkinHackMenu = Menu.AddSubMenu("SkinHack");
                //SkinHack.Initialize();
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
            /*
            public static class SkinHack
            {
                private static readonly CheckBox _turnOff;

                private static readonly Slider skinSliderAlly, skinSliderEnemy;


                public static bool TurnOff
                {
                    get { return _turnOff.CurrentValue; }
                }

                static SkinHack()
                {
                    SkinHackMenu.AddGroupLabel("Skin Hack");
                    _turnOff = SkinHackMenu.Add("turnoffskinhack", new CheckBox("Turn Off Skin Hack?"));
                    SkinHackMenu.AddGroupLabel("Allies");

                    foreach (var ally in EntityManager.Heroes.Allies)
                    {
                        skinSliderAlly = SkinHackMenu.Add("kaally" + ally.ChampionName,
                            new Slider("Select a skin for " + ally.ChampionName, 0, 0, 15));
                        SkinHackMenu.AddSeparator();

                        skinSliderAlly.OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                        {
                            if (TurnOff) return;
                            Ultilities.SkinHack.Skins[ally.Name] = args.NewValue;
                            ally.SetSkin(ally.ChampionName, Ultilities.SkinHack.Skins[ally.Name]);
                        };
                    }

                    SkinHackMenu.AddSeparator();

                    SkinHackMenu.AddGroupLabel("Enemies");

                    foreach (var enemy in EntityManager.Heroes.Enemies)
                    {
                        skinSliderEnemy = SkinHackMenu.Add("kaenemy" + enemy.ChampionName,
                            new Slider("Select a skin for " + enemy.ChampionName, 0, 0, 15));
                        SkinHackMenu.AddSeparator();

                        skinSliderEnemy.OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                        {
                            if (TurnOff) return;
                            Ultilities.SkinHack.Skins[enemy.Name] = args.NewValue;
                            enemy.SetSkin(enemy.ChampionName, Ultilities.SkinHack.Skins[enemy.Name]);
                        };
                    }
                }

                public static void Initialize()
                {
                }
            }
            */
        }
    }
}


