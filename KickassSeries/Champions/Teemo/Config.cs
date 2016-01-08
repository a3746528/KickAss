using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using KickassSeries.MenuSettings;
using Color = System.Drawing.Color;

// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace KickassSeries.Champions.Teemo
{
    public static class Config
    {
        private static readonly string MenuName = "KA " + Player.Instance.ChampionName;

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("KA " + Player.Instance.ChampionName);
            Menu.AddLabel("Made By: MarioGK", 50);

            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu ComboMenu,HarassMenu,LaneClearMenu,JungleClearMenu,KSmenu, FleeMenu,MiscMenu, DrawMenu, DebugMenu;

            static Modes()
            {
                ComboMenu = Menu.AddSubMenu("Combo");
                Combo.Initialize();

                HarassMenu = Menu.AddSubMenu("Harass");
                Harass.Initialize();

                LaneClearMenu = Menu.AddSubMenu("LaneClear");
                LaneClear.Initialize();

                JungleClearMenu = Menu.AddSubMenu("JungleClear");
                JungleClear.Initialize();

                KSmenu = Menu.AddSubMenu("KS");
                KS.Initialize();

                FleeMenu = Menu.AddSubMenu("Flee");
                Flee.Initialize();

                MiscMenu = Menu.AddSubMenu("Misc");
                Misc.Initialize();

                DrawMenu = Menu.AddSubMenu("Draw");
                Draw.Initialize();

                DebugMenu = Menu.AddSubMenu("Debug Menu");
                Debug.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useR;
                private static readonly CheckBox _onlyQADC;
                private static readonly CheckBox _wInRange;
                private static readonly Slider _rCharges;
                private static readonly CheckBox _preventUnstealh;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static bool OnlyQADC
                {
                    get { return _onlyQADC.CurrentValue; }
                }

                public static bool OnlyWInRange
                {
                    get { return _wInRange.CurrentValue; }
                }

                public static int RCharges
                {
                    get { return _rCharges.CurrentValue; }
                }

                public static bool PrevenUnstealth
                {
                    get { return _preventUnstealh.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    ComboMenu.AddGroupLabel("Combo");
                    _useQ = ComboMenu.Add("comboQ", new CheckBox("Use Q ?"));
                    _useW = ComboMenu.Add("comboW", new CheckBox("Use W ?"));
                    _useR = ComboMenu.Add("comboR", new CheckBox("Use R to kite enemy ?", false));
                    //Settings
                    _onlyQADC = ComboMenu.Add("useqADC", new CheckBox("Use Q only on ADC during Combo", false));
                    _wInRange = ComboMenu.Add("wCombat", new CheckBox("Use W if enemy is in range only"));
                    _rCharges = ComboMenu.Add("rCharge", new Slider("Charges of R before using R", 2, 1, 3));
                    _preventUnstealh = ComboMenu.Add("checkCamo", new CheckBox("Prevents combo being activated while stealth in brush", false));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                static Harass()
                {
                    // Initialize the menu values
                    HarassMenu.AddGroupLabel("Harass");
                    _useQ = HarassMenu.Add("harassQ", new CheckBox("Use Q"));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _qMana;
                private static readonly CheckBox _AAturrets;
                private static readonly CheckBox _AAwards;
                private static readonly CheckBox _useR;
                private static readonly Slider _rMinions;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static int QMana
                {
                    get { return _qMana.CurrentValue; }
                }

                public static bool AAturrets
                {
                    get { return _AAturrets.CurrentValue; }
                }

                public static bool AAwards
                {
                    get { return _AAwards.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static int rMinions
                {
                    get { return _rMinions.CurrentValue; }
                }

                static LaneClear()
                {
                    LaneClearMenu.AddGroupLabel("LaneClear");
                    LaneClearMenu.AddGroupLabel("LaneClear Settings");
                    _useQ = LaneClearMenu.Add("qclear", new CheckBox("LaneClear with Q", false));
                    _qMana = LaneClearMenu.Add("qManaManager", new Slider("Q Mana Manager", 50));
                    _AAturrets = LaneClearMenu.Add("attackTurret", new CheckBox("Attack Turret"));
                    _AAwards = LaneClearMenu.Add("attackWard", new CheckBox("Attack Ward"));
                    _useR = LaneClearMenu.Add("rclear", new CheckBox("LaneClear with R"));
                    _rMinions = LaneClearMenu.Add("minionR", new Slider("Minion for R", 3, 1, 4));
                }

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _qMana;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static int QMana
                {
                    get { return _qMana.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                static JungleClear()
                {
                    JungleClearMenu.AddGroupLabel("JungleClear Settings");
                    _useQ = JungleClearMenu.Add("qclear", new CheckBox("JungleClear with Q"));
                    _useR = JungleClearMenu.Add("rclear", new CheckBox("JungleClear with R"));
                    _qMana = JungleClearMenu.Add("qManaManager", new Slider("Q Mana Manager", 25));
                }

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useR;
                private static readonly Slider _rCharge;

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static int RCharge
                {
                    get { return _rCharge.CurrentValue; }
                }

                static Flee()
                {
                    FleeMenu.AddGroupLabel("Flee Settings");
                    _useW = FleeMenu.Add("w", new CheckBox("Use W while Flee"));
                    _useR = FleeMenu.Add("r", new CheckBox("Use R while Flee"));
                    _rCharge = FleeMenu.Add("rCharge", new Slider("Charges of R before using R", 2, 1, 3));
                }

                public static void Initialize()
                {
                }
            }

            public static class KS
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }


                static KS()
                {
                    // KillSteal Menu
                    KSmenu.AddGroupLabel("KillSteal Settings");
                    _useQ = KSmenu.Add("KSQ", new CheckBox("KillSteal with Q"));
                    _useR = KSmenu.Add("KSR", new CheckBox("KillSteal with R"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {
                private static readonly CheckBox _intQ;
                private static readonly CheckBox _gapQ;
                //
                private static readonly CheckBox _autoQ;
                private static readonly CheckBox _autoW;
                private static readonly CheckBox _autoR;
                private static readonly Slider _rCharge;
                private static readonly KeyBind _autoPanicR;
                private static readonly CheckBox _customLocation;

                private static readonly CheckBox _checkAA;
                private static readonly Slider _checkAArange;

                public static bool InterruptQ
                {
                    get { return _intQ.CurrentValue; }
                }

                public static bool GapQ
                {
                    get { return _gapQ.CurrentValue; }
                }

                //

                public static bool AutoQ
                {
                    get { return _autoQ.CurrentValue; }
                }

                public static bool AutoW
                {
                    get { return _autoW.CurrentValue; }
                }

                public static bool AutoR
                {
                    get { return _autoR.CurrentValue; }
                }

                public static int RCharge
                {
                    get { return _rCharge.CurrentValue; }
                }

                public static bool AutoPanicR
                {
                    get { return _autoPanicR.CurrentValue; }
                }

                public static bool CustomLocation
                {
                    get { return _customLocation.CurrentValue; }
                }

                public static bool CheckAA
                {
                    get { return _checkAA.CurrentValue; }
                }

                public static int CheckAArange
                {
                    get { return _checkAArange.CurrentValue; }
                }

                static Misc()
                {
                    MiscMenu.AddGroupLabel("Interruptter and Gapcloser Setting");
                    _intQ = MiscMenu.Add("intq", new CheckBox("Interrupt with Q"));
                    _gapQ = MiscMenu.Add("gapR", new CheckBox("Gapclose with R"));

                    MiscMenu.AddGroupLabel("Misc Settings");
                    _autoQ = MiscMenu.Add("autoQ", new CheckBox("Automatic Q", false));
                    _autoW = MiscMenu.Add("autoW", new CheckBox("Automatic W", false));
                    _autoR = MiscMenu.Add("autoR", new CheckBox("Auto Place Shrooms in Important Places"));
                    _rCharge = MiscMenu.Add("rCharge", new Slider("Charges of R before using R in AutoShroom", 2, 1, 3));
                    _autoPanicR = MiscMenu.Add("autoRPanic", new KeyBind("Panic Key for Auto R", false, KeyBind.BindTypes.HoldActive, 84));
                    _customLocation = MiscMenu.Add("customLocation", new CheckBox("Use Custom Location for Auto Shroom (Requires Reload)"));
                    MiscMenu.AddSeparator();
                    _checkAA = MiscMenu.Add("checkAA", new CheckBox("Subtract Range for Q (checkAA)"));
                    _checkAArange = MiscMenu.Add("checkaaRange", new Slider("How many to subtract from Q Range (checkAA)", 100, 0, 180));
                }

                public static void Initialize()
                {
                }
            }

            public static class Debug
            {
                private static readonly CheckBox _debugDraw;
                private static readonly Slider _x;
                private static readonly Slider _y;
                private static readonly CheckBox _debugPos;

                public static bool DebugDraw
                {
                    get { return _debugDraw.CurrentValue; }
                }

                public static int X
                {
                    get { return _x.CurrentValue; }
                }

                public static int Y
                {
                    get { return _y.CurrentValue; }
                }

                public static bool DebugPos
                {
                    get { return _debugPos.CurrentValue; }
                }

                static Debug()
                {
                    DebugMenu.AddGroupLabel("Debug Settings");
                    _debugDraw = DebugMenu.Add("debugdraw", new CheckBox("Draw Coords", false));
                    _x = DebugMenu.Add("x", new Slider("Where to draw X", 500, 0, 1920));
                    _y = DebugMenu.Add("y", new Slider("Where to draw Y", 500, 0, 1080));
                    _debugPos = DebugMenu.Add("debugpos", new CheckBox("Draw Custom Shroom Locations Coordinates"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Draw
            {
                private static readonly CheckBox _drawautoR;
                private static readonly Slider _drawVision;
                private static readonly CheckBox _drawHealth;
                private static readonly CheckBox _drawQ;
                private static readonly CheckBox _drawW;
                private static readonly CheckBox _drawE;
                private static readonly CheckBox _drawR;

                private static readonly CheckBox _drawReady;

                public static bool DrawAutoR
                {
                    get { return _drawautoR.CurrentValue; }
                }

                public static int DrawVision
                {
                    get { return _drawVision.CurrentValue; }
                }

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
                    _drawautoR = DrawMenu.Add("drawautoR", new CheckBox("Draw Important Shroom Areas"));
                    _drawVision = DrawMenu.Add("DrawVision", new Slider("Shroom Vision", 1500, 2500, 1000));
                    _drawReady = DrawMenu.Add("drawReady", new CheckBox("Draw Only If The Spells Are Ready.", false));
                    DrawMenu.AddSeparator();
                    DrawMenu.AddLabel("Reload is required to aply the changes made in the damage indicator");
                    _drawHealth = DrawMenu.Add("drawHealth", new CheckBox("Draw Damage in HealthBar"));
                    DrawMenu.AddColorItem("colorHealth");
                    DrawMenu.AddSeparator();
                    //Q
                    _drawQ = DrawMenu.Add("drawQ", new CheckBox("Draw Q"));
                    DrawMenu.AddColorItem("colorQ");
                    DrawMenu.AddWidthItem("widthQ");
                    //W
                    _drawW = DrawMenu.Add("drawW", new CheckBox("Draw W"));
                    DrawMenu.AddColorItem("colorW");
                    DrawMenu.AddWidthItem("widthW");
                    //E
                    _drawE = DrawMenu.Add("drawE", new CheckBox("Draw E"));
                    DrawMenu.AddColorItem("colorE");
                    DrawMenu.AddWidthItem("widthE");
                    //R
                    _drawR = DrawMenu.Add("drawR", new CheckBox("Draw R"));
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