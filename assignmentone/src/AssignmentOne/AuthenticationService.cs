using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AssignmentOne
{
    class AuthenticationService{

        // defining two private collections for email and password
        private List<string> emailCollection = new List<string>();
        private List<string> passwordCollection = new List<string>();

        //First Method - RegisterUser - to register user and validating password for below mentioned 5 rules -
        public void RegisterUser(){
            string email;
            string password;

            // Taking user input for new enmail address
            Console.Write("Enter New Email Address: ");
            email = Console.ReadLine();
            
            // Defining a regex expression to validate the email and then validating an email using Match Class
            Regex vaildateEmailAddress = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");  
            Match match = vaildateEmailAddress.Match(email);

            // To check if validation is passed or not
            // if email is correct - Taking user input for passoward and call passwordValidation function to validate passoword
            // if email is incorrect - print error message and exist
            if(match.Success){                
                Console.Write("Enter Password: ");
                password = Console.ReadLine();

                passwordValidation(email, password);
            }
            else{
                Console.WriteLine("Invalid Email-Address!!");
            }
        }

        // passwordValidation method to validate password
        // Take two arguments - email entered by user and password entered by user
        private bool passwordValidation(string email, string password)
        {
            // Validating Password -
            int validationPassed = 0;

            // check if length of password is > 8 or not
            // if not print error message and exit
            // if length > 8 then proceed with the other validation conditions
            if(password.Length < 8){
                Console.WriteLine("Validation Failed.");
            }
            else
            {
                // to check for one or more lowerCase letters
                foreach(char letter in password){
                    if(letter >= 'a' && letter <= 'z'){
                        validationPassed++;
                        break;
                    }
                }
                // to check for one or more upperCase letters
                foreach(char letter in password){
                    if(letter >= 'A' && letter <= 'Z'){
                        validationPassed++;
                        break;
                    }
                }
                // to check for one or more digits
                foreach(char letter in password){
                    if(letter >= '0' && letter <= '9'){
                        validationPassed++;
                        break;
                    }
                }
                // to check for one or more specials characters (@,#,$,&,?,/)
                foreach(char letter in password){
                    if(letter == '@' || letter == '#' | letter == '$' | letter == '&' | letter == '?' | letter == '/'){
                        validationPassed++;
                        break;
                    }
                }
                
                // To check if all validation condtions passed or not
                // If all conditions passed - Store email and password into respective data store and print success message
                // If any condition fails - print error message and exit
                if(validationPassed == 4){
                    Console.WriteLine("Validation PASSED!!\nUser Addded!");
                    emailCollection.Add(email);
                    passwordCollection.Add(password);
                    
                    return true;
                }
                else{
                    Console.WriteLine("Validation FAILED. Password too weak!");
                }
            }
            return false;
        }

        // Second Method - ValidateCredentials - To Validate Email and Password for existing user is correct or not
        public void ValidateCredentials(){
            string existingEmail;
            string existingPassword;

            // taking user input for email id
            Console.WriteLine("Enter Email: ");
            existingEmail = Console.ReadLine();

            // Check if that email id exists in the database or not
            // if email exists - Take user input for password.
            // - then check if entered passwords matches the password stored in database for that email
            // - if yes - show a success message to user.
            // - if not - show a error message for incorrect password.
            // if email doesnt exists - show error message for invalid email and exit.
            if(emailCollection.Contains(existingEmail)){
                int indexOfEmail = emailCollection.IndexOf(existingEmail);
                Console.WriteLine("Enter Password: ");
                existingPassword = Console.ReadLine();
                if(passwordCollection[indexOfEmail] == existingPassword){
                    Console.WriteLine("User FOUND, Correct Email id and password....");
                }
                else{
                    Console.WriteLine("Invalid password for the entered email id..");
                }
            }
            else{
                Console.WriteLine($"This Email id \'{existingEmail}\' doesn't exists");
            }
        }
    }
}