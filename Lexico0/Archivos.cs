using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lexico0
{
    class Archivos : IDisposable
    {
        StreamReader archivo;
        StreamWriter bitacora;

        public Archivos()
        {
            Console.WriteLine("Compilando el archivo Prueba.txt...");
            if (File.Exists("C:\\Archivos\\Prueba.txt"))
            {
                archivo = new StreamReader("C:\\Archivos\\Prueba.txt");
                bitacora = new StreamWriter("C:\\Archivos\\Prueba.log");
                bitacora.AutoFlush = true;
                bitacora.WriteLine("Archivo: Prueba.txt");
                bitacora.WriteLine("Directorio: C:\\Archivos");
            }
            else
            {
                throw new Exception("El archivo Prueba.txt no existe");
            }
        }
        //~Archivos()
        public void Dispose()
        {
            CerrarArchivos();
            Console.WriteLine("Finaliza compilacion de Prueba.txt");
        }
        private void CerrarArchivos()
        {
            archivo.Close();
            bitacora.Close();
        }
        public void Display()
        {
            while (!archivo.EndOfStream)
            {
                Console.Write((char)archivo.Read());
            }
        }
        public void Display2()
        {
            while (!archivo.EndOfStream)
            {
                Console.Write((char)archivo.Peek());
                archivo.Read();
            }
        }
        public void Load()
        {
            while (!archivo.EndOfStream)
            {
                bitacora.Write((char)archivo.Read());
            }
        }
        public void Encrypt()
        {
            while (!archivo.EndOfStream)
            {
                char c;
                if (char.IsLetter(c = (char)archivo.Read()))
                {
                    bitacora.Write((char)(c+1));
                }
                else
                {
                    bitacora.Write(c);
                }
            }
        }
        public void Encrypt(char letra)
        {
            while (!archivo.EndOfStream)
            {
                char c;
                if (char.IsLetter(c = (char)archivo.Read()))
                {
                    if(c=='a' || c=='e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                        bitacora.Write((char)(c=letra));
                    else
                        bitacora.Write((char)(c));
                }
                else
                {
                    bitacora.Write(c);
                }
            }
        }
        public void Palabra()
        {
            char c;
            string palabra = "";

            while (char.IsWhiteSpace(c = (char)archivo.Read()))
            {
            }
            if (char.IsLetter(c))
            {
                palabra += c; //palabra = palabra + c;
                while (char.IsLetter(c = (char)archivo.Read()))
                {
                    palabra += c;
                }
                bitacora.WriteLine("palabra = " + palabra);
            }
        }
        public void Token()
        {
            char c;
            string palabra = "";

            while (char.IsWhiteSpace(c = (char)archivo.Read()))
            {
            }
            palabra += c; //palabra = palabra + c;
            if (char.IsLetter(c))
            {
                while (char.IsLetter(c = (char)archivo.Peek()))
                {
                    palabra += c;
                    archivo.Read();
                }
            }
            else if (char.IsDigit(c))
            {
                while (char.IsDigit(c = (char)archivo.Peek()))
                {
                    palabra += c;
                    archivo.Read();
                }
            }
            bitacora.WriteLine("token = " + palabra);
        }
        public bool FinArchivo()
        {
            return archivo.EndOfStream;
        }
    }
}
