using System;
using System.IO;
using System.Text;
using static Note;




string STORAGE_PATH = "note.txt";

if (!File.Exists(STORAGE_PATH))
{
    Console.WriteLine("ERROR, THE DEFAULT PATH DOESN'T POINT TO AN EXISTING FILE");
    Console.WriteLine("Plese, Give me a valid file");
    STORAGE_PATH = Console.ReadLine()!;
}
//File.WriteAllLines(STORAGE_PATH,nevek);



while (true)
{
    Console.WriteLine("Your Notes: \n");
    Console.WriteLine("---------------------------------------------------");
    
    

   
        var lista = Note.show_notes(File.ReadAllText(STORAGE_PATH).Replace("\n",""));
        //Console.WriteLine(File.ReadAllText(STORAGE_PATH).Replace("\n","").Length);
        if( File.ReadAllText(STORAGE_PATH).Replace("\n","").Length > 4 )
        {
            for(var i = 0; i != lista.Count - 1 ; i++)
            {

                    Console.WriteLine(@$"
                    .........................
                    {i + 1}.   {Note.decode_string(lista[i])}
                    ");
             
                
            }

        }else{
        

            Console.WriteLine("You don't have any Notes");
            
        };
    
    Console.WriteLine("What would you like to do?");
    Console.WriteLine(@"
    1. Read an existing Note of yours
    2. Write a new Note
    3. Exit
    ");

    int mode = Int32.Parse( Console.ReadLine() ?? "1");
    if (mode == 1)
    {
        Console.WriteLine("Which one would you like to read ?");
        var index = Int32.Parse( Console.ReadLine() ?? "1");

        try{
            var choosen_note = File.ReadAllText(STORAGE_PATH).Split(Note.separator)[index - 1];
            Console.WriteLine(Note.decode_note(choosen_note));
        }
        catch(Exception){Console.WriteLine("There's no such Note");};
    }else if (mode == 2)
    {
        Console.WriteLine("Cim: \n");
        string? cim = Console.ReadLine();
        Console.WriteLine($@"
        {cim}
        =================");
        string? szoveg = Console.ReadLine();
        Console.WriteLine($@"
        {cim}
        =================
        {szoveg}
        =================
        
        ");
        string? author = Console.ReadLine();

        Note jegyzet = new Note(cim!,szoveg!,"2022",author);

        var jegyzetek = File.ReadAllLines(STORAGE_PATH).ToList();

        jegyzetek.Add(jegyzet.encode_note());


        File.WriteAllLines(STORAGE_PATH,jegyzetek);
    

    }else if(mode == 3)
    {
        Console.WriteLine("Exit");
        break;
    }
}


