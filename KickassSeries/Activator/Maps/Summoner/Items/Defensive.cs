using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KickassSeries.Activator.Maps.Summoner.DMGHandler;

using Misc = KickassSeries.Activator.Maps.Summoner.Config.Types.Settings;
using Settings = KickassSeries.Activator.Maps.Summoner.Config.Types.DeffensiveItems;

namespace KickassSeries.Activator.Maps.Summoner.Items
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Defensive : Ids
    {
        public static void Execute()
        {
            if (Player.Instance.IsInShopRange() || Player.Instance.CountAlliesInRange(Misc.RangeEnemy) < Misc.EnemyCount ||
                Activator.lastUsed >= Environment.TickCount) return;
            #region Self

            if (Zhonyas.IsReady() && Zhonyas.IsOwned() && Player.Instance.InDanger(Settings.ZhonyasMyHp) && Settings.Zhonyas)
            {
                Zhonyas.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Seraph.IsReady() && Seraph.IsOwned() && Player.Instance.InDanger(Settings.MYHPArchengelStaff) && Settings.UseArchengelStaff)
            {
                Seraph.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (FaceOfTheMountain.IsReady() && FaceOfTheMountain.IsOwned() && Player.Instance.InDanger(30))
            {
                FaceOfTheMountain.Cast(Player.Instance);
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Talisman.IsReady() && Player.Instance.CountAlliesInRange(450) >= 2 && Talisman.IsOwned() &&
                Player.Instance.InDanger(30))
            {
                Talisman.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Mikael.IsReady() && Player.Instance.HasCCs() && Mikael.IsOwned() && Player.Instance.InDanger(30))
            {
                Mikael.Cast(Player.Instance);
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Solari.IsReady() && Solari.IsOwned() && Player.Instance.InDanger(30))
            {
                Solari.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Ohm.IsReady() && Ohm.IsOwned() && Player.Instance.InDanger(30))
            {
                var turret = EntityManager.Turrets.Enemies.FirstOrDefault(t => t.IsAttackingPlayer);
                if (turret != null)
                {
                    Ohm.Cast(turret);
                    Activator.lastUsed = Environment.TickCount + 1500;
                }
            }

            if (Randuin.IsReady() && Player.Instance.CountEnemiesInRange(Randuin.Range) >= 2 && Randuin.IsOwned() &&
                Player.Instance.InDanger(30))
            {
                Randuin.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            //CC

            if (!Player.Instance.HasCCs()) return;

            if (!Player.Instance.HasCC()) return;

            if (DerbishBlade.IsReady() && DerbishBlade.IsOwned() && Settings.DerbishBlade)
            {
                DerbishBlade.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Mercurial.IsReady() && Mercurial.IsOwned() && Settings.Mercurial)
            {
                Mercurial.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (QuickSilver.IsReady() && QuickSilver.IsOwned() && Settings.QuickSilver)
            {
                QuickSilver.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            #endregion Self
        }

        
    }
}


