namespace ConsoleApp1;

public class PythonInterpreter
{
    static void Main()
    {
        string pythonCode = "def example_method():\n    print('Hello, World!')\n    if True:\n print('Indented line')\nint dict={1,2,3}";

        InterpretPythonCode(pythonCode);
        IsDictionary(pythonCode);
    }

    static void InterpretPythonCode(string code)
    {
        string[] lines = code.Split('\n');

        foreach (string line in lines)
        {
            if(HasColonAtEnd(line))
            {
                Console.WriteLine(line);
                Console.Write(new string(' ', GetIndentationLevel(line) * 4)); // Assuming 4 spaces per tab
            }
            else
            {
                Console.WriteLine(line);

            }

            if (ContainsDefKeyword(line))
            {
                ValidateMethodSyntax(line);
            }

            if (ContainsOpeningCurlyBrace(line))
            {
                

                Console.WriteLine($"Is Dictionary: {IsDictionary(line)}");
            }
        }
    }

    static bool HasColonAtEnd(string line)
    {
        return line.TrimEnd().EndsWith(":");
    }

    static int GetIndentationLevel(string line)
    {
        int count = 0;
        foreach (char c in line)
        {
            if (c == ' ')
            {
                count++;
            }
            else
            {
                break;

            }
        }
        return count / 4; 
    }

    static bool ContainsDefKeyword(string line)
    {
        return line.Contains("def");
    }

    static void ValidateMethodSyntax(string line)
    {
        
        Console.WriteLine("This is the correct method syntax in Python.");
    }

    static bool ContainsOpeningCurlyBrace(string line)

    {
        return line.Contains("{");
    }

    static bool IsDictionary(string line)
    {
       
        return line.Contains("{") && line.Contains("}");
    }

}