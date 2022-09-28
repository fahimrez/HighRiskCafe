using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighRiskCafe
{
    internal class CoffeeMaker
    {
        private List<string> coffeeTypes = new()
        {
            "Espresso",
            "Americano",
            "Macchiato",
            "Cortado",
            "Cappucino",
            "Mocha"
        };

        public void MakeCoffee()
        {
            //Ask if user wants a coffee
            bool isWantingCoffee = AskCoffee();

            if (isWantingCoffee)
            {
                //Display coffee types
                DisplayCoffeeTypes();
            }
        }

        private void DisplayCoffeeTypes()
        {
            Console.WriteLine();
            foreach(string coffeeType in coffeeTypes)
            {
                Console.WriteLine(coffeeType);
            }
        }

        private bool AskCoffee()
        {
            Console.WriteLine("Do you want a coffee?");
            Console.WriteLine("Reply: ");

            string answer = Console.ReadLine();
            string[] affirmations = Enum.GetNames(typeof(Affirmation));

            if(affirmations.Contains(answer.ToLower()))
            {
                return true;
            }

            return false;
            
        }
    }
}
