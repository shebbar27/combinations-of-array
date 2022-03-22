using System;
using System.Collections.Generic;
using System.Linq; 
 
class Program
{
    static void getCombinationsOfGivenSize(IList<char> characters, IList<char> combinations, int start, int end, int currentIndex, int sizeOfCombinations, ref List<List<char>> result)
    {
        if (currentIndex == sizeOfCombinations)
        {
            List<char> temp = new List<char>();
            for (int j = 0; j < sizeOfCombinations; j++)
            {
                temp.Add(combinations[j]);
            }

            result.Add(temp);
            return;
        }
 
        for (int i = start; i <= end && end - i + 1 >= sizeOfCombinations - currentIndex; i++)
        {
            combinations[currentIndex] = characters[i];
            getCombinationsOfGivenSize(characters, combinations, i + 1, end, currentIndex + 1, sizeOfCombinations, ref result);
        }
    }
 
    static void printAllPossibleCombinations(IList<char> characters, int sizeOfCombinations, ref List<List<char>> result)
    {
        IList<char> combinations = Enumerable.Repeat(' ', sizeOfCombinations).ToList<char>();
 
        getCombinationsOfGivenSize(characters, combinations, 0, characters.Count - 1, 0, sizeOfCombinations, ref result);
    }
    
    static public void Main ()
    {
        IList<char> characters = new List<char>() {
            'a',
            'b',
            'c',
            'd',
            //'e',
        };

        List<List<char>> result = new List<List<char>>();
        for(int sizeOfCombinations=0; sizeOfCombinations <= characters.Count; sizeOfCombinations++) 
        {
            printAllPossibleCombinations(characters, sizeOfCombinations, ref result);
        }

        foreach(var list in result) 
        {
            foreach(var ch in list) 
            {
                Console.Write(ch + " ");
            }

            Console.WriteLine();
        }
    }
}