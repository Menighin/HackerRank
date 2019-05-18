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

    // Complete the whatFlavors function below.
    static void whatFlavors(int[] cost, int money) {
        
        var costMap = cost
            .Select((o, i) => new { Index = i, Value = o })
            .GroupBy(g => g.Value)
            .ToDictionary(k => k.Key, v => v.Select(x => (int?) x.Index).ToList());

        for (var i = 0; i < cost.Length; i++) {
            var sunny = cost[i];
            var johnny = money - sunny;

            if (costMap.ContainsKey(johnny)) {
                var j = costMap[johnny].FirstOrDefault(o => o != i);
                
                if (j == null) continue;

                Console.WriteLine($"{i + 1} {j + 1}");
                return;
            }
        }

    }

    static void Main(string[] args) {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int money = Convert.ToInt32(Console.ReadLine());

            int n = Convert.ToInt32(Console.ReadLine());

            int[] cost = Array.ConvertAll(Console.ReadLine().Split(' '), costTemp => Convert.ToInt32(costTemp))
            ;
            whatFlavors(cost, money);
        }
    }
}
