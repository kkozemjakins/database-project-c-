using System;
using System.IO;
using System.Linq;

class Judical
{
    public static Int32 NumberRewriter(int number, int difference){
      int Base = 1;
      for(int i = 0; i < number-1; i++){
        Base = Base + difference;
      }
      return Base;
    }
    public static void AddData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Add data:");
    Console.WriteLine ("- 1 - Convicted ");
    Console.WriteLine ("- 2 - Case ");
    Console.WriteLine ("- 3 - Sentence ");
    Console.WriteLine ("- 4 - Back ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");

    int choice = 0;
    try{
      choice = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception)
    {
      // Let the user know what went wrong.
    }
    switch (choice) {
      case 0:
        Console.Clear();
        AddData();
        break;
      case 1:
        Console.Clear();
        Convicted.AddData();
        break;
  
      case 2:
        Console.Clear();
        Case.AddData();
        break;
  
      case 3:
        Console.Clear();
        Sentence.AddData();
        break;
        
      case 4:
        Console.Clear();
        MainMenu();
        break;

    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    AddData();
  }

 /////////////////////////////////// 
  public static void ViewData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("View data:");
    Console.WriteLine ("- 1 - Convicted ");
    Console.WriteLine ("- 2 - Case ");
    Console.WriteLine ("- 3 - Sentence ");
    Console.WriteLine ("- 4 - Back ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");

    int choice = 0;
    try{
      choice = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception)
    {
      // Let the user know what went wrong.
    }
    switch (choice) {
      case 0:
        Console.Clear();
        ViewData();
        break;
      case 1:
        Console.Clear();
        Convicted.ViewData();
        break;
  
      case 2:
        Console.Clear();
        Case.ViewData();
        break;
  
      case 3:
        Console.Clear();
        Sentence.ViewData();
        break;
        
      case 4:
        Console.Clear();
        MainMenu();
        break;
    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    ViewData();
    
  }

/////////////////////////////////////////////  
  public static void DeleteData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Delete data:");
    Console.WriteLine ("- 1 - Convicted ");
    Console.WriteLine ("- 2 - Case ");
    Console.WriteLine ("- 3 - Sentence ");
    Console.WriteLine ("- 4 - Back ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");

    int choice = 0;
    try{
      choice = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception)
    {
      // Let the user know what went wrong.
    }
    switch (choice) {
      case 0:
        Console.Clear();
        DeleteData();
        break;
      case 1:
        Console.Clear();
        Convicted.DeleteData();
        break;
  
      case 2:
        Console.Clear();
        Case.DeleteData();
        break;
  
      case 3:
        Console.Clear();
        Sentence.DeleteData();
        break;
        
      case 4:
        Console.Clear();
        MainMenu();
        break;

    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    DeleteData();
  }

////////////////////////////////////  
  public static void SearchData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Search data:");
    Console.WriteLine ("- 1 - Convicted ");
    Console.WriteLine ("- 2 - Case ");
    Console.WriteLine ("- 3 - Sentence ");
    Console.WriteLine ("- 4 - Back ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");

    int choice = 0;
    try{
      choice = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception)
    {
      // Let the user know what went wrong.
    }
    switch (choice) {
      case 0:
        Console.Clear();
        SearchData();
        break;
      case 1:
        Console.Clear();
        Convicted.SearchData();
        break;
  
      case 2:
        Console.Clear();
        Case.SearchData();
        break;
  
      case 3:
        Console.Clear();
        Sentence.SearchData();
        break;
        
      case 4:
        Console.Clear();
        MainMenu();
        break;

    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    SearchData(); 
  }

////////////////////////////////////////////////  
  public static void MainMenu()
  {
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Main Menu:\n- 1 - Add data\n- 2 - View data\n- 3 - Delete data\n- 4 - Search data\n- 5 - Exit ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");

    int choice = 0;
    try{
      choice = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception)
    {
      // Let the user know what went wrong.
      Console.Clear();
      MainMenu();
    }
    switch (choice) {
      case 0:
        Console.Clear();
        MainMenu();
        break;
      case 1:
        Console.Clear();
        AddData();
        break;
  
      case 2:
        Console.Clear();
        ViewData();
        break;
  
      case 3:
        Console.Clear();
        DeleteData();
        break;
        
      case 4:
        Console.Clear();
        SearchData();
        break;
        
      case 5:
        Environment.Exit(0);
        break;
    }
  } 

  public static void UserMainMenu()
  {
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Main Menu:\n- 1 - View data\n- 2 - Search data\n- 3 - Exit ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");

    int choice = 0;
    try{
      choice = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception)
    {
      // Let the user know what went wrong.
      Console.Clear();
      UserMainMenu();
    }
    switch (choice) {
      case 0:
        Console.Clear();
        UserMainMenu();
        break;
      case 1:
        Console.Clear();
        ViewData();
        break;
  
      case 2:
        Console.Clear();
        SearchData();
        break;
  
      case 3:
        Environment.Exit(0);
        break;

    }
  } 
} 