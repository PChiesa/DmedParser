using System;
using System.IO;
using System.Text.RegularExpressions;

namespace dmed_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("CMA DMED.txt");
            string line;

            const int CPF = 1;
            const int NOME = 2;
            const int VALOR = 7;

            do
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    var infoArray = line.Split("\t");
                    var cpf = infoArray[CPF].Replace(".", "").Replace("-", "");
                    var nome = infoArray[NOME];
                    string valor = infoArray[VALOR];

                    if (infoArray[VALOR].IndexOf(".") > -1 || infoArray[VALOR].IndexOf(",") > -1)
                    {
                        valor = infoArray[VALOR].Replace(".", "").Replace(",", "");
                    }
                    else
                    {
                        valor = infoArray[VALOR] + "00";
                    }

                    System.Console.WriteLine($"RPPSS|{cpf}|{nome}|{valor}");
                }

            } while (line != null);

            sr.Dispose();

        }
    }
}
