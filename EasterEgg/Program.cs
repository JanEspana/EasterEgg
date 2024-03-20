using System;
using System.Xml;

namespace EasterEgg
{
    public class Program
    {
        public static void Main()
        {

            const string MsgWelcome = "Hello hero! Do you want to create a character? \n1.YES\n2.NO";
            const string again = "Do you want to create another?\n1.YES\n2.NO";
            const string byebye = "Thanks for using. Here are your characters";

            int selection = 1;
            
            Console.WriteLine(MsgWelcome);
            selection = Convert.ToInt32(Console.ReadLine());
            while (selection == 1) {               
                Character.CreateCharacter();
                Console.WriteLine(again);
                selection = Convert.ToInt32(Console.ReadLine());             
            }
            if (selection < 1 || selection > 2) Console.WriteLine("You are have stupid");
            if (selection == 2) Console.WriteLine(byebye);

            


        }
    }
}
