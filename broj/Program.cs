using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        
        var digits = Enumerable.Range(1, 9).ToArray();
        var permutations = GetPermutations(digits, digits.Length);

        foreach (var perm in permutations)
        {
           
            var number = int.Parse(string.Join("", perm));

            
            if (IsValid(number))
            {
                Console.WriteLine($"Pronađeni broj: {number}");
                break; 
            }
        }
    }

    static IEnumerable<IEnumerable<T>> GetPermutations<T>(T[] list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });
        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                        (t1, t2) => t1.Concat(new T[] { t2 }));
    }

    static bool IsValid(int number)
    {
        
        for (int i = 9; i >= 1; i--)
        {
            if (number % i != 0)
            {
                return false;
            }
            number /= 10; 
        }
        return true;
    }
}
