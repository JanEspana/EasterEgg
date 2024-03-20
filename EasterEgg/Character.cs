namespace EasterEgg
{
    public class Character
    {
        public string? Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Spd { get; set; }

        public Character(string? name, int health, int atk, int def, int spd)
        {
            Name = name;
            Level = 1;
            Health = health;
            Atk = atk;
            Def = def;
            Spd = spd;
        }
        public static void CreateCharacter()
        {
            Console.WriteLine("Enter your character's name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your character's health:");
            int health = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your character's attack:");
            int atk = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your character's defense:");
            int def = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your character's speed:");
            int spd = Convert.ToInt32(Console.ReadLine());

            Character player = new Character(name, health, atk, def, spd);
        }
    }
}
