using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexico0
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Archivos a = new Archivos())
                {
                    while (!a.FinArchivo())
                    {
                        a.Palabra();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //x = 200;
            Console.ReadKey();
        }
    }

    
}
