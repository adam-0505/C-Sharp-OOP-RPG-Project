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
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
