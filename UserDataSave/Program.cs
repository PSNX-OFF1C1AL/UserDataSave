using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using System.IO;
using System.Text.RegularExpressions;



public interface ChoosingActionInterface 
{ 
    int ChoiseFunctionUser { get; set; }
}

public interface MainFunctionsInterface
{
    string ResponseUserConfirmOperation { get; set; }
    string NameUserFileExists { get; set; }
    bool IsUserFileExists { get; set; }
    bool IsNeedListUserFiles {  get; set; }
    bool NeedEnterNameUserFile { get; set; }
    bool IsNeedUserFileInformation {  get; set; }
    string[] ListUserFiles { get; set; }
    string NameUserFile { get; set; }
    string ContentUserFile {  get; set; }
}

public interface RecordDataUserInterface
{
    string NicknameUser { get; set; }
    string FirstNameUser { get; set; }
    string LastNameUser { get; set; }
    int AgeUser { get; set; }
    int NumberBooksUser { get; set; }
    string[,] AutorsAndBooksReadUser { get; set; }
}

public interface EditingDataUserInterface
{
    string[] ListUserFiles { get; set; }
    string NameUserFile { get; set; }
    string ContentUserFile { get; set; }
    string SelectingVaribleLineUser { get; set; }

    int NumberBooksUser { get; set; }
    string AutorsAndBooksReadUser { get; set; }
    string AuthorBook { get; set; }
    string NameBook { get; set; }
}

public interface ReadDataUserInterface
{
    string[] ListUserFiles { get; set; }
    string NameUserFile { get; set; }
    string ContentUserFile { get; set; }
    int ReadDataUserChoice { get; set; }
}

public interface RemovalDataUserInterface
{
    string[] ListUserFiles { get; set; }
    string NameUserFile { get; set;}
    string ContentUserFile { get; set; }
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

class MainFunctions : MainFunctionsInterface
{
    public string ResponseUserConfirmOperation { get; set; }
    public string NameUserFileExists { get; set; }
    public bool IsUserFileExists { get; set; }
    public bool IsNeedListUserFiles { get; set; }
    public bool NeedEnterNameUserFile { get; set; }
    public bool IsNeedUserFileInformation { get; set; }
    public string[] ListUserFiles { get; set; }
    public string NameUserFile { get; set; }
    public string ContentUserFile { get; set; }

    public string GettingDataFromUserFile()
    {
        Console.WriteLine("Above is your list of files and the full path to it. \nBelow write the name of the file that you want to edit, for example: Readme.txt\nEnter a name:");
        NameUserFile = Console.ReadLine();
        ContentUserFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFile);
        Console.WriteLine(ContentUserFile);
        return ContentUserFile;
    }

    public void GettingUserFiles()
    {
        ListUserFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\");
        foreach (string s in ListUserFiles)
        {
            Console.WriteLine(s);
        }
    }

    public void CheckingFileExists()
    {
        for (int i = 0; i == 1;)
        {

            if (NeedEnterNameUserFile == true)
            {
                Console.WriteLine("Enter the name of the file you want to perform the operation with:");
                NameUserFileExists = Console.ReadLine();

            }

            IsUserFileExists = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFileExists);

            if (IsUserFileExists == true)
            {
                break;
            }
            else
            {
                NeedEnterNameUserFile = true;
                Console.WriteLine("Invalid file name, no such file exists, please try again.");
                GettingUserFiles();

            }

        }
    }


    public void ConfirmationOperation()
    {
        for (int i = 0; i == 1;)
        {
            Console.WriteLine("Are you sure you want to perform this operation? Write \"YES\" or \"NO\" without quotes");
            ResponseUserConfirmOperation = Console.ReadLine();
            if (ResponseUserConfirmOperation == "YES")
            {
                break;
            }
            else if (ResponseUserConfirmOperation == "NO")
            {
                var ChoiseFunction = new Program();
                ChoiseFunction.ChoosingAction();
            }
            else
            {
                Console.WriteLine("This answer does not exist, please try again.");
            }
        }
    }
}


class RecordDataUser : MainFunctions, RecordDataUserInterface
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

        IsUserFileExists = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NicknameUser);
        if (IsUserFileExists == true)
        {
            Console.WriteLine("A file with that name already exists, choose another nickname!");
            RecordDataUser RecordAct = new RecordDataUser();
            RecordAct.RecordAction();
        }

        Console.WriteLine("2.First name user");
        FirstNameUser = Console.ReadLine();

        Console.WriteLine("3.Last name user");
        LastNameUser = Console.ReadLine();

        Console.WriteLine("4.Age user");
        AgeUser = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("5. Number of books");
        NumberBooksUser = Convert.ToInt32(Console.ReadLine());
        AutorsAndBooksReadUser = new string [NumberBooksUser+1, NumberBooksUser+1];

        for (int i = 0; i < NumberBooksUser; i++)
        {
            Console.WriteLine("5." +(i+1) + " Enter the name of the author of the book:");
            string AuthorBook = Console.ReadLine();
            Console.WriteLine("5." +(i+1)+ " Enter the name of the book:");
            string NameBook = Console.ReadLine();
            AutorsAndBooksReadUser[1, i] = AuthorBook;
            AutorsAndBooksReadUser[2, i] = NameBook;
        }

        if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory+"UserData"))
        {

        }
        else
        {
            Directory.CreateDirectory("UserData");
        }

        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory+$"\\UserData\\{NicknameUser}.txt", "1. Nickname:"+NicknameUser + "\n\n2. First name:" + FirstNameUser + "\n\n3. Last name:" + LastNameUser + "\n\n4. Age:" + AgeUser + "\n\n5. The authors of the books and the book itself:\n");
        for (int i = 0; i < NumberBooksUser; i++)
        {
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + $"\\UserData\\{NicknameUser}.txt", "5." + (i+1) + " " + AutorsAndBooksReadUser[1, i] + "      "+ AutorsAndBooksReadUser[2, i]+"\n");
        }
        Console.WriteLine("\nThe operation was completed successfully, the user data has been created!");
        var ChoiseFunction = new Program();
        ChoiseFunction.ChoosingAction();
    }

}

