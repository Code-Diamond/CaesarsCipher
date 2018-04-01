using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Program
{
    static void Main(String[] args)
    {
        bool loopControl = true;
        while(loopControl)
        {
            Console.WriteLine("Welcome.  Type text to be cipherd..");
            string confidentialInformation = Console.ReadLine();
            int numberOfCharacters = confidentialInformation.Length;
            Console.WriteLine("Ok now give me a number for the rotation key..");
            string n = Console.ReadLine();
            try
            {
                int rotationKey = Convert.ToInt32(n);
                string hash = Encrypt(confidentialInformation, rotationKey, numberOfCharacters);
                Console.WriteLine("Ciphered text: ");
                Console.WriteLine("------------------------------------------------------\n" + hash + "\n------------------------------------------------------");
            }
            catch (Exception e) { Console.WriteLine("Incorrect Information entered. Try again.../n/n"); }
        }
        
        // Console.WriteLine(hash + "\n\n-----------\n\n");
        
        //Other test
        /*
            confidentialInformation = "xyz-abcdEFGHIJKLMNOpqrSt&u#*&)(*!#*&^%:{}0-=123vWxY-Z";
            numberOfCharacters = confidentialInformation.Length;
            rotationKey = 27;
            hash = Encrypt (confidentialInformation, rotationKey, numberOfCharacters);
            Console.WriteLine(confidentialInformation);
            Console.WriteLine(hash);
        */
    }
    public static string Encrypt(string confidentialInformation, int rotationKey, int numberOfCharacters)
    {
        string hash = "";
        for (int i = 0; i < numberOfCharacters; i++)
        {
            hash += Rotate(confidentialInformation[i].ToString(), rotationKey);
        }
        return hash;
    }

    public static string Rotate(string letter, int rotationKey)
    {
        int rKey = rotationKey;
        //Console.WriteLine("letter {0} and rotation key {1}", letter, rotationKey);]
        //Ensure that it stays within alphabetic characters.  If it's higher than 26 it will spill over to special characters
        while (rKey > 26)
        {
            rKey = rKey - 26;
        }

        char rotatedKey = RotationAlgo(letter, rKey);

        string rotatedKeyString = rotatedKey.ToString();

        //Console.WriteLine("The rotated Letter is {0} \n", rotatedKeyString);
        return rotatedKeyString;




    }

    public static char RotationAlgo(string letter, int rKey)
    {
        int asciiCharCode = (int)Convert.ToChar(letter);
        bool itsAnUpper = Char.IsUpper(letter[0]);
        bool itsALower = Char.IsLower(letter[0]);
        char rotatedKey;
        if (itsAnUpper)
        {
            //A=65 Z=90
            if (asciiCharCode + rKey > 90)
            {
                //Console.WriteLine("I'm a upper case letter with rotation key HIGHER OR EQUAL TO upper case z");
                int difference = 90 - asciiCharCode;
                rKey = rKey - difference;
                return rotatedKey = (char)(64 + rKey);
            }
            else
            {
                //Console.WriteLine("I'm a upper case letter with rotation key lower than upper case z");
                return rotatedKey = (char)(rKey + asciiCharCode);
            }
        }
        else if (itsALower)
        {
            //a=97 z=122
            if (asciiCharCode + rKey > 122)
            {
                //Console.WriteLine("I'm a lower case letter with rotation key HIGHER OR EQUAL TO lower case z");
                int difference = 122 - asciiCharCode;
                rKey = rKey - difference;
                return rotatedKey = (char)(96 + rKey);
            }
            else
            {
                //Console.WriteLine("I'm a lower case letter with rotation key lower than lower case z");
                return rotatedKey = (char)(rKey + asciiCharCode);
            }
        }
        else
        {
            //Console.WriteLine("I'm not EITHER capital letter or lowercase letter");
            return rotatedKey = (char)(asciiCharCode);
        }
    }
}
