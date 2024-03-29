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
    string[] UserRoots = File.ReadAllLines("CurrentUserRoots.txt");
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
        if(Convert.ToInt32(UserRoots[0]) == 1){
          MainMenu();
        }
        else{
          UserMainMenu();
        }
        break;

      default:
        Console.Clear();
        AddData();
        break;

    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    AddData();
  }

 /////////////////////////////////// 
  public static void ViewData(){
    string[] UserRoots = File.ReadAllLines("CurrentUserRoots.txt");
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
        if(Convert.ToInt32(UserRoots[0]) == 1){
          MainMenu();
        }
        else{
          UserMainMenu();
        }
        break;

      default:
        Console.Clear();
        ViewData();
        break;
    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    ViewData();
    
  }

/////////////////////////////////////////////  
  public static void DeleteData(){
    string[] UserRoots = File.ReadAllLines("CurrentUserRoots.txt");
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
        Console.Clear();
        if(Convert.ToInt32(UserRoots[0]) == 1){
          MainMenu();
        }
        else{
          UserMainMenu();
        }
        break;

      default:
        Console.Clear();
        DeleteData();
        break;

    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    DeleteData();
  }

////////////////////////////////////  
  public static void SearchData(){
    string[] UserRoots = File.ReadAllLines("CurrentUserRoots.txt");
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
        if(Convert.ToInt32(UserRoots[0]) == 1){
          MainMenu();
        }
        else{
          UserMainMenu();
        }
        break;

      default:
        Console.Clear();
        SearchData();
        break;

    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    SearchData(); 
  }

////////////////////////////////////////////////  
  public static void ObjectsNum(){
    string[] UserRoots = File.ReadAllLines("CurrentUserRoots.txt");
    string[] TextConvicted = File.ReadAllLines(Convicted.path);
    string[] TextCase = File.ReadAllLines(Case.path);
    string[] TextSentence = File.ReadAllLines(Sentence.path);

    int ConvictedCounter = 0;
    int CaseCounter = 0;
    int SentenceCounter = 0;

    for(int i = 0; i < TextConvicted.Length; i+=3){
      ConvictedCounter++;
    }
    for(int i = 0; i < TextCase.Length; i+=8){
      CaseCounter++;
    }
    for(int i = 0; i < TextSentence.Length; i+=11){
      SentenceCounter++;
    }

    int SumObjectsNum = ConvictedCounter + CaseCounter + SentenceCounter;
    
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Number of objects:");
    
    Console.WriteLine ($"- | - Convicted - ({ConvictedCounter})");
    Console.WriteLine ($"- | - Case - ({CaseCounter})");
    Console.WriteLine ($"- | - Sentence - ({SentenceCounter}) ");
    Console.WriteLine ($"- | - Total objects in all files - ({SumObjectsNum}) ");

    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    if(Convert.ToInt32(UserRoots[0]) == 1){
      MainMenu();
    }
    else{
      UserMainMenu();
    }
    
  }
  ////////////////////////////////////////////////////
  public static void Sort(){
    string[] UserRoots = File.ReadAllLines("CurrentUserRoots.txt");
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Sort data:");
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
        Sort();
        break;
      case 1:
        Console.Clear();
        Convicted.Sort();
        break;
  
      case 2:
        Console.Clear();
        Case.Sort();
        break;
  
      case 3:
        Console.Clear();
        Sentence.Sort();
        break;
        
      case 4:
        Console.Clear();
        if(Convert.ToInt32(UserRoots[0]) == 1){
          MainMenu();
        }
        else{
          UserMainMenu();
        }
        break;

      default:
        Console.Clear();
        Sort();
        break;

    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    Sort(); 
    
  }
