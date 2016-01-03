using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KickassSeries.Activator.DMGHandler;

namespace KickassSeries.Activator.Items
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Defensive : Ids
    {
        public static void Execute()
        {
            var target =
                EntityManager.Heroes.Enemies.FirstOrDefault(e => !e.IsDead && e.IsInRange(Player.Instance, 1500));

            if (Player.Instance.IsInShopRange() || target == null)
                return;

            #region Self

            if (Zhonyas.IsReady() && Zhonyas.IsOwned() && Player.Instance.InDanger())
            {
                Zhonyas.Cast();
            }

            if (ArchengelStaff.IsReady() && ArchengelStaff.IsOwned() && Player.Instance.InDanger())
            {
                ArchengelStaff.Cast();
            }

            if (FaceOfTheMountain.IsReady() && FaceOfTheMountain.IsOwned() && Player.Instance.InDanger())
            {
                FaceOfTheMountain.Cast(Player.Instance);
            }

            if (Talisman.IsReady() && Player.Instance.CountAlliesInRange(450) >= 2 && Talisman.IsOwned() && Player.Instance.InDanger())
            {
                Talisman.Cast();
            }

            if (Mikael.IsReady() && Player.Instance.HasCC() && Mikael.IsOwned() && Player.Instance.InDanger())
            {
                Mikael.Cast(Player.Instance);
            }

            if (Solari.IsReady() && Solari.IsOwned() && Player.Instance.InDanger())
            {
                Solari.Cast();
            }

            if (Ohm.IsReady() && Ohm.IsOwned() && Player.Instance.InDanger())
            {
                var turret = EntityManager.Turrets.Enemies.FirstOrDefault(t => t.IsAttackingPlayer);
                if (turret != null)
                {
                    Ohm.Cast(turret);
                }
            }

            if (Randuin.IsReady() && Player.Instance.CountEnemiesInRange(Randuin.Range) >= 2 && Randuin.IsOwned() && Player.Instance.InDanger())
            {
                Randuin.Cast();
            }

            //CC

            if (!Player.Instance.HasCC()) return;

            if (DerbishBlade.IsReady() && DerbishBlade.IsOwned())
            {
                DerbishBlade.Cast();
            }

            if (Mercurial.IsReady() && Mercurial.IsOwned())
            {
                Mercurial.Cast();
            }

            if (QuickSilver.IsReady() && QuickSilver.IsOwned())
            {
                QuickSilver.Cast();
            }

            #endregion Self
        }
    }
}


