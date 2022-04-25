using System;
using System.IO;
using System.Linq;

class Case{
  public static string path = "case.txt";
  
  public static void AddData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"Add data({path}):");
    
    string[] readText = File.ReadAllLines(path);
    string[] readTextConvicted = File.ReadAllLines("convicted.txt");
    int counterPrint = 1;
    for(int i = 0; i < readTextConvicted.Length; i+=3)
    {
        
        Console.WriteLine($"- {counterPrint} - {readTextConvicted[i]} - {readTextConvicted[i+1]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");

    try
    {
      Console.Write ("Choose convicted:");
      int choosedLine = Convert.ToInt32(Console.ReadLine());
      choosedLine = Judical.NumberRewriter(choosedLine,3);

    
  
      Console.Write ("\nName:");
      string name = Console.ReadLine();

      string line;
      int found = 0;
      int counter = 0;
        
      System.IO.StreamReader file = new System.IO.StreamReader(path);
        
      while ((line = file.ReadLine()) != null)
      {
          
          if (line.Contains(name))
          {
            found = found +1;
            break;
          }
        counter = counter + 1 ;
  
        
            
      }
      if(found == 1){
        Console.WriteLine("Case name cannot be repeated");
        Console.Write("Enter: ");
        Console.ReadKey();
        Console.Clear();
        AddData();
      }
      else{
        Console.Write ("\nDate:");
        string date = Console.ReadLine();
    
        Console.Write ("\nTime:");
        string time = Console.ReadLine();
    
        Console.Write ("\nPlace:");
        string place = Console.ReadLine();
        
        Console.Write ("\nText:");
        string text = Console.ReadLine();
        
        using(StreamWriter writetext = new StreamWriter(path, true))
        {
    
          writetext.WriteLine(name);
          writetext.WriteLine(date);
          writetext.WriteLine(time);
          writetext.WriteLine(place);
          for(int i = choosedLine; i < choosedLine + 3; i++){
              writetext.WriteLine(readTextConvicted[i-1]);
          }
          writetext.WriteLine(text);
        }
      }

    }
    catch
    {
      Console.Clear();
      Judical.AddData();
      
    }
    
  }
  
  public static void ViewData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"View data({path}):");
    
    string[] readText = File.ReadAllLines(path);
    int counterPrint = 1;
    
    for(int i = 0; i < readText.Length; i+=8)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");
    
    Console.Write("Enter: ");
    
    try{
      int choice = Convert.ToInt32(Console.ReadLine());
      choice = Judical.NumberRewriter(choice,8)-1;
      
      Console.Clear();
      
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"View data({readText[choice]} - {path}):");
      Console.Write($"- 1 - {readText[choice]}\n");
      for(int i = choice + 1; i < choice + 8; i++)
      {
          
          Console.WriteLine($"- | - {readText[i]}");
      }
      Console.WriteLine ("=======================================");
    }
    catch
    {
      // Let the user know what went wrong.
      Console.Clear();
      ViewData();
    }
  }

  public static void SearchData(){
    try
    {
      int counter = 0;
      string line;
      
      Console.Write("Input your search text: ");
      var text = Console.ReadLine();
      
      System.IO.StreamReader file = new System.IO.StreamReader(path);
      
      while ((line = file.ReadLine()) != null)
      {
          if (line.Contains(text))
          {
              break;
          }
          counter = counter + 1 ;
      
          
      }
      int checker = counter;
      
      while(checker != 0 && checker !=1 && checker != 2 && checker !=3 && checker != 4 && checker != 5 && checker !=6 && checker != 7){
        checker = checker - 8;
        Console.WriteLine(checker);
        if(checker < 0){
          Environment.Exit(0);
        }
      }
      
  
      string readLine = counter.ToString();
      using (StreamReader sr = new StreamReader(path))
      {
        string[] lines = File.ReadAllLines(path);

        
        if(checker == 0){
          for(int i = 0; i < 8; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }

        if(checker == 1){
          for(int i = -1; i < 7; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }        

        if(checker == 2){
          for(int i = -2; i < 6; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }  
        if(checker == 3){
          for(int i = -3; i < 5; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }

        if(checker == 4){
          for(int i = -4; i < 4; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }        

        if(checker == 5){
          for(int i = -5; i < 3; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }
        if(checker == 6){
          for(int i = -6; i < 2; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }  
        if(checker == 7){
          for(int i = -7; i < 1; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }  
        
      }
    }

    catch (Exception)
    {
        // Let the user know what went wrong.
      Console.WriteLine("The file does not contain what you are looking for, try changing the letter case");
    }
  }
  
////////////////////////////////////////////////////////////////
  public static void DeleteData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"Delete data({path}):");
    
    string[] readText = File.ReadAllLines(path);
    int counterPrint = 1;

    for(int i = 0; i < readText.Length; i+=8)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]}");
        counterPrint++;
    }
    

    Console.WriteLine ("=======================================");
    try{
      Console.Write("Choose line to delete(Press enter to return):");
      int choiceDelete = Convert.ToInt32(Console.ReadLine());
      choiceDelete = Judical.NumberRewriter(choiceDelete,8) - 1;
      
      //readText[choiceDelete - 1] = "";
      
      for(int i = 0; i<8; i++){
        readText = readText.Where((source, index) =>index != choiceDelete).ToArray();
        File.WriteAllLines(path, readText);       
      }

    }
    catch (Exception){
      Console.Clear();
      Judical.DeleteData();
    }
    Console.Clear();
    DeleteData();
    
  }
  
}