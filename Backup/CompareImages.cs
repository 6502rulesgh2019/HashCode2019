using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode2019
{
    class Program
    {
        static int Imagecompare(int ID, int Notags, int tagsid, char orintateion, string[] tags, string [,]picture, int maxlength)
        {
            string[] comparisonimagetagarray = new string[30];
            string[] currentimagetagarray = new string[30];

            int currentimageid = ID; // this will be called though array
            int currentimagetagid = 0; // in realtiy this will == passed objects first tag but for now
            int currentimagenotags = Notags;

            int comparisonimageid = 0; // in reality this will be a counter 
            int comparisonimagenotags = 0;
            int comparisonimagetagod = 0;

            string comparisonimageusedarray= picture[3, comparisonimageid];
            bool comparisonimageused = false;

            int totalnumberofimages = maxlength;

            int commontags = 0;
            int comparrisonnotcurrenttag = 0;
            int currenthascomparrisontag = 0;
            int totalscore = 0;


            int vbestscoreid = 0;
            int bestscoreid = 0;
            int bestscore = 0;

            bool tagfound = false;
            bool V = false;

            
                for (int q = 0; q < 30; q++) // this gets all the tags in the current tag id and stores it in an array
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


                    for (int q = 0; q < 30; q++) // this gets all the tags in the comparrison tag id and stores it in an array
                    {
                        comparisonimageid = i;

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

                
            if( V == true )
            {
                //if its v then
                picture[3, bestscoreid] = "1";
                //  do it all again but the id of best score id becomes used 
                comparisonimagetagarray = new string[30];
                currentimagetagarray = new string[30];

                currentimageid = bestscoreid; // this will be called though array
                currentimagetagid = 0; // in realtiy this will == passed objects first tag but for now
                currentimagenotags = Notags;

                comparisonimageid = 0; // in reality this will be a counter 
                comparisonimagenotags = 0;
                comparisonimagetagod = 0;
                comparisonimageusedarray = picture[3, comparisonimageid];
                totalnumberofimages = maxlength;

                commontags = 0;
                comparrisonnotcurrenttag = 0;
                currenthascomparrisontag = 0;
                totalscore = 0;


                bestscoreid = 0;
                bestscore = 0;

                tagfound = false;
                V = false;

                for (int q = 0; q < 30; q++) // this gets all the tags in the current tag id and stores it in an array
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


                    for (int q = 0; q < 30; q++) // this gets all the tags in the comparrison tag id and stores it in an array
                    {
                        comparisonimageid = i;

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
                bestscoreid = bestscoreid + vbestscoreid;
            }


                return (bestscoreid);
            }
            

        }


}


    



