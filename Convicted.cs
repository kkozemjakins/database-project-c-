using System;
using System.IO;
using System.Linq;

class Convicted{
  public static string path = "convicted.txt";
  
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
    counterPrint = 1;
    try{
      choice = Convert.ToInt32(Console.ReadLine());
      choice = Judical.NumberRewriter(choice,3)-1;
      
      Console.Clear();
      
      Console.WriteLine ("=======================================");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ("JUDICIAL INFORMATION SYSTEM");
      Console.WriteLine ("---------------------------------------");
      Console.WriteLine ($"View data({readText[choice]} - {path}):");
      Console.Write($"- o - {readText[choice]}\n");
      for(int i = choice + 1; i < choice + 3; i++)
      {
          
          Console.WriteLine($"- | - {readText[i]}");
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
    string[] TextCase = File.ReadAllLines("case.txt");
    string[] TextSentence = File.ReadAllLines("sentence.txt");
    int counterPrint = 1;
    for(int i = 0; i < readText.Length; i+=3)
    {
        
        Console.WriteLine($"- {counterPrint} - {readText[i]} - {readText[i+1]}");
        counterPrint+=3;
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
      int found = 0;
      
      
      
 /////////////////////////////////////////////////////
  

      while ((line = file.ReadLine()) != null)
      {
          if (line.Contains(text))
          {
            Console.WriteLine($"case txt:{counter}");
            counter = counter - 5;
            //found = 3;
            Console.WriteLine($"case txt:{counter}");
            for(int i = 0; i<8; i++){
              TextCase = TextCase.Where((source, index) =>index != counter).ToArray();
              File.WriteAllLines("case.txt", TextCase);
              Console.Write("Enter: ");
              Console.ReadKey();


            }
            counter = 0;
            file = new System.IO.StreamReader("case.txt");
            
          }
          else{
            counter = counter + 1 ;
          }
          
          
      }



      /////////////////////////////////


      found = 0;
      counter = 0;
      System.IO.StreamReader fileSentence = new System.IO.StreamReader("sentence.txt");
      while ((line = fileSentence.ReadLine()) != null)
      {
          if (line.Contains(text))
          {
            Console.WriteLine($"sentence txt:{counter}");
            counter = counter - 5 - found;
            found = 6;
            Console.WriteLine($"sentence txt:{counter}");
            for(int i = 0; i<11; i++){
              TextSentence = TextSentence.Where((source, index) =>index != counter).ToArray();
              File.WriteAllLines("sentence.txt", TextSentence);
              Console.Write("Enter: ");
              Console.ReadKey();
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
    //Console.Clear();
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
      int checker = counter;
      
      while(checker != 0 && checker !=1 && checker != 2){
        checker = checker - 3;
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
          for(int i = 0; i < 3; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }

        if(checker == 1){
          for(int i = -1; i < 2; i++){
            Console.WriteLine(lines[counter + i]);
          }
        }        

        if(checker == 2){
          for(int i = -2; i < 1; i++){
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
}