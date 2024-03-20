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
                using (XmlWriter writer = XmlWriter.Create(path))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Character");
                    writer.WriteElementString("Name", Name);
                    writer.WriteElementString("Level", Level.ToString());
                    writer.WriteElementString("Health", Health.ToString());
                    writer.WriteElementString("Attack", Atk.ToString());
                    writer.WriteElementString("Defense", Def.ToString());
                    writer.WriteElementString("Speed", Spd.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
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
            if (Health <= 0)
            {
                Console.WriteLine("You lost the battle!");
            }
            else
            {
                Console.WriteLine("You won the battle!");
            }
        }
    }
}
