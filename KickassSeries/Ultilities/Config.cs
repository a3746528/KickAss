using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

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
            private static readonly Menu TeteMenu;

            static Types()
            {
                TeteMenu = Menu.AddSubMenu("Offensive Items");
                Teste.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Teste
            {
                private static readonly CheckBox teste;

                public static bool Teste1
                {
                    get { return teste.CurrentValue; }
                }

                static Teste()
                {
                    TeteMenu.AddGroupLabel("Teste");
                    teste = TeteMenu.Add("test1", new CheckBox("Teste"));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}


