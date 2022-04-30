using System;
using System.IO;
using System.Linq;

class Case{
  public static string path = "case.txt";

  public static string[] titles = {"Case name:","Date:","Time:","Place:","Convicted name:","Personal code:","Date of birth:","Case text:"};
  
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
    counterPrint = 0;
    try{
      int choice = Convert.ToInt32(Console.ReadLine());
      choice = Judical.NumberRewriter(choice,8)-1;
      
      Console.Clear();
      
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"View data({readText[choice]} - {path}):");
      for(int i = choice; i < choice + 8; i++)
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
      
      while(checker > 0){
        if(checker >= 0 && checker <= 7){
          break;
        }
        checker = checker - 8;
      }
      
      int counterPrint = 0;
      string readLine = counter.ToString();
      using (StreamReader sr = new StreamReader(path))
      {
        string[] lines = File.ReadAllLines(path);

        for(int i = 0; i < 8; i++){
          
          if(checker == i){
            
            for(int n = -i; n < 8 - checker; n++){
              
              Console.WriteLine($" - | {titles[counterPrint]} {lines[counter + n]}");
              counterPrint++;
            }
            
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

    string line;
    string[] readText = File.ReadAllLines(path);
    string[] TextSentence = File.ReadAllLines("sentence.txt");
    int counterPrint = 1;
    int counter = 0;

    for(int i = 0; i < readText.Length; i+=8)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]}");
        counterPrint++;
    }
    

    Console.WriteLine ("=======================================");
    try{
      Console.WriteLine("If you delete a case, then all data associated with this case is also deleted.");
      Console.Write("Choose line to delete(Press enter to return):");
      int choiceDelete = Convert.ToInt32(Console.ReadLine());
      choiceDelete = Judical.NumberRewriter(choiceDelete,8) - 1;

      string text = readText[choiceDelete];

      System.IO.StreamReader fileSentence = new System.IO.StreamReader("sentence.txt");
      while ((line = fileSentence.ReadLine()) != null)
      {
          if (line.Contains(text))
          {

            for(int i = 0; i<11; i++){
              TextSentence = TextSentence.Where((source, index) =>index != counter).ToArray();
              File.WriteAllLines("sentence.txt", TextSentence);

            }
            fileSentence = new System.IO.StreamReader("sentence.txt");
            counter = 0;
          }
          else{
            counter = counter + 1 ;
          }
      }
      
      
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
  ////////////////////////////////////////////////////
  public static void Sort(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("Sort data({path}):");
    Console.WriteLine ("- 1 - A-Z ");
    Console.WriteLine ("- 2 - Z-A ");
    Console.WriteLine ("- 3 - Back ");
    Console.WriteLine ("=======================================");
    Console.Write("Enter: ");
    
    string[] readText = File.ReadAllLines(path);

    int ReadTextLength = readText.Length;
    
    string[] ConvictedSort = new string[ReadTextLength/8];
    
    int n = 0;

    for(int i = 0; i < readText.Length; i+=8){
      
      ConvictedSort[n] = readText[i];

      n++;
      
    }



    try{
      int choice = Convert.ToInt32(Console.ReadLine());

      Console.Clear();
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"Sort data({path}):");
      
      switch(choice){
        case 1:
          Array.Sort(ConvictedSort);
          
          foreach (string people in ConvictedSort)
          {
            Console.WriteLine($"- | - {people}");
          }
          
          break;
    
        case 2:
          Array.Sort(ConvictedSort);

          Array.Reverse(ConvictedSort);
          
          foreach (string people in ConvictedSort)
          {
            Console.WriteLine($"- | - {people}");
          }
          break;
        case 3:
          Console.Clear();
          Judical.Sort();
          break;

        default:
          Console.Clear();
          Sort();
          break;

      }
    }
    catch (Exception)
    {
      // Let the user know what went wrong.
      Console.Clear();
      Sort();
    }
    Console.WriteLine ("=======================================");
  }
  
}