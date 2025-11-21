namespace C__OOP_RPG_Project
{
    abstract class GameCharacter
    {
        string name;
        int health;
        int maxHealth;

        public string Name { get; }
        public int Health { get; private set; }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
