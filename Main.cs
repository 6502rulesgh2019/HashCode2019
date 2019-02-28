using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

            StreamReader InputFile = new StreamReader(@"b_lovely_landscapes.txt");
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
            StreamWriter tw = new StreamWriter(@"slideshow.txt", true);
            CreateSlideShow(0, "0", Picture[1,0],ref Picture,ref Tags, ref tw);
            tw.Close();
        }

        static string Imagecompare(int ID, ref string[] tags, ref string[,] picture, int maxlength)
        {
            string[] comparisonimagetagarray = new string[30];
            string[] currentimagetagarray = new string[30];

            int currentimageid = ID; // this will be called though array
            int currentimagetagid = 0; // in realtiy this will == passed objects first tag but for now
            int currentimagenotags = Convert.ToInt32(picture[2, currentimageid]);

            int comparisonimageid = 0; // in reality this will be a counter 
            int comparisonimagenotags = 0;
            int comparisonimagetagod = 0;

            
            bool comparisonimageused = false;

            int totalnumberofimages = maxlength;

            int commontags = 0;
            int comparrisonnotcurrenttag = 0;
            int currenthascomparrisontag = 0;
            int totalscore = 0;


            int vbestscoreid = 0;
            int bestscoreid = 0;
            string bestScoreString = "0";
            int bestscore = 0;

            bool tagfound = false;
            bool V = false;

            

            if (picture[3, comparisonimageid] == "0")
            {
                comparisonimageused = false;
            }
            else
            {
                comparisonimageused = true;
            }

            if (picture[1, comparisonimageid] == "0")
            {
                V = false;
            }
            else
            {
                V = false;
            }

            for (int q = 0; q < currentimagenotags; q++) // this gets all the tags in the current tag id and stores it in an array
            {
                string temp = "";
                foreach (char item in tags[comparisonimageid])
                {
                    temp = "";
                    if (Convert.ToString(item) == "32")
                    {
                        continue;
                    }
                    temp = temp + item;
                }
                currentimagetagarray[q] = temp; // reads in each 3 digit and saves the temp until space 
            }



            for (int i = 0; i < totalnumberofimages; i++)// compares all currents tags to all other images 
            {
                comparisonimageid = i;
                if (comparisonimageused == true || currentimageid == comparisonimageid)  // if it 
                {
                    continue; // or continue , wants it to skip
                }


                for (int q = 0; q < Convert.ToInt32(picture[2, comparisonimageid]); q++) // this gets all the tags in the comparrison tag id and stores it in an array
                {
                    comparisonimageid = q;

                    string temp = "";
                    foreach (char item in tags[comparisonimageid])
                    {
                        temp = "";
                        if (Convert.ToString(item) == "32")
                        {
                            continue;
                        }
                        temp = temp + item;
                    }
                    comparisonimagetagarray[q] = temp;
                    // reads in each 3 digti and saves the temp until space 
                }

                for (int j = 0; j < currentimagenotags; j++)// compares all current tags to all comparison tags
                {
                    currentimagetagid = j;
                    for (int k = 0; k < comparisonimagenotags; k++)// compares current tags to all the other tags , so this chages its 
                    {
                        comparisonimagetagod = k;

                        if (currentimagetagarray[currentimagetagid] == comparisonimagetagarray[comparisonimagetagod]) // t23 == t34 for example 
                        {
                            commontags += 0;
                            tagfound = true;
                        }
                        else
                        {
                            comparrisonnotcurrenttag += 1;
                        }


                    }
                }

                for (int j = 0; j < comparisonimagenotags; j++)// comparing all current tags against one comparrison for the third condidtion
                    currentimagetagid = j;
                for (int k = 0; k < currentimagenotags; k++)// compares current tags to all the other tags , so this chages its 
                {
                    currenthascomparrisontag = k;

                    if (currentimagetagarray[currentimagetagid] != comparisonimagetagarray[comparisonimagetagod]) // t23 == t34 for example 
                    {
                        currenthascomparrisontag += 1;
                    }


                }
                totalscore = commontags + comparrisonnotcurrenttag + currenthascomparrisontag;
                if (bestscore < totalscore && tagfound == true)
                {
                    bestscoreid = comparisonimageid;
                }
                tagfound = false;
            }


            if (V == true)
            {
                //if its v then
                picture[3, bestscoreid] = "1";
                //  do it all again but the id of best score id becomes used 
                comparisonimagetagarray = new string[30];
                currentimagetagarray = new string[30];

                currentimageid = bestscoreid; // this will be called though array
                currentimagetagid = 0; // in realtiy this will == passed objects first tag but for now
                currentimagenotags = Convert.ToInt32(picture[2, currentimageid]);

                comparisonimageid = 0; // in reality this will be a counter 
                comparisonimagenotags = 0;
                comparisonimagetagod = 0;
                
                totalnumberofimages = maxlength;

                commontags = 0;
                comparrisonnotcurrenttag = 0;
                currenthascomparrisontag = 0;
                totalscore = 0;


                bestscoreid = 0;
                bestscore = 0;

                tagfound = false;
                V = false;




                for (int q = 0; q < currentimagenotags; q++) // this gets all the tags in the current tag id and stores it in an array
                {
                    string temp = "";
                    foreach (char item in tags[comparisonimageid])
                    {
                        temp = "";
                        if (Convert.ToString(item) == "32")
                        {
                            continue;
                        }
                        temp = temp + item;
                    }
                    currentimagetagarray[q] = temp; // reads in each 3 digit and saves the temp until space 
                }



                for (int i = 0; i < totalnumberofimages; i++)// compares all currents tags to all other images 
                {
                    comparisonimageid = i;
                    if (comparisonimageused == true | currentimageid == comparisonimageid)  // if it 
                    {
                        continue; // or continue , wants it to skip
                    }


                    for (int q = 0; q < Convert.ToInt32(picture[2, comparisonimageid]); q++) // this gets all the tags in the comparrison tag id and stores it in an array
                    {
                        comparisonimageid = q;

                        string temp = "";
                        foreach (char item in tags[comparisonimageid])
                        {
                            temp = "";
                            if (Convert.ToString(item) == "32")
                            {
                                continue;
                            }
                            temp = temp + item;
                        }
                        comparisonimagetagarray[q] = temp;
                        // reads in each 3 digti and saves the temp until space 
                    }

                    for (int j = 0; j < currentimagenotags; j++)// compares all current tags to all comparison tags
                    {
                        currentimagetagid = j;
                        for (int k = 0; k < comparisonimagenotags; k++)// compares current tags to all the other tags , so this chages its 
                        {
                            comparisonimagetagod = k;

                            if (currentimagetagarray[currentimagetagid] == comparisonimagetagarray[comparisonimagetagod]) // t23 == t34 for example 
                            {
                                commontags += 0;
                                tagfound = true;
                            }
                            else
                            {
                                comparrisonnotcurrenttag += 1;
                            }


                        }
                    }

                    for (int j = 0; j < comparisonimagenotags; j++)// comparing all current tags against one comparrison for the third condidtion
                        currentimagetagid = j;
                    for (int k = 0; k < currentimagenotags; k++)// compares current tags to all the other tags , so this chages its 
                    {
                        currenthascomparrisontag = k;

                        if (currentimagetagarray[currentimagetagid] != comparisonimagetagarray[comparisonimagetagod]) // t23 == t34 for example 
                        {
                            currenthascomparrisontag += 1;
                        }


                    }
                    totalscore = commontags + comparrisonnotcurrenttag + currenthascomparrisontag;
                    if (vbestscoreid < totalscore && tagfound == true)
                    {
                        vbestscoreid = comparisonimageid;
                    }
                    tagfound = false;
                }
                bestScoreString = bestscoreid.ToString() + " " + vbestscoreid.ToString(); ;
            }


            return (bestScoreString);
        }


    static void CreateSlideShow(int currentIteration, string ID,string Orientation,ref string[,] Picture,ref string[] tags, ref StreamWriter tw)
        {
            if(maxlength == currentIteration)
            {
                Console.WriteLine("I am finished! Slide show created!");
            }
            else
            {
                currentImage = Imagecompare(Convert.ToInt32(ID),ref tags,ref Picture, maxlength);
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
