using System;
using EloBuddy;
using EloBuddy.SDK.Rendering;

using Settings = KickassSeries.Champions.Jayce.Config.Modes.Draw;

namespace KickassSeries.Champions.Jayce
{
     class Jayce
    {
        public static void Initialize()
        {
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();
            DamageIndicator.Initialize(SpellDamage.GetTotalDamage);
            EventsManager.Initialize();

            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            if (Settings.DrawReady ? SpellManager.Qh.IsReady() : Settings.DrawQ)
            {
                new Circle { Color = Settings.colorQ, BorderWidth = Settings._widthQ, Radius = SpellManager.Qh.Range }.Draw(Player.Instance.Position);
            }

            if (Settings.DrawReady ? SpellManager.Wh.IsReady() : Settings.DrawW)
            {
                new Circle { Color = Settings.colorW, BorderWidth = Settings._widthW, Radius = SpellManager.Wh.Range }.Draw(Player.Instance.Position);
            }

            if (Settings.DrawReady ? SpellManager.Eh.IsReady() : Settings.DrawE)
            {
                new Circle { Color = Settings.colorE, BorderWidth = Settings._widthE, Radius = SpellManager.Eh.Range }.Draw(Player.Instance.Position);
            }

            if (Settings.DrawR && Settings.DrawReady ? SpellManager.R.IsReady() : Settings.DrawR)
            {
                new Circle { Color = Settings.colorR, BorderWidth = Settings._widthR, Radius = SpellManager.R.Range }.Draw(Player.Instance.Position);
            }
        }
    }
}
