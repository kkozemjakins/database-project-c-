using System;
using System.IO;
using System.Linq;

class Sentence{
  public static string path = "sentence.txt";

  public static string[] titles = {"Case name:","Date:","Time:","Place:","Convicted name:","Personal code:","Date of birth:","Start of Sentence:","End of sentence:","Term:","Sentence text:"};
  
  public static void AddData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"Add data({path}):");

    string line;
    int counter = 0;
    string[] readText = File.ReadAllLines(path);
    string[] readTextConvicted = File.ReadAllLines("case.txt");
    int counterPrint = 1;
    for(int i = 0; i < readTextConvicted.Length; i+=8)
    {
        
        Console.WriteLine($"- {counterPrint} - {readTextConvicted[i]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");
    Console.Write ("Choose case:");
    try{
      int choosedLine = Convert.ToInt32(Console.ReadLine());
      choosedLine = Judical.NumberRewriter(choosedLine,8);
  
      string text = readTextConvicted[choosedLine-1];
      int found = 0;
        
      System.IO.StreamReader file = new System.IO.StreamReader(path);
        
      while ((line = file.ReadLine()) != null)
      {
          
          if (line.Contains(text))
          {
            found = found +1;
            break;
          }
        counter = counter + 1 ;
  
        
            
      }
      if(found == 1){
        Console.WriteLine("Sentence for this case is already exist");
        Console.Write("Enter: ");
        Console.ReadKey();
        Console.Clear();
        AddData();
      }
      else{
  
        Console.Write ("\nStart of sentence:");
        string StartSentence = Console.ReadLine();
        
        Console.Write ("\nEnd of sentence:");
        string EndSentence = Console.ReadLine();
    
        Console.Write ("\nTerm:");
        string term = Console.ReadLine();
        
        Console.Write ("\nSentence:");
        string sentence = Console.ReadLine();
        using(StreamWriter writetext = new StreamWriter(path, true))
        {
    
          for(int i = choosedLine; i < choosedLine + 7; i++){
              writetext.WriteLine(readTextConvicted[i-1]);
          }
          writetext.WriteLine(StartSentence);
          writetext.WriteLine(EndSentence);
          writetext.WriteLine(term);
          writetext.WriteLine(sentence);
    
        }
      }
    }
    catch{
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
    for(int i = 0; i < readText.Length; i+=11)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");

    counterPrint = 0;
    try{
      int choice = Convert.ToInt32(Console.ReadLine());
      choice = Judical.NumberRewriter(choice,11)-1;
      
      Console.Clear();
      
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"View data({readText[choice]} - {path}):");
      for(int i = choice; i < choice + 11; i++)
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
  
  public static void DeleteData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"Delete data({path}):");
    
    string[] readText = File.ReadAllLines(path);
    int counterPrint = 1;
    for(int i = 0; i < readText.Length; i+=11)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");
    try{
      
      Console.Write("Choose Sentence to delete(Press enter to return):");
      
      int choiceDelete = Convert.ToInt32(Console.ReadLine());
      
      choiceDelete = Judical.NumberRewriter(choiceDelete,11);
      
      for(int i = 0; i<11; i++){
        readText = readText.Where((source, index) =>index != choiceDelete-1).ToArray();
        File.WriteAllLines(path, readText);       
      }
      File.WriteAllLines(path, readText);
    }
    catch (Exception){
      Console.Clear();
      DeleteData();
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
        if(checker >= 0 && checker <= 10){
          break;
        }
        checker = checker - 11;
      }
      
      int counterPrint = 0;
      
      Console.Clear();
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"Search data({path}):");      
      
      string readLine = counter.ToString();
      using (StreamReader sr = new StreamReader(path))
      {
        string[] lines = File.ReadAllLines(path);

        for(int i = 0; i < 11; i++){
          
          if(checker == i){
            
            for(int n = -i; n < 11 - checker; n++){
              
              Console.WriteLine($" - | {titles[counterPrint]} {lines[counter + n]}");
              counterPrint++;
            }
            
          }
        }
        
      }
      Console.WriteLine ("=======================================");

    }

    catch (Exception)
    {
        // Let the user know what went wrong.
      Console.WriteLine("The file does not contain what you are looking for, try changing the letter case");
    }
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
    
    string[] ConvictedSort = new string[ReadTextLength/11];
    
    int n = 0;

    for(int i = 0; i < readText.Length; i+=11){
      
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