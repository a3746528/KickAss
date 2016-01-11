using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;

using Settings = KickassSeries.Champions.Jinx.Config.Modes.Draw;
using Misc = KickassSeries.Champions.Jinx.Config.Modes.Misc;

namespace KickassSeries.Champions.Jinx
{
    internal class Jinx
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
             if (Settings.DrawReady ? SpellManager.Q.IsReady() : Settings.DrawQ)
             {
                 new Circle {Color = Settings.colorQ, BorderWidth = Settings._widthQ, Radius = Player.Instance.GetAutoAttackRange()}
                     .Draw(Player.Instance.Position);
             }

             if (Settings.DrawReady ? SpellManager.W.IsReady() : Settings.DrawW)
             {
                 new Circle {Color = Settings.colorW, BorderWidth = Settings._widthW, Radius = SpellManager.W.Range}
                     .Draw(Player.Instance.Position);
             }

             if (Settings.DrawReady ? SpellManager.E.IsReady() : Settings.DrawE)
             {
                 new Circle {Color = Settings.colorE, BorderWidth = Settings._widthE, Radius = SpellManager.E.Range}
                     .Draw(Player.Instance.Position);
             }

             if (Settings.DrawReady ? SpellManager.R.IsReady() : Settings.DrawR)
             {
                 new Circle {Color = Settings.colorR, BorderWidth = Settings._widthR, Radius = Misc.RRange}
                     .Draw(Player.Instance.Position);
             }

             if (Settings.DrawWPred)
             {
                 var enemy =
                     EntityManager.Heroes.Enemies.Where(t => t.IsValidTarget() && SpellManager.W.IsInRange(t))
                         .OrderBy(t => t.Distance(Player.Instance))
                         .FirstOrDefault();
                 if (enemy == null)
                 {
                     return;
                 }
                 var wPred = SpellManager.W.GetPrediction(enemy).CastPosition;
                 Essentials.DrawLineRectangle(wPred.To2D(), Player.Instance.Position.To2D(), SpellManager.W.Width, 1,
                     SpellManager.W.IsReady() ? System.Drawing.Color.YellowGreen : System.Drawing.Color.Red);
             }

             if (Settings.DrawRPred)
             {
                 var enemy =
                     EntityManager.Heroes.Enemies.Where(
                         t =>
                             t.IsValidTarget()
                             && t.Distance(Player.Instance) >= Misc.RRange &&
                             t.Distance(Player.Instance) <= SpellManager.R.Range)
                         .OrderBy(t => t.Distance(Player.Instance))
                         .FirstOrDefault();
                 if (enemy == null)
                 {
                     return;
                 }
                 var rPred = SpellManager.R.GetPrediction(enemy).CastPosition;
                 Essentials.DrawLineRectangle(rPred.To2D(), Player.Instance.Position.To2D(), SpellManager.R.Width, 1,
                     SpellManager.R.IsReady() ? System.Drawing.Color.YellowGreen : System.Drawing.Color.Red);
             }
         }
    }
}
