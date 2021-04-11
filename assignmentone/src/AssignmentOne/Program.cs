using System;

namespace AssignmentOne
{
    class Program
    {
        // creating an object for AuthenticateService class
        AuthenticationService validate = new AuthenticationService();

        static void Main(string[] args)
        {
            // Calling start menu to start the program
            Program obj = new Program();
            obj.StartMenu();
        }
        
        // StartMenu function, which let user interact with the program as per their choice
        public void StartMenu(){
            Console.WriteLine("Hello there! Welcome to LeadSquared");
            Console.WriteLine("Here is the menu for you - ");
            Console.WriteLine("1. Enter '1' to register a new user.");
            Console.WriteLine("2. Enter '2' to validate a user.");
            Console.WriteLine("3. Enter 'Q' to quit.");

            // asking user for 1st time input and proceed according to user's choice
            char userInput = Convert.ToChar(Console.ReadLine());

            // This will let user interact with the program until they choose to quit by pressing Q button
            while(true){
                if(userInput == 'Q' | userInput == 'q'){
                    Console.WriteLine("Have a great day! You chose to QUIT.");
                    break;
                }
                switch(userInput){
                    case '1':
                    validate.RegisterUser();
                    break;

                    case '2':
                    validate.ValidateCredentials();
                    break;
                }

                Console.WriteLine("\n\n1. Enter '1' to register a new user.");
                Console.WriteLine("2. Enter '2' to validate a user.");
                Console.WriteLine("3. Enter 'Q' to quit.");

                userInput = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
