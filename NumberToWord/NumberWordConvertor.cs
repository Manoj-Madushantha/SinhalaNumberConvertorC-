using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWord
{
    public static class NumberWordConvertor
    {

        private static int counter = 0;
        private static bool sep1 = false;
        private static bool sep2 = false;
        private static bool sep3 = false;
        private static bool entranceHundred = false;
        private static bool entranceThousand = false;
        private static bool OneThousandIdentifier = false;


        private static string[] unitMap = new string[20] { "බිංදුව", "එක", "දෙක", "තුන", "හතර", "පහ", "හය", "හත", "අට", "නවය", "දහය", "එකොලහ", "දොලහ", "දහතුන", "දාහතර", "පහලව", "දහසය", "දහහත", "දහඅට", "දහනවය" };
        private static string[] unitMapDup = new string[20] { "බිංදුව", "එක්", "දෙ", "තුන්", "හාර", "පන්", "හය", "හත්", "අට", "නව", "දස", "එකොලොස්", "දොලොස්", "දහතුන්", "දාහතර", "පහලොස්", "දහසය", "දහහත්", "දහඅට", "දහනව" };
        private static string[] tensMap = new string[10] { "බිංදුව", "දහය", "විස්ස", "තිහ", "හතලිහ", "පනහ", "හැට", "හැත්තෑව", "අසූව", "අනූව" };
        private static string[] tensMapDup = new string[10] { "බිංදුව", "දහ", "විසි", "තිස්", "හතලිස්", "පනස්", "හැට", "හැත්තෑ", "අසූ", "අනූ" };

        private static string[] tensMapEN = new string[10] { "zero", "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string[] unitMapEN = new string[20] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

       
        public static string ConvertSinhala(int number)
        {
            if (number > 0)
            {
                return NumberToWords(number, counter, sep1, sep2, sep3, entranceHundred, entranceThousand, 
                        OneThousandIdentifier) + "යි ";
            }
            else
            {
                if (number == 0)
                {
                    return "බිංදුවයි";
                }
                else
                {
                    return "සෘණ " + NumberToWords(Math.Abs(number), counter, sep1, sep2, sep3, 
                            entranceHundred, entranceThousand, OneThousandIdentifier) + "යි ";
                }
            }           
        }

        public static string ConvertEnglish(int number)
        {

            if (number > 0)
            {
                return NumberToWordsEN(number) ;
            }
            else
            {
                if (number == 0)
                {
                    return "Zero";
                }
                else
                {
                    return "minus " + NumberToWordsEN(Math.Abs(number));
                }
                             
            }
        }

        // NumberToWord() is conversion function of the number to sinhala words.
        // 
        // Parameters :
        // 
        // number - number to convert to word
        // Type : Integer
        // 
        // sep1   - use to separate internal number groups (level 1 separator)
        // Type : Boolean
        // 
        // sep2   - use to separate internal number groups (level 2 separator)
        // Type : Boolean
        // 
        // sep3   - use to separate internal number groups (level 3 separator)
        // Type : Boolean
        // 
        // EntranceHundred - use to identify the number is in hundred range to the function
        // Type : Boolean
        // 
        // EntranceThousand - use to identify the number is in thousand range to the function
        // Type : Boolean
        // 
        // OneThousandIdentifier - use to identify is the thousand is one thousand range
        // 
        // return - word
        // Type : String



        private static string NumberToWords(int number, int counter, bool sep1, bool sep2, bool sep3, bool entranceHundred, bool entranceThousand, bool oneThousandIdentifier)
        {
            string words = "";

            if ((int)Math.Floor((double)number / 1000000) > 0)
            {
                counter = counter + 1;

                if (number % 1000000 > 0)
                {
                    sep1 = false;
                }
                else
                {
                    sep1 = true;
                }
                if ((int)Math.Floor((double)number / 1000000) < 100)
                {
                    sep2 = false;
                }
                else
                {
                    sep2 = true;
                }
                if (sep1 == false)
                {
                    words = words + NumberToWords((int)Math.Floor((double)number / 1000000), counter , sep1, sep2, sep3, entranceHundred, entranceThousand, oneThousandIdentifier) + " මිලියන ";
                }
                else
                {
                    words = words + NumberToWords((int)Math.Floor((double)number / 1000000), counter , sep1, sep2, sep3, entranceHundred, entranceThousand, oneThousandIdentifier) + " මිලියනය ";
                }
                number = number % 1000000;
            }
            if ((int)Math.Floor((double)number / 1000) > 0)
            {
                counter = counter + 1;
                if (counter == 1)
                {
                    entranceThousand = true;
                }
                else
                {
                    entranceThousand = false;
                }
                if ((int)Math.Floor((double)number / 1000) == 1)
                {
                    oneThousandIdentifier = true;
                }
                else
                {
                    oneThousandIdentifier = false;
                }
                if (number % 1000 > 0)
                {
                    sep1 = false;
                }
                else
                {
                    sep1 = true;
                }
                if ((int)Math.Floor((double)number / 1000) < 100)
                {
                    sep2 = false;
                }
                else
                {
                    sep2 = true;
                }
                if ((int)Math.Floor((double)number / 1000) % 10 > 0)
                {
                    sep3 = false;
                }
                else
                {
                    sep3 = true;
                }
                if (sep1 == false)
                {
                    words = words + NumberToWords((int)Math.Floor((double)number / 1000), counter, sep1, sep2, sep3, entranceHundred, entranceThousand, oneThousandIdentifier) + " දහස් ";
                }
                else
                {
                    words = words + NumberToWords((int)Math.Floor((double)number / 1000), counter, sep1, sep2, sep3, entranceHundred, entranceThousand, oneThousandIdentifier) + " දහස ";
                }

                sep2 = false;

                entranceThousand = false;

                oneThousandIdentifier = false;

                number = number % 1000;

                if (number < 100)
                {
                    if (number % 10 > 0)
                    {
                        sep3 = false;
                    }
                    else
                    {
                        sep3 = true;
                    }
                }
            }
            if ((int)Math.Floor((double)number / 100) > 0)
            {
                counter = counter + 1;

                if (counter == 1)
                {
                    entranceHundred = true;
                }
                else
                {
                    entranceHundred = false;
                }
                if (number % 100 > 0)
                {
                    sep1 = false;
                }
                else
                {
                    if (sep2 == false)
                    {
                        sep1 = true;
                    }
                    else
                    {
                        sep1 = false;
                    }
                }
                if (sep1 == false)
                {
                    words = words + NumberToWords((int)Math.Floor((double)number / 100), counter, sep1, sep2, sep3, entranceHundred, entranceThousand, oneThousandIdentifier) + " සිය ";
                }
                else
                {
                    words = words + NumberToWords((int)Math.Floor((double)number / 100), counter, sep1, sep2, sep3, entranceHundred, entranceThousand, oneThousandIdentifier) + " සියය ";
                }

                number = number % 100;

                counter = counter + 1;

                if (number < 20)
                {
                    sep1 = true;
                }
                else
                {
                    if (number % 10 > 0)
                    {
                        sep1 = false;
                    }
                    else
                    {
                        sep1 = true;
                    }
                }
            }

            if (number > 0)
            {
                if (number < 20)
                {
                    if (counter > 0)
                    {
                        if (number == 1)
                        {
                            if (oneThousandIdentifier == false)
                            {
                                if (counter == 3 && sep1 == false)
                                {
                                    words = words + unitMapDup[number];
                                }
                                else
                                {
                                    words = words + unitMap[number];
                                }
                            }
                            else
                            {
                                if (counter == 1)
                                {
                                    words = words + unitMapDup[number];
                                }
                                else
                                {
                                    if (counter == 2)
                                    {
                                        words = words + unitMap[number];
                                    }
                                    else
                                    {
                                        if (counter == 3)
                                        {
                                            words = words + unitMap[number];
                                        }
                                        else
                                        {
                                            words = words + unitMapDup[number];
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (sep1 == false)
                            {
                                if (counter == 1)
                                {
                                    if (entranceThousand == false)
                                    {
                                        if (entranceHundred == false)
                                        {
                                            words = words + unitMap[number];
                                        }
                                        else
                                        {
                                            words = words + unitMapDup[number];
                                        }
                                    }
                                    else
                                    {
                                        words = words + unitMapDup[number];
                                    }
                                }
                                else
                                {
                                    if (counter == 2)
                                    {
                                        words = words + unitMapDup[number];
                                    }
                                    else
                                    {
                                        words = words + unitMap[number];
                                    }
                                }
                            }
                            else
                            {
                                if (entranceThousand == false)
                                {
                                    if (counter == 2)
                                    {
                                        if (entranceHundred == false)
                                        {
                                            words = words + unitMapDup[number];
                                        }
                                        else
                                        {
                                            words = words + unitMap[number];
                                        }

                                        entranceHundred = false;
                                    }
                                    else
                                    {
                                        if (entranceHundred == false)
                                        {
                                            words = words + unitMap[number];
                                        }
                                        else
                                        {
                                            words = words + unitMapDup[number];
                                        }
                                    }
                                }
                                else
                                {
                                    words = words + unitMapDup[number];
                                }
                            }
                        }
                    }
                    else
                    {
                        words = words + unitMap[number];
                    }
                }
                else
                {
                    if (sep1 == false && sep2 == false && sep3 == false)
                    {
                        if (number < 100 && counter == 0)
                        {
                            if (number % 10 > 0)
                            {
                                words = words + tensMapDup[(int)Math.Floor((double)number / 10)];
                            }
                            else
                            {
                                words = words + tensMap[(int)Math.Floor((double)number / 10)];
                            }
                        }
                        else
                        {
                            words = words + tensMapDup[(int)Math.Floor((double)number / 10)];
                        }
                    }
                    else
                    {
                        if (entranceThousand == false)
                        {
                            words = words + tensMap[(int)Math.Floor((double)number / 10)];
                        }
                        else
                        {
                            words = words + tensMapDup[(int)Math.Floor((double)number / 10)];
                        }
                    }
                    if (number % 10 > 0)
                    {
                        if (entranceThousand == false)
                        {
                            if (counter < 3)
                            {
                                words = words + unitMap[number % 10];
                            }
                            else
                            {
                                if (counter == 3)
                                {
                                    words = words + unitMap[number % 10];
                                }
                                else
                                {
                                    words = words + unitMapDup[number % 10];
                                }
                            }
                        }
                        else
                        {
                            if (number % 10 == 4)
                            {
                                words = words + unitMap[number % 10];
                            }
                            else
                            {
                                words = words + unitMapDup[number % 10];
                            }
                        }
                    }
                }
            }

            return words;
        }

        // English Version

        private static string NumberToWordsEN(int number)
        {
            string words = "";

            if ((int)Math.Floor((double)number / 1000000) > 0)
            {
                words = words + NumberToWordsEN((int)Math.Floor((double)number / 1000000)) + " million ";
                number = number % 1000000;
            }
            if ((int)Math.Floor((double)number / 1000) > 0)
            {
                words = words + NumberToWordsEN((int)Math.Floor((double)number / 1000)) + " thousand ";
                number = number % 1000;
            }
            if ((int)Math.Floor((double)number / 100) > 0)
            {
                words = words + NumberToWordsEN((int)Math.Floor((double)number / 100)) + " hundred ";
                number = number % 100;
            }
            if (number > 0)
            {
                if (words != "")
                {
                    words = words + " and ";
                }

                if (number < 20)
                {
                    words = words + unitMapEN[number];
                }
                else
                {
                    words = words + tensMapEN[(int)Math.Floor((double)number / 10)];

                    if (number % 10 > 0)
                    {
                        words = words + "-" + unitMapEN[number % 10];
                    }
                }
            }

            return words;
        }

    }
}
