using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Presentation.Util
{
    public class InputValidator
    {
        private static InputValidator? _instance = null;

        public static InputValidator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InputValidator();
            }
            return _instance;
        }

        public int GetValidInt(string request)
        {
            while (true)
            {
                try
                {
                    string? input = GetValidInput(request);
                    return input switch
                    {
                        "--q" => -1,
                        null => throw new NullReferenceException(),
                        _ => int.Parse(input)
                    };
                }
                catch
                {
                    //Console.WriteLine(e.ToString());
                    Console.WriteLine("\nPlease Enter Valid Input");
                }
            }
        }

        public string GetValidKeySeperatedValues(string request, char separator)
        {
            while (true)
            {
                try
                {
                    string? input = GetValidInput(request);
                    return input switch
                    {
                        "--q" => input,
                        null => throw new NullReferenceException(),
                        _ => string.Join(separator, input.Replace(" ", "").Split(separator))
                    };
                }
                catch
                {
                    //Console.WriteLine(e.ToString());
                    Console.WriteLine("\nPlease Enter Valid Input");
                }
            }
        }

        public string GetValidInput(string request)
        {
            Console.Write($"\n{request} : ");
            return Console.ReadLine() ?? "--q";
        }
    }
}
