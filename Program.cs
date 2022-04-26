using System;

namespace CSharp.LabExercise3
{
    class Pin
    {
        public void Pincode()
        {
            bool isPinWrong = true;
            int pinCount = 0;
            int triesLeft = 3;

             while (isPinWrong)
             {
                Console.WriteLine("Enter PIN: ");
                int pin = Convert.ToInt32(Console.ReadLine());
                if (pin == 1234) //set pincode to 1234
                {
                    Console.WriteLine("Access granted.");
                    isPinWrong = false;
                }
                else
                {
                    Console.WriteLine("\nInvalid PIN. Try again.\n");
                    pinCount++;
                    triesLeft--; //after 3 failed tries account will be locked
                    Console.WriteLine("\n{0} tries left", triesLeft);

                    if(pinCount == 3)
                    {
                        Console.WriteLine("\nYour account is locked. Please contact customer support to unlock your account.\n\n");
                        Environment.Exit(0);

                    }
                }
             }
        }
    }

    class UserAccount
    {
        public decimal Balance { get; set; }

        public void PrintBalance()
        {
            Console.WriteLine("\nYour balance is: {0}", Balance);
        }
        public UserAccount()
        {
            this.Balance = 0;
        }
    }
    
    

    class Processor
    {
        UserAccount userAccount;

        public Processor(UserAccount userAccount)
        { 
            this.userAccount = userAccount;
        }


        public void Withdraw(decimal withdrawAmount)
        {
            userAccount.Balance -= withdrawAmount;
            Console.WriteLine($"\nWithdrawn amount is: {withdrawAmount}");
            Console.WriteLine("Your remaining balance is: {0}", userAccount.Balance);
        }
        public void Deposit(decimal depositAmount)
        {
            userAccount.Balance += depositAmount;
            Console.WriteLine($"\nDeposited amount is: {depositAmount}");
            Console.WriteLine("Your total balance is: {0}", userAccount.Balance);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserAccount account = new UserAccount();
            Processor processor = new Processor(account);
            Pin pin = new Pin();

            pin.Pincode();


            bool isLooping = true;
            while (isLooping)
            {
                Console.WriteLine("\n\n~~~Welcome to ATM Service~~~");
                Console.WriteLine("\nPlease select from the following:\n");
                Console.WriteLine("[1] Check Balance");
                Console.WriteLine("[2] Withdraw Cash");
                Console.WriteLine("[3] Deposit Cash");
                Console.WriteLine("[4] Quit ATM Service");
                Console.WriteLine("");
                int userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        account.PrintBalance();
                        break;

                    case 2:

                        pin.Pincode();
                        Console.WriteLine("\nEnter amount you wish to withdraw.\n");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        if (withdrawAmount % 100 != 0) //set withdraw amount into multiples of 100
                        {
                            Console.WriteLine("\nAmount must be multiples of 100.\n");
                            break;
                        }
                        if (withdrawAmount <= 0) //cannot withdraw 0 or negative amount
                        {
                            Console.WriteLine("\nAmount must not be negative or 0.\n");
                            break;
                        }
                        if (account.Balance < withdrawAmount) //cannot withdraw less than your balance
                        {
                            Console.WriteLine("\nYour balance is less than the withdrawal amount.\n");
                            Console.WriteLine("Your balance is: {0}", account.Balance);
                            break;
                        }
                        processor.Withdraw(withdrawAmount);
                        break;

                    case 3:
                        Console.WriteLine("Enter the amount you wish to deposit.");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        if (depositAmount <= 0)
                        {
                            Console.WriteLine("You cannot enter 0 or a negative amount."); //you cannot deposit 0 or negative amount
                            break;
                        }
                        processor.Deposit(depositAmount);
                        break;
                    case 4:
                        Console.WriteLine("\nThank you for using our service. See you again next time!\n\n");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Enter a valid selection.");
                        break;
                }
            }
        }
    }
}