/////////////////////////////////////////////////////
  public static void Summary(){
    string[] UserRoots = File.ReadAllLines("CurrentUserRoots.txt");
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"Summary({Case.path}):");

    string[] readTextConvicted = File.ReadAllLines(Convicted.path);
    string[] readTextCase = File.ReadAllLines(Case.path);
    string[] readTextSentence = File.ReadAllLines(Sentence.path);
    int counterPrint = 1;

    for(int i = 0; i < readTextCase.Length; i+=8)
    {
        
        Console.WriteLine($"- {counterPrint} - {readTextCase[i]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");
    Console.Write("Enter(Press ENTER to return): ");
    try{
      int choice = Convert.ToInt32(Console.ReadLine());
      choice = NumberRewriter(choice,8)-1;

      Console.Clear();
      
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"Summary({readTextCase[choice]} - {Case.path}):");
/////////////////////////
      Console.WriteLine ($"Сonvicted:");

      counterPrint = 0;
      
      for(int i = choice + 4; i < choice + 7; i++)
      {
          
        Console.WriteLine($"- | {Convicted.titles[counterPrint]} {readTextCase[i]}");
        counterPrint++;
      }

      counterPrint = 0;
///////////////////////////
      Console.WriteLine ($"Case:");
      
      for(int i = choice; i < choice + 8; i++)
      {
        if(i >= choice + 4 && i <= choice + 6){
          i+=3;
          counterPrint+=3;
        }
        Console.WriteLine($"- | {Case.titles[counterPrint]} {readTextCase[i]}");
        counterPrint++;
      }
//////////////////////////
      Console.WriteLine ($"Sentence:");
      counterPrint = 0;
      int counter = 0;
      string line;
      string text = readTextCase[choice];
      System.IO.StreamReader file = new System.IO.StreamReader(Sentence.path);
        
      while ((line = file.ReadLine()) != null)
      {
          if (line.Contains(text))
          {
            break;
          }
        counter = counter + 1 ;
      }      
      
      for(int i = counter; i < counter + 11; i++)
      {
        if(i >= counter + 1 && i <= counter + 6){
          i+=6;
          counterPrint+=6;
        }
        Console.WriteLine($"- | {Sentence.titles[counterPrint]} {readTextSentence[i]}");
        counterPrint++;
      }

      Console.WriteLine ("=======================================");
      Console.WriteLine ("Enter:");
    }
    catch{
      Console.Clear();
      if(Convert.ToInt32(UserRoots[0]) == 1){
        MainMenu();
      }
      else{
        UserMainMenu();
      }
    }
    Console.ReadKey();
    Console.Clear();
    if(Convert.ToInt32(UserRoots[0]) == 1){
      MainMenu();
    }
    else{
      UserMainMenu();
    }
  }
////////////////////////////////////////////////////
  public static void UserInfo(){
    string[] UserRoots = File.ReadAllLines("CurrentUserRoots.txt");
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("User info:");
    Console.WriteLine ("- 1 - View data");
    Console.WriteLine ("- 2 - Change access");
    Console.WriteLine ("- 3 - Delete user");
    Console.WriteLine ("- 4 - Back");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");

    try{
      int choice = Convert.ToInt32(Console.ReadLine());

      switch (choice) {
        case 1:
          Console.Clear();
          LoginPass.ViewData();
          break;
    
        case 2:
          Console.Clear();
          LoginPass.ChangeAccess();
          break;
    
        case 3:
          Console.Clear();
          LoginPass.DeleteUser();
          break;
          
        case 4:
          Console.Clear();
          if(Convert.ToInt32(UserRoots[0]) == 1){
            MainMenu();
          }
          else{
            UserMainMenu();
          }
          break;
  
        default:
          Console.Clear();
          UserInfo();
          break;
  
      }
    }
    catch
    {
      // Let the user know what went wrong.
      Console.Clear();
      UserInfo();
    }

  }
  
  public static void MainMenu()
  {
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Main Menu: ");
    Console.WriteLine ("- 1 - Add data");
    Console.WriteLine ("- 2 - View data");
    Console.WriteLine ("- 3 - Delete data");
    Console.WriteLine ("- 4 - Search data");
    Console.WriteLine ("- 5 - Sort");
    Console.WriteLine ("- 6 - Summary");
    Console.WriteLine ("- 7 - Number of objects");
    Console.WriteLine ("- 8 - User info");
    Console.WriteLine ("- 9 - Exit ");
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
        Console.Clear();
        Sort();
        break;

      case 6:
        Console.Clear();
        Summary();
        break;
        
      case 7:
        Console.Clear();
        ObjectsNum();
        break;
        
      case 8:
        Console.Clear();
        UserInfo();
        break;
        
      case 9:
        Console.Clear();
        LoginPass.MainSignIn();
        break;

      default:
        Console.Clear();
        MainMenu();
        break;
    }
  } 

  public static void UserMainMenu()
  {
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Main Menu:");
    Console.WriteLine ("- 1 - View data");
    Console.WriteLine ("- 2 - Search data");
    Console.WriteLine ("- 3 - Sort");
    Console.WriteLine ("- 4 - Summary");
    Console.WriteLine ("- 5 - Exit");
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
        Console.Clear();
        Sort();
        break;
        
      case 4:
        Console.Clear();
        Summary();
        break;
        
      case 5:
        Console.Clear();
        LoginPass.MainSignIn();
        break;

      default:
        Console.Clear();
        UserMainMenu();
        break;

    }


    
  } 
} 