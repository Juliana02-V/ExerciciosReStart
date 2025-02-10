using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListVersusDictionary
{
    private const int NumElements = 1000;
    private readonly Random _rnd;
    private readonly int[] _keys;
    private readonly List<int> _list;
    private readonly Dictionary<int, string> _dict;

    public ListVersusDictionary()
    {
        _rnd = new Random();
        _keys = GetKeys(NumElements).ToArray();


        _list = new List<int>();
        foreach (var key in _keys)
        {
            _list.Add(key);
        }

        _dict = _keys.ToDictionary(key => key, key => $"Value_{key}");
    }

    [Benchmark]
    public int GetValueFromList()
    {
        var key = RandomKey();

        return _list.FirstOrDefault(item => item == key);
        //Console.WriteLine(key);
    }

    [Benchmark]
    public string GetValueFromDictionary()
    {
        var key = RandomKey();
        _dict.TryGetValue(key, out var value);
        return value;
        //Console.WriteLine(key);
    }

    [Benchmark]
    public int GetValueFromLinq()
    {
        var key = RandomKey();
        return _list.FirstOrDefault(x => x == key);
        // Console.WriteLine(key);
    }


    private int RandomKey()
    {
        return _keys[_rnd.Next(_keys.Length)];
    }

    private IEnumerable<int> GetKeys(int numElements)
    {
        for (int i = 0; i <= numElements; i++)
        {
            yield return _rnd.Next();
            //Console.WriteLine(i);
        }
    }
}






