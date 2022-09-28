using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace HighRiskCafe
{
    internal class CoffeeMaker
    {
        private List<string> coffeeTypes = new()

        {
            "espresso",
            "americano",
            "macchiato",
            "cortado",
            "cappucino",
            "mocha"
        };

        private Coffee coffee;
        public void MakeCoffee()
        {
            //Ask if user wants a coffee
            bool isWantingCoffee = AskCoffee();

            if (isWantingCoffee)
            {
                //Display coffee types
                DisplayCoffeeTypes();

                // Ask what coffee type the user wants
                string validCoffeeType = AskCoffeeType();

                // Create a coffee object
                CreateCoffee(validCoffeeType);

                // Attempt to put coffee in machine
                bool success = PutCoffeeInMachine();

                if (success)
                {
                    success = PutWaterInMachine();

                    if (success)
                    {
                        success = PlaceCupInMachine();

                        if (success)
                        {
                            success = StartMachine();

                            if (success)
                            {
                                success = ServeCoffeeToGuests();

                                if (success) 
                                {
                                    coffee.IsDone = true;
                                }
                            }
                        }
                    }
                }

                DisplayResult();
            }
        }

        private void DisplayResult()
        {
            Console.WriteLine();
            Console.WriteLine("Coffee: ");
            Console.WriteLine($"Is done: {coffee.IsDone}");
            Console.WriteLine($"Coffee type: {coffee.CoffeeType}");
            Console.WriteLine($"Enjoy your {coffee.CoffeeType}");
            if (!coffee.IsDone)
            {
                Console.WriteLine($"Failed step: {coffee.FailStep}");
            }
        }

        private bool ServeCoffeeToGuests()
        {
            Console.WriteLine();
            Console.WriteLine("Attempting to serve coffee...");

            bool success = DetermineSuccess();

            if (success)
            {

                return true;
            }
            else
            {
                coffee.FailStep = "Failed to serve coffee...";
                return false;
            }

        }

        private bool StartMachine()
        {
            Console.WriteLine();
            Console.WriteLine("Attempting to start machine...");

            bool success = DetermineSuccess();

            if (success)
            {
                return true;
            }
            else
            {
                coffee.FailStep = "Failed to start the machine...";
                return false;
            }

        }

        private bool PlaceCupInMachine()
        {
            Console.WriteLine();
            Console.WriteLine("Attempting to put the cup in the machine...");

            bool success = DetermineSuccess();

            if (success)
            {
                return true;
            }
            else
            {
                coffee.FailStep = "Failed to put the the cup in the machine...";
                return false;
            }

        }

        private bool PutWaterInMachine()
        {
            Console.WriteLine();
            Console.WriteLine("Attempting to put water in machine...");

            bool success = DetermineSuccess();

            if (success)
            {
                return true;
            }
            else
            {
                coffee.FailStep = "Failed to put the water in the machine...";
                return false;
            }

        }

        private bool PutCoffeeInMachine()
        {
            Console.WriteLine();
            Console.WriteLine("Attempting to put coffee in machine...");

            bool success = DetermineSuccess();

            if (success)
            {
                return true;
            }
            else
            {
                coffee.FailStep = "Failed to put the coffee in the machine...";
                return false;
            }
          
        }

        private bool DetermineSuccess()
        {
            int randomNumber =  new Random().Next(0,100);

            if(randomNumber >= 20)
            {
                return true;
            }

            return false;
        }

        private void CreateCoffee(string validCoffeeType)
        {
            coffee = new();
            coffee.IsDone = false;
            coffee.CoffeeType = validCoffeeType;
            coffee.FailStep = "";
        }

        private string AskCoffeeType()
        {
            Console.WriteLine();
            Console.WriteLine("What coffee type do you want?");
            Console.WriteLine("Answer: ");

            string answer = Console.ReadLine();

            bool isValidCoffeeType = ValidateCoffeeType(answer);

            if (isValidCoffeeType)
            {
                return answer;
            }

            AskCoffeeType();
            return "";
        }

        private bool ValidateCoffeeType(string? answer)
        {
            if (coffeeTypes.Contains(answer.ToLower()))
            {
                return true;
            }

            return false;
        }

        private void DisplayCoffeeTypes()
        {
            Console.WriteLine();
            Console.WriteLine("What coffee type do you want?");
            Console.WriteLine("We have: ");
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
