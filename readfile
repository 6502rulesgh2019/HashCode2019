using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
namespace ConsoleApp5
{
    public class Program
    {

        public static void Main(string[] args)
        {

            int maxlength = 0, maxwidth = 0, currentlength, count = 0;
            string append = "", currentLine;

            StreamReader csvFile = new StreamReader("C:/Users/Student/Downloads/e_shiny_selfies.txt");
            while ((currentLine = csvFile.ReadLine()) != null)
            {
                string[] lineString = currentLine.Split(' ');
                for (int i = 1; i < lineString.Length; i++)
                {

                    currentlength = Int32.Parse(lineString[1]);
                    if (maxwidth < currentlength)
                    {
                        maxwidth = currentlength;
                    }
                }
                maxlength++;
            }
            string[,] Picture = new string[4, maxlength];
            string[] Tags = new string[maxlength];

            StreamReader File = new StreamReader("C:/Users/Student/Downloads/e_shiny_selfies.txt");
            while ((currentLine = File.ReadLine()) != null)
            {
                string[] lineString = currentLine.Split(' ');
                Picture[0, count] = count.ToString();

                for (int i = 1; i < lineString.Length; i++)
                {
                    if (i > 2)
                    {
                        Picture[3, count] = "0";
                        append += lineString[i - 1];
                        append += " ";

                        continue;
                    }
                    Picture[i, count] = lineString[i - 1];
                }

                Tags[count] = append;
                append = "";
                count++;

            }
        }
    }    
}
