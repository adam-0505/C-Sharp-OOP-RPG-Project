namespace C__OOP_RPG_Project
{
    abstract class GameCharacter
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int MaxHealth { get; }

        public GameCharacter(string name, int maxHealth = 100)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
