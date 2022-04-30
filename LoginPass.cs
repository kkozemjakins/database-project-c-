using System;
using System.IO;
using System.Linq; 


class LoginPass{
  public static string path = "LoginPass.txt";

  public static string[] titles = {"Username:","Password","Roots:"};

  public static string temporaryPath = "CurrentUserRoots.txt";

  public static void ViewData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"View data({path}):");
    
    string[] readText = File.ReadAllLines(path);
    int counterPrint = 1;
    
    for(int i = 0; i < readText.Length; i+=3)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");
    counterPrint=0;
    try{
      int choice = Convert.ToInt32(Console.ReadLine());
      choice = Judical.NumberRewriter(choice,3) - 1;
      
      Console.Clear();
      
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"View data({readText[choice]} - {path}):");
      for(int i = choice; i < choice + 3; i++)
      {
          
          Console.WriteLine($"- | {titles[counterPrint]} {readText[i]}");
          counterPrint++;
      }
      Console.WriteLine ("=======================================");
    }
    catch
    {
      // Let the user know what went wrong.
      Console.Clear();
      ViewData();
    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    Judical.UserInfo();
  }

  public static void ChangeAccess(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"Change access({path}):");
    
    string[] readText = File.ReadAllLines(path);
    int counterPrint = 1;
    
    for(int i = 0; i < readText.Length; i+=3)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");
    int choice = 0; 
    counterPrint = 0;
    try{
      choice = Convert.ToInt32(Console.ReadLine());
      choice = Judical.NumberRewriter(choice,3) - 1;
      
      Console.Clear();
      
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"Change access({readText[choice]} - {path}):");
      for(int i = choice; i < choice + 3; i++)
      {
          
          Console.WriteLine($"- | {titles[counterPrint]} {readText[i]}");
          counterPrint++;
      }
      Console.WriteLine ("=======================================");
      Console.Write("Enter: ");
      readText[choice+2] = Console.ReadLine();
      File.WriteAllLines("LoginPass.txt", readText);
    }
    catch
    {
      // Let the user know what went wrong.
      Console.Clear();
      ChangeAccess();
    }

    Console.Clear();
    Judical.UserInfo();
  }
  
  public static void DeleteUser(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"Delete user({path}):");
    
    string[] readText = File.ReadAllLines(path);
    int counterPrint = 1;
    for(int i = 0; i < readText.Length; i+=3)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");
    try{
      
      Console.Write("Choose Sentence to delete(Press enter to return):");
      
      int choiceDelete = Convert.ToInt32(Console.ReadLine());
      
      choiceDelete = Judical.NumberRewriter(choiceDelete,3);
      
      for(int i = 0; i<3; i++){
        readText = readText.Where((source, index) =>index != choiceDelete-1).ToArray();
        File.WriteAllLines(path, readText);       
      }
      File.WriteAllLines(path, readText);
    }
    catch{
      Console.Clear();
      DeleteUser();
    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    Judical.UserInfo();
  }
  
  public static void Login(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Log in:");
    Console.WriteLine ("- 1 - Log in ");
    Console.WriteLine ("- 2 - Back ");
    Console.WriteLine ("- 3 - Exit ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");
    try{
      int choice = Convert.ToInt32(Console.ReadLine());

      switch (choice) {
        case 1:
          break;
    
        case 2:
          Console.Clear();
          MainSignIn();
          break;
    
        case 3:
          Environment.Exit(0);
          break;
          
        default:
          Login();
          break;
  
      }
    }
    catch{
      Console.Clear();
      Login();
      
    }

    string line;
    int counter = 0;
    int found = 0;
    string[] readText = File.ReadAllLines("LoginPass.txt");
    
    Console.Write("Username: ");
    string username = Console.ReadLine();

    Console.Write("Password: ");
    string password = Console.ReadLine();

    System.IO.StreamReader file = new System.IO.StreamReader("LoginPass.txt");

    int checkLine;
    
    while ((line = file.ReadLine()) != null)
    {
        
        if (line.Contains(username) )
        {
          checkLine = counter;
          while(checkLine != 0){
            checkLine-=3;
            if(checkLine < 0){
              break;
            }
          }
          Console.WriteLine(checkLine);
          if(checkLine == 0){
            found++;
            break;
          }
        }
      counter = counter + 1 ;
          
    }

    if(readText[counter] == username && readText[counter + 1] == password && found == 1){
      int roots = Convert.ToInt32(readText[counter + 2]);

      using(StreamWriter writetext = new StreamWriter("CurrentUserRoots.txt"))
      {
        writetext.WriteLine(roots);
      }
      if(readText[counter + 2] == "1"){
        Console.Clear();
        Judical.MainMenu();
        
      }
      else{
        Console.Clear();
        Judical.UserMainMenu();
      }
    }
    
      
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    MainSignIn();
    
  }
  static string[] UserRoots = File.ReadAllLines("CurrentUserRoots.txt");
  
  public static int Roots = Convert.ToInt32(UserRoots[0]);
  
  public static void Reg(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Register:");
    Console.WriteLine ("- 1 - Reg ");
    Console.WriteLine ("- 2 - Back ");
    Console.WriteLine ("- 3 - Exit ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");
    try{
      int choice = Convert.ToInt32(Console.ReadLine());

      switch (choice) {
        case 1:
          break;
    
        case 2:
          Console.Clear();
          MainSignIn();
          break;
    
        case 3:
          Environment.Exit(0);
          break;
          
        default:
          Reg();
          break;
  
      }
    }
    catch{
      Console.Clear();
      Reg();
      
    }
    
    Console.Write("Username(longer than 5 characters): ");
    string username = Console.ReadLine();
    if(username.Length < 5){
      Console.Clear();
      Reg();
    }

    string line;
    int found = 0;
    int counter = 0;
    int roots = 0;
      
    System.IO.StreamReader file = new System.IO.StreamReader(path);
      
    while ((line = file.ReadLine()) != null)
    {
        
        if (line.Contains(username))
        {
          found = found +1;
          break;
        }
      counter = counter + 1 ;
          
    }
    if(found == 1){
      Console.WriteLine("Username is already taken:");
      Console.Write("Enter: ");
      Console.ReadKey();
      Console.Clear();
      Reg();
    }

    else{
    
      Console.Write("Password: ");
      string password = Console.ReadLine();
  
      Console.Write("Confirm password: ");
      string confirm_password = Console.ReadLine();
      
      if(password == confirm_password && found < 1){
        using(StreamWriter writetext = new StreamWriter(path, true))
        {
          writetext.WriteLine($"{username}\n{password}\n{roots}");
        }
      }
    }
    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
    MainSignIn();


    
    
  }
  
  public static void MainSignIn(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Sign in:");
    Console.WriteLine ("- 1 - Log in ");
    Console.WriteLine ("- 2 - Registration ");
    Console.WriteLine ("- 3 - Exit ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");
    
    try{
      int choice = Convert.ToInt32(Console.ReadLine());

      switch (choice) {
        case 0:
          Console.Clear();
          MainSignIn();
          break;
        case 1:
          Console.Clear();
          Login();
          break;
    
        case 2:
          Console.Clear();
          Reg();
          break;
    
        case 3:
          Environment.Exit(0);
          break;
        default:
          MainSignIn();
          break;
          
      }
    }
    catch (Exception)
    {
      // Let the user know what went wrong.
    }

    Console.Write("Enter: ");
    Console.ReadKey();
    Console.Clear();
  }
    
}
  