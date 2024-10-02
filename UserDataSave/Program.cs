using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

public interface ChoosingActionInterface 
{ 
    int ChoiseFunctionUser { get; set; }
}

public interface RecordDataUserInterface
{
    string NicknameUser { get; set; }
    string FirstNameUser { get; set; }
    string LastNameUser { get; set; }
    int AgeUser { get; set; }
    int NumberBooksUser {  get; set; }
    string[,] AutorsAndBooksReadUser { get; set; }
}



class Program : ChoosingActionInterface
{
    public int ChoiseFunctionUser { set; get; }

    static void Main()
    {
        Program ChoosingAct = new Program();
        ChoosingAct.ChoosingAction();
    }

    public void ChoosingAction() 
    {
        Console.WriteLine("\nWrite this number if:\n1-You want to create a new record\n2-You want to change an existing record\n3-You want to read an existing record\n4-Do you want to delete an existing record");
        ChoiseFunctionUser = Convert.ToInt32(Console.ReadLine());

        if (ChoiseFunctionUser == 1)
        {
            var RecordAct = new RecordDataUser();
            RecordAct.RecordAction();
        }
        else if (ChoiseFunctionUser == 2)
        {
            var EditingAct = new EditingDataUser();
            EditingAct.EditingAction();
        }
        else if (ChoiseFunctionUser == 3)
        {
            var ReadAct = new ReadDataUser();
            ReadAct.ReadAction();
        }
        else if (ChoiseFunctionUser == 4)
        {
            var RemovalAct = new RemovalDataUser();
            RemovalAct.RemovalAction();
        }
        else
        {
            Console.WriteLine("\nThis text does not correspond to the functions specified in the program, please specify the correct number from 1 to 4, depending on which function you need.");
            Program ChoosingAct = new Program();
            ChoosingAct.ChoosingAction();
        }
    }

}




class RecordDataUser : RecordDataUserInterface
{
    public string NicknameUser { get; set; }
    public string FirstNameUser { get; set; }
    public string LastNameUser { get; set; }
    public int AgeUser { get; set; }
    public int NumberBooksUser { get; set; }
    public string[,] AutorsAndBooksReadUser { get; set; }

    public void RecordAction()
    {
        Console.WriteLine("\nCreating a user record.\n1. Nickname user ");
        NicknameUser = Console.ReadLine();

        Console.WriteLine("2.First name user");
        FirstNameUser = Console.ReadLine();

        Console.WriteLine("3.Last name user");
        LastNameUser = Console.ReadLine();

        Console.WriteLine("4.Age user");
        AgeUser = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("5. Number of books");
        NumberBooksUser = Convert.ToInt32(Console.ReadLine());
        AutorsAndBooksReadUser = new string [NumberBooksUser, NumberBooksUser];

        for (int i = 0; i < NumberBooksUser; i++)
        {
            Console.WriteLine("5." + (i + 1) + " Enter the name of the author of the book:");
            string AuthorBook = Console.ReadLine();
            Console.WriteLine("5." + (i + 1) + " Enter the name of the book:");
            string NameBook = Console.ReadLine();
            AutorsAndBooksReadUser[1, i] = AuthorBook;
            AutorsAndBooksReadUser[2, i] = NameBook;
        }

        System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory+$"\\{NicknameUser}.txt", "1. Nickname:"+NicknameUser + "\n\n2. First name:" + FirstNameUser + "\n\n3. Last name:" + LastNameUser + "\n\n4. Age:" + AgeUser + "\n\n5. The authors of the books and the book itself:\n");
        for (int i = 0; i < NumberBooksUser; i++)
        {
            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + $"\\{NicknameUser}.txt", "5." + i + " " + AutorsAndBooksReadUser[1, i] + "      ");

            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + $"\\{NicknameUser}.txt", AutorsAndBooksReadUser[2, i] + "\n");

        }
        Console.WriteLine("\nThe operation was completed successfully, the user data has been created!");
        var ChoiseFunction = new Program();
        ChoiseFunction.ChoosingAction();
    }

}


class EditingDataUser 
{
    public void EditingAction()
    {

    }
}


class ReadDataUser 
{ 
    public void ReadAction()
    {

    }
}


class RemovalDataUser 
{
    public void RemovalAction() 
    {
    
    }
}