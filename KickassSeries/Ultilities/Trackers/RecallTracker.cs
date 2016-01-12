using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using KickassSeries.Properties;
using SharpDX;
using Color = System.Drawing.Color;

using Settings = KickassSeries.Ultilities.Config.Types.RecallTracker;

namespace KickassSeries.Ultilities.Trackers
{
    internal class RecallTracker
    {
        private static Sprite TopSprite { get; set; }
        private static Sprite BottomSprite { get; set; }
        private static Sprite BackSprite { get; set; }
        private static Text Text { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private static Text TextTwo { get; set; }

        public static List<Recall> Recalls = new List<Recall>();

        public static readonly TextureLoader TextureLoader = new TextureLoader();

        public static void Initialize()
        {
            TextureLoader.Load("top", Resources.RTTopHUD);
            TextureLoader.Load("bottom", Resources.RTBottomHUD);
            TextureLoader.Load("back", Resources.RTBack);

            TopSprite = new Sprite(() => TextureLoader["top"]);
            BottomSprite = new Sprite(() => TextureLoader["bottom"]);
            BackSprite = new Sprite(() => TextureLoader["back"]);

            Text = new Text("", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)) {Color = Color.AntiqueWhite};
            TextTwo = new Text("", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold))
            {
                Color = Color.AntiqueWhite
            };

            Teleport.OnTeleport += Teleport_OnTeleport;
            Drawing.OnEndScene += Drawing_OnEndScene;
        }

        private static void Teleport_OnTeleport(Obj_AI_Base sender, Teleport.TeleportEventArgs args)
        {
            if (Settings.TurnOff) return;

            if (args.Type != TeleportType.Recall || !(sender is AIHeroClient)) return;

            switch (args.Status)
            {
                case TeleportStatus.Abort:
                    foreach (var source in Recalls.Where(a => a.Unit == sender))
                    {
                        source.Abort();
                    }
                    break;
                case TeleportStatus.Start:
                    var recall = Recalls.FirstOrDefault(a => a.Unit == sender);
                    if (recall != null)
                    {
                        Recalls.Remove(recall);
                    }
                    Recalls.Add(new Recall((AIHeroClient) sender, Environment.TickCount,
                        Environment.TickCount + args.Duration, args.Duration));
                    break;
            }
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
            if(Settings.TurnOff) return;
            /*
            var x = (int) (Drawing.Width*0.846875);
            var y = (int) (Drawing.Height*0.5555555555555556);
            */
            var x = (int)(Drawing.Width * 0.846875);
            var y = (int)(Drawing.Height * 0.5 + Settings.XPos);

            var bonus = 0;
            foreach (var recall in Recalls.ToList())
            {
                TopSprite.Draw(new Vector2(x + 1, y));
                BackSprite.Draw(new Vector2(x, y + 18 + bonus));
                Text.Draw(Truncate(recall.Unit.ChampionName, 10), Color.White, x + 15, y + bonus + 27);
                Text.Draw(recall.PercentComplete() + "%", Color.White, new Vector2(x + 258, y + bonus + 26));

                Line.DrawLine(Color.White, 10, new Vector2(x + 80, y + bonus + 33), new Vector2(x + 250, y + bonus + 33));

                Line.DrawLine(recall.IsAborted ? Color.DodgerBlue : BarColor(recall.PercentComplete()), 10,
                    new Vector2(x + 80, y + bonus + 33),
                    new Vector2(x + 80 + (170*(recall.PercentComplete()/100)), y + bonus + 33));
                bonus += 31;

                if (recall.ExpireTime < Environment.TickCount && Recalls.Contains(recall))
                {
                    Recalls.Remove(recall);
                }
                BottomSprite.Draw(new Vector2(x + 1, y + bonus + 18));
            }
        }

        private static Color BarColor(float percent)
        {
            if (percent > 80)
            {
                return Color.Red;
            }
            if (percent > 60)
            {
                return Color.OrangeRed;
            }

            if (percent > 40)
            {
                return Color.Orange;
            }
            if (percent > 20)
            {
                return Color.YellowGreen;
            }
            if (percent > 1)
            {
                return Color.LimeGreen;
            }
            return Color.White;
        }

        public class Recall
        {
            public Recall(AIHeroClient unit, int recallStart, int recallEnd, int duration)
            {
                Unit = unit;
                RecallStart = recallStart;
                Duration = duration;
                RecallEnd = recallEnd;
                ExpireTime = RecallEnd + 2000;
            }

            public int RecallEnd;
            public int Duration;
            public int RecallStart;
            public int ExpireTime;
            public int CancelT;

            public AIHeroClient Unit;

            public bool IsAborted;

            public void Abort()
            {
                CancelT = Environment.TickCount;
                ExpireTime = Environment.TickCount + 2000;
                IsAborted = true;
            }

            private float Elapsed
            {
                get { return (CancelT > 0 ? CancelT : Environment.TickCount) - RecallStart; }
            }

            public float PercentComplete()
            {
                return (float) Math.Round(Elapsed/Duration*100) > 100 ? 100 : (float) Math.Round(Elapsed/Duration*100);
            }
        }

        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
