namespace _03BarracksFactory.Models.Units
{
    public class Horseman : Unit
    {
        public const int Health = 50;
        public const int AttackDamage = 10;

        public Horseman() : base(Health, AttackDamage)
        {
        }
    }
}