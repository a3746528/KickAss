﻿using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using KickassSeries.Ultilities;
using SharpDX;

namespace KickassSeries.Champions.Bard
{
    internal class Functions
    {
        public static void CastQ(Obj_AI_Base target)
        {
            var Qpred = SpellManager.Q.GetPrediction(target);

            //var Qdire = (Qpred.CastPosition - Qpred.UnitPosition).Normalized();

            //Dunno the push distance fix later

            if (target.IsValidTarget(SpellManager.Q.Range) && SpellManager.Q.IsReady())
            {
                if (target.Position.Extend(Player.Instance.Position, 450).IsWall() ||
                    target.Position.Extend(Player.Instance.Position, 450).IsBuilding() ||
                    Qpred.CollisionObjects.Length == 1)
                {
                    SpellManager.Q.Cast(target);
                }
            }
        }
    }
}
