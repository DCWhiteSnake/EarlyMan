using System.ComponentModel.DataAnnotations;
namespace EarlyMan.ViewModels
{
        public class ErrorPageViewModel
        {
                private string _message;
                private int _code;
                [Range(100, 511)]
                public int Code { get { return _code; } set { _code = value; } }
                public string Message
                {
                        get
                        {
                                return _message;
                        }
                        set
                        {
                                _message = Escape(value);
                        }
                }

                public string Src
                {
                        get
                        {       
                                var firstLink = string.Concat("http://memegen.link/custom/",_code.ToString(), "/", _message,
                                ".jpg?alt=https://i.imgur.com/CsCgN7Ll.png&width=400");
                                return firstLink;
                        }
                }
                /// <summary>
                /// Escape special characters.
                /// https://github.com/jacebrowning/memegen#special-characters
                /// </summary>
                /// <param name="message">The error message</param>
                /// <returns>The mutated string</returns>
                public static string Escape(string message)
                {
                        Dictionary<string, string> charMap = new()
                        {{"-", "--"}, {" ", "-"}, {"_", "__"}, {"?", "~q"},
                        {"%", "~p"}, {"#", "~h"}, {"/", "~s"}, {"\"", "''"}};
                        // int count = 1;
                        foreach (char c in message)
                        {
                                // if (count++ % 2 == 0)
                                //         continue;
                                try
                                {
                                        message = message.Replace(c.ToString(), charMap[c.ToString()]);
                                }
                                catch
                                {
                                        continue;
                                }
                        }
                        return message;
                }
        }

}