class EditingDataUser : MainFunctions, EditingDataUserInterface
{
    public string SelectingVaribleLineUser { get; set; }
    public int NumberBooksUser { get; set; }
    public string AutorsAndBooksReadUser { get; set; }
    public string AuthorBook { get; set; }
    public string NameBook { get; set; }
    public void EditingAction()
    {

        GettingUserFiles();
        GettingDataFromUserFile();


        Console.WriteLine("Select the line you want to change, example \"1.\":");
        SelectingVaribleLineUser = Console.ReadLine();
        switch (SelectingVaribleLineUser)
        {
            case "1.":
                Console.WriteLine("\nEnter the user new nickname:");
                String nickname = Console.ReadLine();
                Regex regexNickname = new Regex(@"1\. Nickname:(.*)2\. First name:", RegexOptions.Singleline);
                ContentUserFile = regexNickname.Replace(ContentUserFile, "1. Nickname:" + nickname + "\n\n2. First name:");
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFile, ContentUserFile);
                Console.WriteLine("\nYou have successfully changed the user nickname!");
                break;

            case "2.":
                Console.WriteLine("\nEnter the user new first name:");
                String firstname = Console.ReadLine();
                Regex regexFirstname = new Regex(@"2\. First name:(.*)3\. Last name:", RegexOptions.Singleline);
                ContentUserFile = regexFirstname.Replace(ContentUserFile, "2. First name:" + firstname + "\n\n3. Last name:");
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFile, ContentUserFile);
                Console.WriteLine("\nYou have successfully changed the user first name!");
                break;

            case "3.":
                Console.WriteLine("\nEnter the user new last name:");
                String lastname = Console.ReadLine();
                Regex regexLastname = new Regex(@"3\. Last name:(.*)4\. Age:", RegexOptions.Singleline);
                ContentUserFile = regexLastname.Replace(ContentUserFile, "3. Last name:" + lastname + "\n\n4. Age:");
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFile, ContentUserFile);
                Console.WriteLine("\nYou have successfully changed the user last name!");
                break;

            case "4.":
                Console.WriteLine("\nEnter the user new age:");
                String age = Console.ReadLine();
                Regex regexAge = new Regex(@"4\. Age:(.*)5\. The authors of the books and the book itself:", RegexOptions.Singleline);
                ContentUserFile = regexAge.Replace(ContentUserFile, "4. Age:" + age + "\n\n5. The authors of the books and the book itself:");
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFile, ContentUserFile);
                Console.WriteLine("\nYou have successfully changed the user age!");
                break;

            case "5.":
                Console.WriteLine("\nEnter the user new number of books:");
                NumberBooksUser = Convert.ToInt32(Console.ReadLine());
                AutorsAndBooksReadUser = "5. The authors of the books and the book itself:\n";

                for (int i = 0; i < NumberBooksUser; i++)
                {
                    Console.WriteLine("5." + (i + 1) + " Enter the name of the author of the book:");
                    AuthorBook = Console.ReadLine();
                    Console.WriteLine("5." + (i + 1) + " Enter the name of the book:");
                    NameBook = Console.ReadLine();
                    AutorsAndBooksReadUser = AutorsAndBooksReadUser+ "5." + (i+1) + " "+ AuthorBook + "      " + NameBook+"\n";
                }

               
                Regex regexAutorsAndBooks = new Regex(@"5\. The authors of the books and the book itself:(.*)", RegexOptions.Singleline);
                ContentUserFile = regexAutorsAndBooks.Replace(ContentUserFile, AutorsAndBooksReadUser);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFile, ContentUserFile);
                Console.WriteLine("\nYou have successfully changed the user autors and books!");
                break;

            case "0":
                break;

        }

    }
}

class ReadDataUser : MainFunctions, ReadDataUserInterface
{
    public int ReadDataUserChoice { get; set; }
    public void ReadAction()
    {
        ListUserFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\");
        foreach (string s in ListUserFiles)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine("Above is your list of files and the full path to it. \nBelow write the name of the file that you want to edit, for example: Readme.txt\nEnter a name:");
        NameUserFile = Console.ReadLine();
        ContentUserFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFile);
        Console.WriteLine(ContentUserFile + "\n\nReading user data from the file was successful!\nEnter the number \"1\" to continue, or the number \"2\" to repeat reading the file");
        ReadDataUserChoice = Convert.ToInt32(Console.ReadLine());
        if (ReadDataUserChoice == 1)
        {
            var ProgramAct = new Program();
            ProgramAct.ChoosingAction();

        }
        else if (ReadDataUserChoice == 2)
        {
            var ReadDataUserAct = new ReadDataUser();
            ReadDataUserAct.ReadAction();
        }
        else
        {
            Console.WriteLine("The answer is incorrect. You are redirected to the main page.");
            var ProgramAct = new Program();
            ProgramAct.ChoosingAction();
        }

    }


}

class RemovalDataUser : MainFunctions, RemovalDataUserInterface
{
    public void RemovalAction() 
    {
        ListUserFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\");
        foreach (string s in ListUserFiles)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine("Above is your list of files and the full path to it. \nBelow write the name of the file that you want to edit, for example: Readme.txt\nEnter a name:");
        NameUserFile = Console.ReadLine();
        ContentUserFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFile);
        Console.WriteLine(ContentUserFile);
        
        ConfirmationOperation();

        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\UserData\\" + NameUserFile);
    }
}