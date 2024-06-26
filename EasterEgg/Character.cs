using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;

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
            player.SaveCharacterInXML();
            Console.WriteLine($"Character {player.Name} created!");
        }
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Level: {Level}\n" +
                $"Health: {Health}\n" +
                $"Attack: {Atk}\n" +
                $"Defense: {Def}\n" +
                $"Speed: {Spd}";
        }
        public void SaveCharacterInXML()
        {
            try
            {
                string path = "Characters.xml";
                
                if (File.Exists(path))
                {
                    XDocument doc = XDocument.Load(path);
                    if (doc.Element("characters") == null)
                    {
                        doc.Add(new XElement("characters"));
                    }
                    XElement character = new XElement("Character",
                    new XElement("Name", Name),
                    new XElement("Level", Level),
                    new XElement("Health", Health),
                    new XElement("Atk", Atk),
                    new XElement("Def", Def),
                    new XElement("Spd", Spd));
                    doc.Element("characters")?.Add(character);
                    doc.Save(path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public void Battle(Character enemy)
        {
            int playerDamage = Atk - enemy.Def;
            int enemyDamage = enemy.Atk - Def;
            while (Health > 0 && enemy.Health > 0)
            {
                enemy.Health -= playerDamage;
                Health -= enemyDamage;
            }
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"{enemy.Name} defeated! {Name} won!");
            }
            else
            {
                Console.WriteLine($"{Name} defeated! {enemy.Name} won!");
            }
        }
    }
}

