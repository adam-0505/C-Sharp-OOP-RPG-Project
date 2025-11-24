namespace C__OOP_RPG_Project
{
    abstract class GameCharacter
    {
        string name;
        int health;
        int maxHealth;

        public string Name { get; }
        public int Health { get; private set; }

        public GameCharacter(string name, int maxHealth)
        {
            this.name = name;
            this.maxHealth = maxHealth;
        }

        public GameCharacter(string name)
        {
            this.name = name;
            maxHealth = 100;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
