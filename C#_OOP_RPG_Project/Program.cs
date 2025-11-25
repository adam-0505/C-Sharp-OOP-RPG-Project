namespace C__OOP_RPG_Project
{
    public enum CharacterClass
        {
            Warrior,
            Mage,
            Archer,
            Healer
        }        
    abstract class GameCharacter
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int MaxHealth { get; }
        public CharacterClass Role { get; set; }        

        public GameCharacter(string name, int maxHealth = 100)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (amount < 0)
            {
                return;
            }

            Health -= amount;

            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void Heal(int amount)
        {
            if (amount < 0)
            {
                return;
            }
            
            Health += amount;

            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public virtual void PrintStatus()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
        }

        public abstract void PerformAttack(GameCharacter target);
    }

    class Warrior : GameCharacter
    {
        public Warrior(string name, int maxHealth = 200) : base(name, maxHealth)
        {
            Role = CharacterClass.Warrior;
        }
    }

    class Mage : GameCharacter
    {
        public Mage(string name, int maxHealth = 100) : base(name, maxHealth)
        {
            Role = CharacterClass.Mage;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            CharacterClass warrior = CharacterClass.Warrior;
            CharacterClass mage = CharacterClass.Mage;
        }
    }
}
