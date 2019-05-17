using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note) {

        var notesDict = note
            .GroupBy(g => g)
            .ToDictionary(k => k.Key, v => new [] { v.Count(), 0 });
        
        foreach (var w in magazine)
        {
            if (notesDict.ContainsKey(w))
                notesDict[w][1]++;
        }

        foreach (var w in notesDict.Keys)
        {
            if (notesDict[w][0] > notesDict[w][1])
            {
                Console.WriteLine("No");
                return;
            }
        }

        Console.WriteLine("Yes");
    }

    static void Main(string[] args) {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
