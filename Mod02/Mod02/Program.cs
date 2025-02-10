using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Mod02;

namespace MyBenchmarks;

class Program
{
    static void Main(string[] args)
    {

        BenchmarkRunner.Run<ListVersusDictionary>();

        //list.GetValueFromDictionary();
        //list.GetValueFromList();
        //list.GetValueFromLinq();

    }
}



