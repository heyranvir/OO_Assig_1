using System;

namespace Assignment
{
    public static class ArrayReplicator
    {
        /// <summary>
        /// Replicates (deep copies) the incoming array
        /// </summary>
        /// <param name="original">The array to be replicated</param>
        /// <returns>A deep copy of the original array</returns>
        public static int[] ReplicateArray(int[] original_Array)
        {   
            int[] deepCopiedArray = new int[original_Array.Length];

            for (int i = 0; i < original_Array.Length; ++i)
            {
                deepCopiedArray[i] = original_Array[i];
            }
            return deepCopiedArray;
        }

        /// <summary>
        /// Asks the user for a number. Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="prompt">Text to prompt the user</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumber(string prompt)
        {
            Console.WriteLine(prompt);

            return ReadNumber();
        }

        /// <summary>
        /// Asks the user for a number within a certain range [min, max]. If the number is not in the range, re-prompt the user for a new number.
        /// Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="prompt">Text to prompt the user</param>
        /// <param name="min">Smallest permissible value</param>
        /// <param name="max">Largest permissible value</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumberInRange(string prompt, int min, int max)
        {
            bool Range = true;
            int userValue = -1;
            while (Range)
            {
                userValue = AskForNumber(prompt);
                if (userValue >= min && userValue <= max)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Please Enter a value between [{min}, {max}] only.");
                }
            }
            return userValue;
        }

        /// <summary>
        /// Read input and convert it to an integer value. If the value format cannot be converted, prompt again until a correct value is entered.
        /// </summary>
        /// <returns>An integer value entered by the user</returns>
        private static int ReadNumber()
        {
            int UserNumber = 0;

            while (true)
            {
                try
                {
                    UserNumber = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Please enter only numbers!!! No alphabebts or Special characters.");
                }
            }

            return UserNumber;
        }
    }

    static class Program
    {
        static void Main()
        {
            const int MinSize = 0;
            const int MaxSize = 10;
            const int PrintOffset = 4;

            int SizeOfArray = ArrayReplicator.AskForNumberInRange("Enter the array size: ", MinSize, MaxSize);

            int[] originalArray = new int[SizeOfArray];

            for (int item = 0; item < SizeOfArray; ++item)
            {
                originalArray[item] = ArrayReplicator.AskForNumber($"Enter number for position {item}: ");
            }

            int[] copiedArray = ArrayReplicator.ReplicateArray(originalArray);

            for (int IndexNumber = 0; IndexNumber < SizeOfArray; ++IndexNumber)
            {
                Console.WriteLine($"Original {originalArray[IndexNumber],-PrintOffset}  {copiedArray[IndexNumber],4} Copy");
            }

            Console.ReadLine();
        }
    }
}
