using System;
using System.IO;
using System.Linq;

class Sentence{
  public static string path = "sentence.txt";
  
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
    try{
      int choice = Convert.ToInt32(Console.ReadLine());
      choice = Judical.NumberRewriter(choice,11)-1;
      
      Console.Clear();
      
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"View data({readText[choice]} - {path}):");
      Console.Write($"- 1 - {readText[choice]}\n");
      for(int i = choice + 1; i < choice + 11; i++)
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
  
  public static void DeleteData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"Delete data({path}):");
    
    string[] readText = File.ReadAllLines(path);
    int counterPrint = 1;
    foreach (string s in readText)
    {
        
        Console.WriteLine($"- {counterPrint} - {s}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");
    try{
      Console.Write("Choose line to delete:");
      int choiceDelete = Convert.ToInt32(Console.ReadLine());
      readText[choiceDelete - 1] = "";
      File.WriteAllLines(path, readText);
    }
    catch (Exception){
      
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
  
      string readLine = counter.ToString();
      using (StreamReader sr = new StreamReader(path))
      {
        string[] lines = File.ReadAllLines(path);
        Console.WriteLine(lines[counter]);
      }
    }

    catch (Exception)
    {
        // Let the user know what went wrong.
      Console.WriteLine("The file does not contain what you are looking for, try changing the letter case");
    }
  }
  
}