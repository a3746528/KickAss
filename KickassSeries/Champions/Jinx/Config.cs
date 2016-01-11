using System;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using KickassSeries.MenuSettings;
using Color = System.Drawing.Color;

// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace KickassSeries.Champions.Jinx
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
            private static readonly Menu ComboMenu, HarassMenu, LastHitMenu, LaneClearMenu, JungleClearMenu, FleeMenu, KillStealMenu,MiscMenu, DrawMenu;
            public static readonly Menu JungleStealMenu;

            static Modes()
            {
                ComboMenu = Menu.AddSubMenu("Combo");
                Combo.Initialize();

                HarassMenu  = Menu.AddSubMenu("Harass");
                Harass.Initialize();

                LastHitMenu = Menu.AddSubMenu("LastHit");
                LastHit.Initialize();

                LaneClearMenu = Menu.AddSubMenu("LaneClear");
                LaneClear.Initialize();

                JungleClearMenu = Menu.AddSubMenu("JungleClear");
                JungleClear.Initialize();

                JungleStealMenu = Menu.AddSubMenu("JungleSteal");
                JungleSteal.Initialize();

                KillStealMenu = Menu.AddSubMenu("KillSteal");
                KillSteal.Initialize();

                FleeMenu = Menu.AddSubMenu("Flee");
                Flee.Initialize();


                MiscMenu = Menu.AddSubMenu("Misc");
                Misc.Initialize();

                DrawMenu = Menu.AddSubMenu("Draw");
                Draw.Initialize();
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
                private static readonly Slider _manaQ;
                private static readonly Slider _manaW;
                private static readonly Slider _manaE;
                private static readonly Slider _manaR;
                private static readonly Slider _qCount;
                private static readonly Slider _rCount;
                private static readonly Slider _wPredSliderCombo;
                private static readonly Slider _ePredSliderCombo;
                private static readonly Slider _rPredSliderCombo;
                private static readonly Slider _wRangeCombo;
                private static readonly Slider _eRangeCombo;
                private static readonly Slider _eRangeCombo2;
                private static readonly Slider _rRangeCombo;

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

                public static int ManaQ
                {
                    get { return _manaQ.CurrentValue; }
                }

                public static int ManaW
                {
                    get { return _manaW.CurrentValue; }
                }

                public static int ManaE
                {
                    get { return _manaE.CurrentValue; }
                }

                public static int ManaR
                {
                    get { return _manaR.CurrentValue; }
                }

                public static int QCount
                {
                    get { return _qCount.CurrentValue; }
                }

                public static int RCount
                {
                    get { return _rCount.CurrentValue; }
                }

                public static int WPrediction
                {
                    get { return _wPredSliderCombo.CurrentValue; }
                }

                public static int EPrediction
                {
                    get { return _ePredSliderCombo.CurrentValue; }
                }

                public static int RPrediction
                {
                    get { return _rPredSliderCombo.CurrentValue; }
                }

                public static int WRange
                {
                    get { return _wRangeCombo.CurrentValue; }
                }

                public static int ERange
                {
                    get { return _eRangeCombo.CurrentValue; }
                }

                public static int ERange2
                {
                    get { return _eRangeCombo2.CurrentValue; }
                }

                public static int RRange
                {
                    get { return _rRangeCombo.CurrentValue; }
                }

                static Combo()
                {
                    ComboMenu.AddLabel("Combo Settings");
                    _useQ = ComboMenu.Add("useQ", new CheckBox("Use Q"));
                    _useW = ComboMenu.Add("useW", new CheckBox("Use W"));
                    _useE = ComboMenu.Add("useE", new CheckBox("Use E"));
                    _useR = ComboMenu.Add("useR", new CheckBox("Use R"));
                    ComboMenu.AddLabel("ManaManager");
                    _manaQ = ComboMenu.Add("manaQ", new Slider("ManaManager for Q", 25));
                    _manaW = ComboMenu.Add("manaW", new Slider("ManaManager for W", 25));
                    _manaE = ComboMenu.Add("manaE", new Slider("ManaManager for E", 25));
                    _manaR = ComboMenu.Add("manaR", new Slider("ManaManager for R", 25));
                    ComboMenu.AddLabel("Hit on Champion is Prioritized first over Minion");
                    _qCount = ComboMenu.Add("qCountC", new Slider("Use Q if Hit x Champion(s)", 3, 1, 5));
                    _rCount = ComboMenu.Add("rCountC", new Slider("Use R if Hit x Champion(s)", 5, 1, 5));
                    ComboMenu.AddLabel("Prediction Settings");
                    _wPredSliderCombo = ComboMenu.Add("wSlider", new Slider("Use W if HitChance % is x", 80));
                    _ePredSliderCombo = ComboMenu.Add("eSlider", new Slider("Use E if HitChance % is x", 80));
                    _rPredSliderCombo = ComboMenu.Add("rSlider", new Slider("Use R if HitChance % is x", 80));
                    ComboMenu.AddLabel("Extra Settings");
                    _wRangeCombo = ComboMenu.Add("wRange2", new Slider("Don't Use W if Player Range from Target is x", 150, 0, 1450));
                    _eRangeCombo = ComboMenu.Add("eRange", new Slider("Only Use E if Player Range from Target is more than x", 150, 0, 900));
                    _eRangeCombo2 = ComboMenu.Add("eRange2", new Slider("Max E Range", 900, 0, 900));
                    _rRangeCombo = ComboMenu.Add("rRange2", new Slider("Max R Range", 3000, 0, 3000));
            }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly Slider _manaQ;
                private static readonly Slider _manaW;
                private static readonly Slider _minChampQ;
                private static readonly Slider _minMinionQ;
                private static readonly Slider _percW;
                private static readonly Slider _wRange;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static int ManaQ
                {
                    get { return _manaQ.CurrentValue; }
                }

                public static int ManaW
                {
                    get { return _manaW.CurrentValue; }
                }

                public static int MinChampQ
                {
                    get { return _minChampQ.CurrentValue; }
                }

                public static int MinMinionQ
                {
                    get { return _minMinionQ.CurrentValue; }
                }

                public static int PercentageW
                {
                    get { return _percW.CurrentValue; }
                }

                public static int MinWRange
                {
                    get { return _wRange.CurrentValue; }
                }

                static Harass()
                {
                    HarassMenu.AddLabel("Harass Settings");
                    _useQ = HarassMenu.Add("useQ", new CheckBox("Use Q"));
                    _useW = HarassMenu.Add("useW", new CheckBox("Use W"));
                    HarassMenu.AddLabel("ManaManager");
                    _manaQ = HarassMenu.Add("manaQ", new Slider("ManaManager for Q", 15));
                    _manaW = HarassMenu.Add("manaW", new Slider("ManaManager for W", 35));
                    HarassMenu.AddLabel("Hit on Champion is Prioritized first over Minion");
                    _minChampQ = HarassMenu.Add("qCountC", new Slider("Use Q if Hit x Champion(s)", 3, 1, 5));
                    _minMinionQ = HarassMenu.Add("qCountM", new Slider("Use Q if Hit x Minion(s)", 3, 1, 7));
                    HarassMenu.AddLabel("Prediction Settings");
                    _percW = HarassMenu.Add("wSlider", new Slider("Use W if HitChance % is x", 95));
                    HarassMenu.AddLabel("Extra Settings");
                    _wRange = HarassMenu.Add("wRange2", new Slider("Don't Use W if Player Range from Target is x", 0, 0, 1450));
                }

                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _minMinionsQ;
                private static readonly Slider _manaQ;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static int MinMinionsQ
                {
                    get { return _minMinionsQ.CurrentValue; }
                }

                public static int ManaQ
                {
                    get { return _manaQ.CurrentValue; }
                }

                static LastHit()
                {
                    // Initialize the menu values
                    LastHitMenu.AddGroupLabel("LastHit Settings");
                    _useQ = LastHitMenu.Add("lastQ", new CheckBox("Use Q"));
                    _minMinionsQ = LastHitMenu.Add("qCountM", new Slider("Use Q if Hit x Minions", 3, 1, 7));
                    LastHitMenu.AddLabel("ManaManager");
                    _manaQ = LastHitMenu.Add("manaQ", new Slider("ManaManager for Q", 25));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useQOut;
                private static readonly Slider _minMinionQ;
                private static readonly Slider _manaLane;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseQOutOfRange
                {
                    get { return _useQOut.CurrentValue; }
                }

                public static int MinMinionLane
                {
                    get { return _minMinionQ.CurrentValue; }
                }

                public static int ManaLane
                {
                    get { return _manaLane.CurrentValue; }
                }

                static LaneClear()
                {
                    LaneClearMenu.AddLabel("Lane Clear Settings");
                    _useQ = LaneClearMenu.Add("useQ", new CheckBox("Use Q"));
                    _useQOut = LaneClearMenu.Add("lastHit", new CheckBox("Last Hit Minion Out of Range", false));
                    _manaLane = LaneClearMenu.Add("manaQ", new Slider("ManaManager for Q", 25));
                    _minMinionQ = LaneClearMenu.Add("qCountM", new Slider("Use Q if Hit x Minion(s)", 3, 1, 7));
                }

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly Slider _manaQ;
                private static readonly Slider _manaW;
                private static readonly Slider _WPredPercentage;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static int ManaQ
                {
                    get { return _manaQ.CurrentValue; }
                }

                public static int ManaW
                {
                    get { return _manaW.CurrentValue; }
                }

                public static int WPredPercentage
                {
                    get { return _WPredPercentage.CurrentValue; }
                }

                static JungleClear()
                {
                    JungleClearMenu.AddLabel("Jungle Clear Settings");
                    _useQ = JungleClearMenu.Add("useQ", new CheckBox("Use Q"));
                    _useW = JungleClearMenu.Add("useW", new CheckBox("Use W", false));
                    JungleClearMenu.AddLabel("ManaManager");
                    _manaQ = JungleClearMenu.Add("manaQ", new Slider("ManaManager for Q", 25));
                    _manaW = JungleClearMenu.Add("manaW", new Slider("ManaManager for W", 25));
                    JungleClearMenu.AddLabel("Misc Settings");
                    _WPredPercentage = JungleClearMenu.Add("wSlider", new Slider("Use W if HitChance % is x", 85));
                }

                public static void Initialize()
                {
                }
            }

            public static class JungleSteal
            {
                private static readonly CheckBox _toggleJungleSteal;
                private static readonly Slider _manaR;
                private static readonly Slider _rangeR;

                public static bool JungleStealToggle
                {
                    get { return _toggleJungleSteal.CurrentValue; }
                }

                public static int ManaR
                {
                    get { return _manaR.CurrentValue; }
                }

                public static int RangeR
                {
                    get { return _rangeR.CurrentValue; }
                }

                static JungleSteal()
                {
                    // Initialize the menu values
                    JungleStealMenu.AddLabel("Jungle Steal Settings");
                    _toggleJungleSteal = JungleStealMenu.Add("toggle", new CheckBox("Use Jungle Steal", false));
                    _manaR = JungleStealMenu.Add("manaR", new Slider("ManaManager for R", 25));
                    _rangeR = JungleStealMenu.Add("rRange", new Slider("Range from mob before using R", 3000, 0, 3000));

                    switch (Game.MapId)
                    {
                        case GameMapId.SummonersRift:
                            JungleStealMenu.AddLabel("Epics");
                            JungleStealMenu.Add("SRU_Baronjinx", new CheckBox("Baron"));
                            JungleStealMenu.Add("SRU_Dragonjinx", new CheckBox("Dragon"));
                            JungleStealMenu.AddLabel("Buffs");
                            JungleStealMenu.Add("SRU_Bluejinx", new CheckBox("Blue", false));
                            JungleStealMenu.Add("SRU_Redjinx", new CheckBox("Red", false));
                            JungleStealMenu.AddLabel("Small Camps");
                            JungleStealMenu.Add("SRU_Grompjinx", new CheckBox("Gromp", false));
                            JungleStealMenu.Add("SRU_Murkwolfjinx", new CheckBox("Murkwolf", false));
                            JungleStealMenu.Add("SRU_Krugjinx", new CheckBox("Krug", false));
                            JungleStealMenu.Add("SRU_Razorbeakjinx", new CheckBox("Razerbeak", false));
                            JungleStealMenu.Add("Sru_Crabjinx", new CheckBox("Skuttles", false));
                            break;
                        case GameMapId.TwistedTreeline:
                            JungleStealMenu.AddLabel("Epics");
                            JungleStealMenu.Add("TT_Spiderboss8.1jinx", new CheckBox("Vilemaw"));
                            JungleStealMenu.AddLabel("Camps");
                            JungleStealMenu.Add("TT_NWraith1.1jinx", new CheckBox("Wraith", false));
                            JungleStealMenu.Add("TT_NWraith4.1jinx", new CheckBox("Wraith", false));
                            JungleStealMenu.Add("TT_NGolem2.1jinx", new CheckBox("Golem", false));
                            JungleStealMenu.Add("TT_NGolem5.1jinx", new CheckBox("Golem", false));
                            JungleStealMenu.Add("TT_NWolf3.1jinx", new CheckBox("Wolf", false));
                            JungleStealMenu.Add("TT_NWolf6.1jinx", new CheckBox("Wolf", false));
                            break;
                    }
                }

                public static void Initialize()
                {
                }
            }

            public static class KillSteal
            {
                private static readonly CheckBox _toggleKillSteal;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useR;
                private static readonly Slider _WManaSlider;
                private static readonly Slider _RManaSlider;
                private static readonly Slider _WpredSlider;
                private static readonly Slider _RpreSlider;
                private static readonly Slider _RMaxRange;

                public static bool ToggleKillSteal
                {
                    get { return _toggleKillSteal.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static int WMana
                {
                    get { return _WManaSlider.CurrentValue; }
                }

                public static int RMana
                {
                    get { return _RManaSlider.CurrentValue; }
                }

                public static int WPredSlider
                {
                    get { return _WpredSlider.CurrentValue; }
                }

                public static int RPredSlider
                {
                    get { return _RpreSlider.CurrentValue; }
                }

                public static int RMaxRange
                {
                    get { return _RMaxRange.CurrentValue; }
                }

                static KillSteal()
                { 
                    KillStealMenu.AddGroupLabel("KillSteal Settings");
                    _toggleKillSteal = KillStealMenu.Add("toggle", new CheckBox("Use Kill Steal"));
                    _useW = KillStealMenu.Add("useW", new CheckBox("Use W to KS"));
                    _useR = KillStealMenu.Add("useR", new CheckBox("Use R to KS"));
                    KillStealMenu.AddLabel("ManaManager");
                    _WManaSlider = KillStealMenu.Add("manaW", new Slider("ManaManager for W", 25));
                    _RManaSlider = KillStealMenu.Add("manaR", new Slider("ManaManager for R", 25));
                    KillStealMenu.AddLabel("Prediction Settings");
                    _WpredSlider = KillStealMenu.Add("wSlider", new Slider("Use W if HitChance % is x", 80));
                    _RpreSlider = KillStealMenu.Add("rSlider", new Slider("Use R if HitChance % is x", 80));
                    KillStealMenu.AddLabel("Spell Settings");
                    _RMaxRange = KillStealMenu.Add("rRange", new Slider("Max Distance for R", 3000, 0, 3000));
                }

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _WpredSlider;
                private static readonly Slider _EpreSlider;

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int WPredPercentage
                {
                    get { return _WpredSlider.CurrentValue; }
                }

                public static int EPredPercentage
                {
                    get { return _EpreSlider.CurrentValue; }
                }

                static Flee()
                {
                    FleeMenu.AddLabel("Flee Settings");
                    _useW = FleeMenu.Add("useW", new CheckBox("Use W while Fleeing"));
                    _useE = FleeMenu.Add("useE", new CheckBox("Use E while Fleeing"));
                    _WpredSlider = FleeMenu.Add("wSlider", new Slider("Use W if HitChance is X", 75));
                    _EpreSlider = FleeMenu.Add("eSlider", new Slider("Use E if HitChance is X", 75));
                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {
                private static readonly CheckBox _interruptE;
                private static readonly Slider _interruptManaE;
                private static readonly CheckBox _gapcloserE;
                private static readonly Slider _gapcloserEMana;
                private static readonly CheckBox _autoW;
                private static readonly CheckBox _autoE;
                private static readonly CheckBox _wAArange;
                private static readonly Slider _rRange;
                private static readonly CheckBox _stunW;
                private static readonly CheckBox _charmW;
                private static readonly CheckBox _fearW;
                private static readonly CheckBox _snareW;
                private static readonly CheckBox _tauntW;
                private static readonly Slider _wSlider;
                private static readonly Slider _eSlider;
                private static readonly CheckBox _soundR;

                public static bool InterruptE
                {
                    get { return _interruptE.CurrentValue; }
                }

                public static int InterruptEMana
                {
                    get { return _interruptManaE.CurrentValue; }
                }

                public static bool GapCloserE
                {
                    get { return _gapcloserE.CurrentValue; }
                }

                public static int GapCloserEMana
                {
                    get { return _gapcloserEMana.CurrentValue; }
                }

                public static bool AutoW
                {
                    get { return _autoW.CurrentValue; }
                }

                public static bool AutoE
                {
                    get { return _autoE.CurrentValue; }
                }

                public static bool WAARange
                {
                    get { return _wAArange.CurrentValue; }
                }

                public static int RRange
                {
                    get { return _rRange.CurrentValue; }
                }

                public static bool StunW
                {
                    get { return _stunW.CurrentValue; }
                }

                public static bool CharmW
                {
                    get { return _charmW.CurrentValue; }
                }

                public static bool FearW
                {
                    get { return _fearW.CurrentValue; }
                }

                public static bool SnareW
                {
                    get { return _snareW.CurrentValue; }
                }

                public static bool TauntW
                {
                    get { return _tauntW.CurrentValue; }
                }

                public static int WPredSlider
                {
                    get { return _wSlider.CurrentValue; }
                }

                public static int EPredSlider
                {
                    get { return _eSlider.CurrentValue; }
                }

                public static bool PlaySoundR
                {
                    get { return _soundR.CurrentValue; }
                }

                static Misc()
                {
                    MiscMenu.AddLabel("Interrupter");
                    _interruptE = MiscMenu.Add("interruptE", new CheckBox("Use E to Interrupt"));
                    _interruptManaE = MiscMenu.Add("interruptmanaE", new Slider("Mana % before using E to Interrupt", 25));
                    MiscMenu.AddLabel("Gapcloser");
                    _gapcloserE = MiscMenu.Add("gapcloserE", new CheckBox("Use E to Gapcloser"));
                    _gapcloserEMana = MiscMenu.Add("gapclosermanaE", new Slider("Mana % before using E to Gapclose", 25));
                    MiscMenu.AddLabel("Spell Settings");
                    _autoW = MiscMenu.Add("lastQ", new CheckBox("Automatically uses W in certain situations"));
                    _autoE = MiscMenu.Add("lastW", new CheckBox("Automatically uses E in certain situations"));
                    _wAArange = MiscMenu.Add("lastE", new CheckBox("Use W only if target is in AA range", false));
                    _rRange = MiscMenu.Add("rRange", new Slider("Don't Use R if Player Range from target is X", 345, 0, 3000));
                    MiscMenu.AddLabel("Auto W Settings (You must have Auto W on)");
                    _stunW = MiscMenu.Add("stunW", new CheckBox("Use W on Stunned Enemy"));
                    _charmW = MiscMenu.Add("charmW", new CheckBox("Use W on Charmed Enemy", false));
                    _tauntW = MiscMenu.Add("tauntW", new CheckBox("Use W on Taunted Enemy"));
                    _fearW = MiscMenu.Add("fearW", new CheckBox("Use W on Feared Enemy"));
                    _snareW = MiscMenu.Add("snareW", new CheckBox("Use W on Snared Enemy"));
                    MiscMenu.AddLabel("Prediction Settings");
                    _wSlider = MiscMenu.Add("wSlider", new Slider("Use W if HitChance % is x"));
                    _eSlider = MiscMenu.Add("eSlider", new Slider("Use E if HitChance % is x"));
                    MiscMenu.AddLabel("Allah Akbar");
                    _soundR = MiscMenu.Add("allahAkbarT", new CheckBox("Play Allah Akbar after casting R"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Draw
            {
                private static readonly CheckBox _drawWPred;
                private static readonly CheckBox _drawRPred;
                //
                private static readonly CheckBox _drawHealth;
                private static readonly CheckBox _drawQ;
                private static readonly CheckBox _drawW;
                private static readonly CheckBox _drawE;
                private static readonly CheckBox _drawR;

                private static readonly CheckBox _drawReady;

                public static bool DrawWPred
                {
                    get { return _drawWPred.CurrentValue; }
                }

                public static bool DrawRPred
                {
                    get { return _drawRPred.CurrentValue; }
                }

                //

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
                    _drawWPred = DrawMenu.Add("predW", new CheckBox("Draw W Prediction"));
                    _drawRPred = DrawMenu.Add("predR", new CheckBox("Draw R Prediction (In consideration of Range before R)", false));
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