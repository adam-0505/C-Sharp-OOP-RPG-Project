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

        public override void PerformAttack(GameCharacter target)
        {
            target.TakeDamage(10);
        }

        public override void PrintStatus()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");

            Console.WriteLine("Warrior uses a heavy sword");
        }
    }

    class Mage : GameCharacter
    {
        public Mage(string name, int maxHealth = 100) : base(name, maxHealth)
        {
            Role = CharacterClass.Mage;
        }

        public override void PerformAttack(GameCharacter target)
        {
            target.TakeDamage(8);
        }

        public override void PrintStatus()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");

            Console.WriteLine("Mage channels power");
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<GameCharacter> characters = new List<GameCharacter>();
            GameCharacter warrior1 = new Warrior("Thorfinn");
            GameCharacter mage1 = new Mage("Thorkell");

            characters.Add(warrior1);
            characters.Add(mage1);

            foreach(GameCharacter character in characters)
            {
                character.PrintStatus();
                Console.WriteLine();
            }
        }
    }
}
