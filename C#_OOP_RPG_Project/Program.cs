namespace C__OOP_RPG_Project
{
    public interface IAttack
    {
        void Attack(GameCharacter target);
    }

    public interface IHealable
    {
        void ReceiveHealing(int amount);
    }

    public interface IAttackBehavior
    {
        void ExecuteAttack(GameCharacter attacker, GameCharacter target);
    }
    
    public enum CharacterClass
        {
            Warrior,
            Mage,
            Archer,
            Healer,
            Boss
        }        
    public abstract class GameCharacter : IHealable
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int MaxHealth { get; }
        public CharacterClass Role { get; protected set; }

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

        protected void Heal(int amount)
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

        protected abstract void PerformAttack(GameCharacter target);

        public void ReceiveHealing(int amount)
        {
            Heal(amount);
        }
    }

    public class Warrior : GameCharacter, IAttack
    {
        public Warrior(string name, int maxHealth = 200) : base(name, maxHealth)
        {
            Role = CharacterClass.Warrior;
        }

        protected override void PerformAttack(GameCharacter target)
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

        public void Attack(GameCharacter target)
        {
            PerformAttack(target);
        }
    }

    public class Mage : GameCharacter, IAttack
    {
        public Mage(string name, int maxHealth = 100) : base(name, maxHealth)
        {
            Role = CharacterClass.Mage;
        }

        protected override void PerformAttack(GameCharacter target)
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

        public void Attack(GameCharacter target)
        {
            PerformAttack(target);
        }
    }

    public sealed class BossEnemy : GameCharacter, IAttack
    {
        public BossEnemy(string name, int maxHealth = 500) : base(name, maxHealth)
        {
            Role = CharacterClass.Boss;
        }
        
        protected override void PerformAttack(GameCharacter target)
        {
            target.TakeDamage(30);
        }

        public void Attack(GameCharacter target)
        {
            PerformAttack(target);
        }        
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // List<GameCharacter> characters = new List<GameCharacter>();
            Warrior warrior1 = new Warrior("Thorfinn");
            Mage mage1 = new Mage("Thorkell");

            // characters.Add(warrior1);
            // characters.Add(mage1);

            // foreach(GameCharacter character in characters)
            // {
            //     character.PrintStatus();
            //     Console.WriteLine();
            // }
            // Console.WriteLine();

            // characters[0].PerformAttack(characters[1]);
            // characters[1].PerformAttack(characters[0]);

            // foreach(GameCharacter character in characters)
            // {
            //     character.PrintStatus();
            //     Console.WriteLine();
            // }

            // List<IAttack> attackers = new List<IAttack>();
            // attackers.Add((IAttack)warrior1);
            // attackers.Add((IAttack)mage1);

            // Warrior warrior2 = new Warrior("Askeladd");

            // foreach (IAttack attacker in attackers)
            // {
            //     attacker.Attack(warrior2);
            // }

            // warrior2.PrintStatus();

            BossEnemy bossEnemy1 = new BossEnemy("Kaiju No. 9");

            warrior1.Attack(bossEnemy1);
            mage1.Attack(bossEnemy1);
            bossEnemy1.Attack(warrior1);
            bossEnemy1.Attack(mage1);

            warrior1.PrintStatus();
            Console.WriteLine();
            mage1.PrintStatus();
            Console.WriteLine();
            bossEnemy1.PrintStatus();
        }
    }
}