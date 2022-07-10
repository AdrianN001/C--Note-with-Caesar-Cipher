
class Note{
    public string Title; 
    public string Body;

    public string Date_Added;

    public string Author;

    public const int SHIFTED_VALUE = 4;

    public static string separator = ">/"; 

    public Note(string Title_1, string Body_1, string Date_Added_1, string? Author_1)
    {
        this.Title = Title_1;
        this.Body = Body_1; 
        this.Date_Added = Date_Added_1; 

        if (Author_1 == null)
            this.Author = Environment.UserName ?? "Adrian";
        else
            this.Author = Author_1; 
    }

    public string encode_note()
    {
        string full = $"{encode_string(this.Title)}&&{encode_string(this.Body)}&&{encode_string(this.Date_Added)}&&{encode_string(this.Author)}{separator}";
        return full; 
    }
    private string encode_string(string basic_string)// elore csusztatja 
    {
        char[] alphabet_num = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z','1','2','3','4','5','6','7','8','9','0'};

        string starting_string = "";
        foreach(char character in basic_string)
        {
            if (!alphabet_num.Contains(character))
            {
                starting_string.Append(character);
                continue;
            }
            int index = Array.IndexOf(alphabet_num,char.Parse(character.ToString().ToUpper())) + SHIFTED_VALUE;

            starting_string += alphabet_num[index % alphabet_num.Length];
        }

        return starting_string;
    }
    
    public static string decode_string(string encoded_string)//hatra csusztatja
    {
        char[] alphabet_num = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z','1','2','3','4','5','6','7','8','9','0'};

        string starting_string = "";
        foreach(char character in encoded_string)
        {
            if (!alphabet_num.Contains(character))
            {
                starting_string.Append(character);
                continue;
            }
            int index = Array.IndexOf(alphabet_num,char.Parse(character.ToString().ToUpper()));

            if (index >= 4)
            {
                starting_string.Append(alphabet_num[(index - 4) % alphabet_num.Length]);
                starting_string = $"{starting_string}{alphabet_num[(index - 4) % alphabet_num.Length]}";
            }else{
                
                index += alphabet_num.Length;
                starting_string = $"{starting_string}{alphabet_num[(index - 4) % alphabet_num.Length]}";
            }
        }

        return starting_string;
    }

    public static List<string> show_notes(string full_text_file)
    {
    
        full_text_file = full_text_file.Replace("\n","");


        if (!(full_text_file == "") && !(full_text_file == " "))
        {

            string[] notes = full_text_file.Split(separator);

            List<string> titles = new List<string>();

            for (int i = 0; i < notes.Length; i++)
            {
                string cim = notes[i].Split("&&")[0];
                Console.WriteLine();
                if (cim != " ")
                    titles.Add(cim);
            };

            return titles;
        }else 
        {
            return new List<string>();
        }

    }

    public static string decode_note(string encoded_string)
    {
        string[] szoveg = encoded_string.Split("&&");

        string full_szoveg = @$"
        {Note.decode_string(szoveg[0])}
        ===================================================
        {Note.decode_string(szoveg[1])}
        ===================================================
        {Note.decode_string(szoveg[2])}                        {Note.decode_string(szoveg[3])}    
        ";

        return full_szoveg;
    }
}

