using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MainHashCode
{
    class Program
    {
        static int startingID = 0;
        static string currentImage;
        static int maxlength = 0;
        static int count = 0;

        static void Main(string[] args)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;

            
            string append = "", currentLine;

            StreamReader InputFile = new StreamReader(@"e_shiny_selfies.txt");
            while ((currentLine = InputFile.ReadLine()) != null)
            {
                maxlength++;
            }
            maxlength -= 1;
            string[,] Picture = new string[4, maxlength];
            string[] Tags = new string[maxlength];

            while ((currentLine = InputFile.ReadLine()) != null)
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
            InputFile.Close(); 
            if (File.Exists(@"slideshow.txt"))
            {
                File.Delete(path);
            }
            StreamWriter tw = new StreamWriter(path, true);
            CreateSlideShow(0, Picture[0,0], Picture[1,0],ref Picture,ref Tags, ref tw);
            tw.Close();
        }

        static string ImageCompare(int ID,string tags, int noTags, char orientation)
        {
            return "Blah";
        }


        static void CreateSlideShow(int currentIteration, string ID,string Orientation,ref string[,] Picture,ref string[] tags, ref StreamWriter tw)
        {
            if(maxlength == currentIteration)
            {
                Console.WriteLine("I am finished! Slide show created!");
            }
            else
            {
                currentImage = ImageCompare(Convert.ToInt32(ID), tags[Convert.ToInt32(ID)], 0, Convert.ToChar(Orientation));
                if(currentImage.Contains(" "))
                {
                    string[] twoIDs = currentImage.Split(' ');
                    tw.WriteLine(twoIDs[0] + " " + twoIDs[1]);
                    currentImage = twoIDs[0];
                    Picture[3, Convert.ToInt32(twoIDs[0])] = "1";
                    Picture[3, Convert.ToInt32(twoIDs[1])] = "1";
                }
                else
                {
                    tw.WriteLine(currentImage);
                    Picture[3, Convert.ToInt32(currentImage)] = "1";
                }
                CreateSlideShow(currentIteration++, currentImage, Picture[3, Convert.ToInt32(currentImage)], ref Picture, ref tags, ref tw);
            }
        }
    }
}
