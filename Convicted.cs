using System;
using System.IO;
using System.Linq;

class Convicted{
  public static string path = "convicted.txt";

  static string[] titles = {"Convicted name:","Personal code:","Date of birth:"};
  
  public static void AddData(){
    string Name;
    string SecondName;
    string PersonCode;
    string BirthDate;

    Console.Write("Name:");
    Name = Console.ReadLine();
      
    Console.Write("SecondName:");
    SecondName = Console.ReadLine();
      
    Console.Write("PersonCode:");
    PersonCode = Console.ReadLine();

    string line;
    int found = 0;
    int counter = 0;
      
    System.IO.StreamReader file = new System.IO.StreamReader(path);
      
    while ((line = file.ReadLine()) != null)
    {
        
        if (line.Contains(PersonCode))
        {
          found = found +1;
          break;
        }
      counter = counter + 1 ;

      
          
    }
    if(found == 1){
      Console.WriteLine("Personal code cannot be repeated");
      Console.Write("Enter: ");
      Console.ReadKey();
      Console.Clear();
      AddData();
    }
    else{
      Console.Write("BirthDate:");
      BirthDate = Console.ReadLine();

      using(StreamWriter writetext = new StreamWriter(path, true))
      {
        writetext.WriteLine($"\n{Name} {SecondName}\n{PersonCode}\n{BirthDate}");
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
      Console.WriteLine ($"View data({readText[choice]} - {path}):");
      for(int i = choice; i < choice + 3; i++)
      {
          
          Console.WriteLine($"- | {titles[i]} {readText[i]}");
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
  ////////////////////DeleteData///////////////////////
  public static void DeleteData(){
    Console.WriteLine ("=======================================");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
    Console.WriteLine ("---------------------------------------");
    Console.WriteLine ($"Delete data({path}):");
    
    string[] readText = File.ReadAllLines(path);
    string[] TextCase = File.ReadAllLines("case.txt");
    string[] TextSentence = File.ReadAllLines("sentence.txt");
    int counterPrint = 1;
    for(int i = 0; i < readText.Length; i+=3)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]} - {readText[i+1]}");
        counterPrint++;
    }
    Console.WriteLine ("=======================================");
    try{
      Console.WriteLine("If you delete a convict, then all data associated with him is also deleted.");
      Console.Write("Choose line to delete(Press enter to return):");
      int choiceDelete = Convert.ToInt32(Console.ReadLine());
      choiceDelete = Judical.NumberRewriter(choiceDelete,3);
      //readText[choiceDelete - 1] = "";

      //////////////////Delete all data about convicted///////////////
      System.IO.StreamReader file = new System.IO.StreamReader("case.txt");
      string line;
      int counter = 0;
      var text = readText[choiceDelete];
       
      
 /////////////////////////////////////////////////////
  

      while ((line = file.ReadLine()) != null)
      {
          if (line.Contains(text))
          {
            counter = counter - 5;
            for(int i = 0; i<8; i++){
              TextCase = TextCase.Where((source, index) =>index != counter).ToArray();
              File.WriteAllLines("case.txt", TextCase);

            }
            counter = 0;
            file = new System.IO.StreamReader("case.txt");
            
          }
          else{
            counter = counter + 1 ;
          }
          
          
      }



      /////////////////////////////////


      counter = 0;
      System.IO.StreamReader fileSentence = new System.IO.StreamReader("sentence.txt");
      while ((line = fileSentence.ReadLine()) != null)
      {
          if (line.Contains(text))
          {
            counter = counter - 5;
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


      //////////////////////////////
      for(int i = 0; i<3; i++){
        readText = readText.Where((source, index) =>index != choiceDelete-1).ToArray();
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
      int ReadTextLength = counter;
      
      while(ReadTextLength > 0){
        ReadTextLength = ReadTextLength - 3;
        Console.WriteLine(ReadTextLength);
        if(ReadTextLength >= 0 && ReadTextLength <= 2){
          break;
        }
      }
      
  
      string readLine = counter.ToString();
      using (StreamReader sr = new StreamReader(path))
      {
        string[] lines = File.ReadAllLines(path);

        for(int i = 0; i < 3; i++){
          
          if(ReadTextLength == i){
            
            for(int n = -i; n < 3 - ReadTextLength; n++){
              
              Console.WriteLine(lines[counter + n]);
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
    
    string[] ConvictedSort = new string[ReadTextLength/3];
    
    int n = 0;

    for(int i = 0; i < readText.Length; i+=3){
      
      ConvictedSort[n] = readText[i] + " " +readText[i+1];

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
          Judical.Sort();
          break;

        default:
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