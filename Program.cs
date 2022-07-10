using System;
using System.IO;
using System.Text;
using static Note;




string STORAGE_PATH = "note.txt";
//File.WriteAllLines(STORAGE_PATH,nevek);



while (true)
{
    Console.WriteLine("Az eddigi jegyzeteid: \n");
    Console.WriteLine("---------------------------------------------------");
    
    

   
        var lista = Note.show_notes(File.ReadAllText(STORAGE_PATH).Replace("\n",""));
        //Console.WriteLine(File.ReadAllText(STORAGE_PATH).Replace("\n","").Length);
        if( File.ReadAllText(STORAGE_PATH).Replace("\n","").Length > 4 )
        {
            for(var i = 0; i < lista.Count ; i++)
            {

                    Console.WriteLine(@$"
                    .........................
                    {i + 1}.   {Note.decode_string(lista[i])}
                    ");
             
                
            }

        }else{
        

            Console.WriteLine("Eddig Nem Volt Feljegyzésed");
            
        };
    
    Console.WriteLine("Mit Szeretnél Csinálni?");
    Console.WriteLine(@"
    1. Felovasni Egy Meglévő Jegyzetet
    2. Új Jegyzet Irás
    ");

    int mode = Int32.Parse( Console.ReadLine() ?? "1");
    if (mode == 1)
    {
        Console.WriteLine("Melyik Jegyzetet Olvassam Fel ?");
        var index = Int32.Parse( Console.ReadLine() ?? "1");

        try{
            var choosen_note = File.ReadAllText(STORAGE_PATH).Split(Note.separator)[index - 1];
            Console.WriteLine(Note.decode_note(choosen_note));
        }
        catch(Exception){Console.WriteLine("Nincs Olyan Indexü Jegyzet");};
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
        string? authro = Console.ReadLine();

        Note jegyzet = new Note(cim!,szoveg!,"2022",authro);

        var jegyzetek = File.ReadAllLines(STORAGE_PATH).ToList();

        jegyzetek.Add(jegyzet.encode_note());


        File.WriteAllLines(STORAGE_PATH,jegyzetek);
    

    }else if(mode == 3)
    {
        break;
    }
}


