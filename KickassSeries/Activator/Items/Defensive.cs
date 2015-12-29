using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

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

            if (Zhonyas.IsReady() && Zhonyas.IsOwned())
            {
                Zhonyas.Cast();
            }

            if (ArchengelStaff.IsReady() && ArchengelStaff.IsOwned())
            {
                ArchengelStaff.Cast();
            }

            if (FaceOfTheMountain.IsReady() && FaceOfTheMountain.IsOwned())
            {
                FaceOfTheMountain.Cast(Player.Instance);
            }

            if (Talisman.IsReady() && Player.Instance.CountAlliesInRange(450) >= 2 && Talisman.IsOwned())
            {
                Talisman.Cast();
            }

            if (Mikael.IsReady() && Player.Instance.HasCC() && Mikael.IsOwned())
            {
                Mikael.Cast(Player.Instance);
            }

            if (Solari.IsReady() && Solari.IsOwned())
            {
                Solari.Cast();
            }

            if (Ohm.IsReady() && Ohm.IsOwned())
            {
                var turret = EntityManager.Turrets.Enemies.FirstOrDefault(t => t.IsAttackingPlayer);
                if (turret != null)
                {
                    Ohm.Cast(turret);
                }
            }

            if (Randuin.IsReady() && Player.Instance.CountEnemiesInRange(Randuin.Range) >= 2 && Randuin.IsOwned())
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


