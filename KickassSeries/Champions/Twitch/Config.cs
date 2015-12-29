using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using KickassSeries.MenuSettings;
using Color = System.Drawing.Color;

// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace KickassSeries.Champions.Twitch
{
    public static class Config
    {
        private static readonly string MenuName = "KA " + Player.Instance.ChampionName;

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel(Player.Instance.ChampionName + " Hu3Series");
            Menu.AddLabel("Made By: iRaxe", 50);

            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu
                DrawMenu,
                ComboMenu,
                HarassMenu,
                LaneclearMenu,
                OtherMenu;

            static Modes()
            {
                DrawMenu = Menu.AddSubMenu("Draw");
                Draw.Initialize();
                ComboMenu = Menu.AddSubMenu("Combo");
                Combo.Initialize();
                HarassMenu = Menu.AddSubMenu("Harass");
                Harass.Initialize();
                LaneclearMenu = Menu.AddSubMenu("Laneclear");
                LaneClear.Initialize();
                OtherMenu = Menu.AddSubMenu("Misc Functions");
                Other.Initialize();

            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                private static readonly Slider _minEStacks;
                private static readonly Slider _minREnemies;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static int MinEStacks
                {
                    get { return _minEStacks.CurrentValue; }
                }

                public static int MinREnemies
                {
                    get { return _minREnemies.CurrentValue; }
                }

                static Combo()
                {
                    ComboMenu.AddGroupLabel("Combo");
                    _useQ = ComboMenu.Add("comboQ", new CheckBox("Ambush (Q Spell)"));
                    _useW = ComboMenu.Add("comboW", new CheckBox("Venom Cask (W Spell)"));
                    _useE = ComboMenu.Add("comboE", new CheckBox("Contaminate (E Spell)"));
                    _useR = ComboMenu.Add("comboR", new CheckBox("Rat-Ta-Tat-Tat (R Spell)"));
                    _minEStacks = ComboMenu.Add("comboMinEStacks",
                        new Slider("Minimum stacks to Contaminate (E Spell)", 6, 1, 6));
                    _minREnemies = ComboMenu.Add("comboMinREnemies",
                        new Slider("Minimum enemies in range to ult", 3, 1, 5));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _minEStacks;

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int MinEStacks
                {
                    get { return _minEStacks.CurrentValue; }
                }

                static Harass()
                {
                    HarassMenu.AddGroupLabel("Harass");
                    _useW = HarassMenu.Add("harassW", new CheckBox("Venom Cask (W Spell)"));
                    _useE = HarassMenu.Add("harassE", new CheckBox("Contaminate (E Spell)"));
                    _minEStacks = HarassMenu.Add("harassMinEStacks",
                        new Slider("Minimum stacks to Contaminate (E Spell)", 4, 1, 6));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _minWTargets;
                private static readonly Slider _minETargets;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int MinWTargets
                {
                    get { return _minWTargets.CurrentValue; }
                }

                public static int MinETargets
                {
                    get { return _minETargets.CurrentValue; }
                }

                static LaneClear()
                {
                    LaneclearMenu.AddGroupLabel("LaneClear");
                    _useQ = LaneclearMenu.Add("laneUseQ", new CheckBox("Use Ambush (Q Spell)"));
                    _useW = LaneclearMenu.Add("laneUseW", new CheckBox("Use Venom Cask (W Spell)"));
                    _useE = LaneclearMenu.Add("laneUseE", new CheckBox("Use Contaminate (E Spell)"));
                    _minWTargets = LaneclearMenu.Add("minWTargetsLC", new Slider("Minimum targets for W", 4, 1, 10));
                    _minETargets = LaneclearMenu.Add("minETargetsLC", new Slider("Minimum targets for E", 4, 1, 10));
                }

                public static void Initialize()
                {
                }
            }

            public static class Other
            {
                private static readonly CheckBox _gapcloserW;
                private static readonly CheckBox _ksE;
                private static readonly CheckBox _autoQ;
                private static readonly CheckBox _stealthRecall;
                private static readonly Slider _autoQMinEnemies;
                private static readonly Slider _minQMana;
                private static readonly Slider _minWMana;
                private static readonly Slider _minEMana;
                private static readonly Slider _minRMana;

                public static int MinQMana
                {
                    get { return _minQMana.CurrentValue; }
                }

                public static int MinWMana
                {
                    get { return _minWMana.CurrentValue; }
                }

                public static int MinEMana
                {
                    get { return _minEMana.CurrentValue; }
                }

                public static int MinRMana
                {
                    get { return _minRMana.CurrentValue; }
                }
                
                public static bool GapcloserUseW
                {
                    get { return _gapcloserW.CurrentValue; }
                }

                public static bool KsE
                {
                    get { return _ksE.CurrentValue; }
                }

                public static bool AutoQ
                {
                    get { return _autoQ.CurrentValue; }
                }

                public static bool StealthRecall
                {
                    get { return _stealthRecall.CurrentValue; }
                }

                public static int AutoQMinEnemies
                {
                    get { return _autoQMinEnemies.CurrentValue; }
                }

                static Other()
                {
                    OtherMenu.AddGroupLabel("AntiGapcloser");
                    _gapcloserW = OtherMenu.Add("gapcloserW", new CheckBox("Venom Cask (W Spell) against gapclosers", false));
                    OtherMenu.AddGroupLabel("KillSteal");
                    _ksE = OtherMenu.Add("ksE", new CheckBox("KillSteal E"));
                    OtherMenu.AddGroupLabel("Auto Q usage");
                    _autoQ = OtherMenu.Add("autoQ", new CheckBox("Ambush (Q Spell) when X enemies around", false));
                    _autoQMinEnemies = OtherMenu.Add("autoQMinEnemiesAround", new Slider("Minimum enemies around to auto Q", 3, 1, 5));
                    OtherMenu.AddGroupLabel("Other");
                    _stealthRecall = OtherMenu.Add("stealthRecall", new CheckBox("Use Stealth when recalling"));
                    OtherMenu.AddGroupLabel("Mana Manager");
                    _minQMana = OtherMenu.Add("minQMana", new Slider("Minimum mana % to Ambush (Q Spell)", 10));
                    _minWMana = OtherMenu.Add("minWMana", new Slider("Minimum mana % to Venom Cask (W Spell)", 50));
                    _minEMana = OtherMenu.Add("minEMana", new Slider("Minimum mana % to Contaminate (E Spell)", 10));
                    _minRMana = OtherMenu.Add("minRMana", new Slider("Minimum mana % to Rat-Ta-Tat-Tat (R Spell)", 100));
                }

                public static void Initialize()
                {
                }
            }

            public static class Draw
            {
                private static readonly CheckBox _drawHealth;
                private static readonly CheckBox _drawQ;
                private static readonly CheckBox _drawW;
                private static readonly CheckBox _drawE;
                private static readonly CheckBox _drawR;

                private static readonly CheckBox _drawReady;

                public static bool DrawHealth
                {
                    get { return _drawHealth.CurrentValue; }
                }

                public static bool DrawQ
                {
                    get { return _drawQ.CurrentValue; }
                }

                public static bool DrawW
                {
                    get { return _drawW.CurrentValue; }
                }

                public static bool DrawE
                {
                    get { return _drawE.CurrentValue; }
                }

                public static bool DrawR
                {
                    get { return _drawR.CurrentValue; }
                }

                public static bool DrawReady
                {
                    get { return _drawReady.CurrentValue; }
                }


                public static Color colorHealth
                {
                    get { return DrawMenu.GetColor("colorHealth"); }
                }

                public static Color colorQ
                {
                    get { return DrawMenu.GetColor("colorQ"); }
                }

                public static Color colorW
                {
                    get { return DrawMenu.GetColor("colorW"); }
                }

                public static Color colorE
                {
                    get { return DrawMenu.GetColor("colorE"); }
                }

                public static Color colorR
                {
                    get { return DrawMenu.GetColor("colorR"); }
                }

                public static float _widthQ
                {
                    get { return DrawMenu.GetWidth("widthQ"); }
                }

                public static float _widthW
                {
                    get { return DrawMenu.GetWidth("widthW"); }
                }

                public static float _widthE
                {
                    get { return DrawMenu.GetWidth("widthE"); }
                }

                public static float _widthR
                {
                    get { return DrawMenu.GetWidth("widthR"); }
                }

                static Draw()
                {
                    DrawMenu.AddGroupLabel("Draw");
                    _drawReady = DrawMenu.Add("drawReady", new CheckBox("Draw Only If The Spells Are Ready.", false));
                    DrawMenu.AddSeparator();
                    DrawMenu.AddLabel("Reload is required to aply the changes made in the damage indicator");
                    _drawHealth = DrawMenu.Add("drawHealth", new CheckBox("Draw Damage in HealthBar"));
                    DrawMenu.AddColorItem("colorHealth");
                    DrawMenu.AddSeparator();
                    //Q
                    _drawQ = DrawMenu.Add("drawQ", new CheckBox("Draw Ambush (Q Spell)"));
                    DrawMenu.AddColorItem("colorQ");
                    DrawMenu.AddWidthItem("widthQ");
                    //W
                    _drawW = DrawMenu.Add("drawW", new CheckBox("Draw Venom Cask (W Spell)"));
                    DrawMenu.AddColorItem("colorW");
                    DrawMenu.AddWidthItem("widthW");
                    //E
                    _drawE = DrawMenu.Add("drawE", new CheckBox("Draw Contaminate (E Spell)"));
                    DrawMenu.AddColorItem("colorE");
                    DrawMenu.AddWidthItem("widthE");
                    //R
                    _drawR = DrawMenu.Add("drawR", new CheckBox("Draw Rat-Ta-Tat-Tat (R Spell)"));
                    DrawMenu.AddColorItem("colorR");
                    DrawMenu.AddWidthItem("widthR");
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}