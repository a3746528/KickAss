using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;

namespace KickassSeries.Activator.DMGHandler
{
    internal class DamageHandler
    {
        public static bool ReceivingAA;
        public static bool ReceivingSpell;
        public static bool ReceivingDangSpell;

        public static void Initialize()
        {
            Obj_AI_Base.OnBasicAttack += Obj_AI_Base_OnBasicAttack;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
        }

        private static void Obj_AI_Base_OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null || hero.IsAlly) return;

            if (args.Target.IsMe)
            {
                ReceivingAA = true;
            }
            
            Core.DelayAction(() => ReceivingAA = false, 50);
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null || hero.IsAlly) return;

            var dangerousspell =
                DangerousSpells.Spells.FirstOrDefault(
                    x =>
                        x.Champion == hero.Hero && args.Slot == x.Slot &&
                        Config.Types.SettingsMenu[x.Champion.ToString() + x.Slot].Cast<CheckBox>().CurrentValue);

            if (dangerousspell != null && args.Target.IsMe)
            {
                ReceivingDangSpell = true;
                Chat.Print("player received AA");
                Core.DelayAction(Reset, 50);
                return;
            }

            if (args.Target.IsMe && args.Target != null)
            {
                ReceivingSpell = true;
                Chat.Print("player received Targeted spell");
                Core.DelayAction(Reset, 50);
                return;
            }

            if (Player.Instance.IsInRange(args.Start.To2D(), args.SData.CastRadius))
            {
                Chat.Print("Skill shot is in range");
                var projection = Player.Instance.Position.To2D().ProjectOn(args.Start.To2D(), args.End.To2D());

                if (projection.IsOnSegment &&
                    projection.SegmentPoint.Distance(Player.Instance.Position.To2D()) <= args.SData.CastRadius + Player.Instance.BoundingRadius)
                {
                    Chat.Print("player is on skillshot");
                }
            }

        }

        private static void Reset()
        {
            ReceivingDangSpell = false;
            ReceivingSpell = false;
        }
    }
}
