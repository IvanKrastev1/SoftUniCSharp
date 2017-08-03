namespace _03BarracksFactory.Models.Units
{
    using Contracts;
    public class Gunner :Unit
    {
        public const int Health = 20;
        public const int AttackDamage = 20;

        public Gunner() : base(Health, AttackDamage)
        {
        }
    }
}