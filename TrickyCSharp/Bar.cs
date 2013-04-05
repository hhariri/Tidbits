using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrickyCSharp.Orcs
{
  public class Bar<T>
  {
    [ThreadStatic]
    public ConcurrentDictionary<int, float> rates;

    private static int range;

    private string text;
    private int value;

    public Bar(int n) : this("Chuck Norris")
    {
      value = n;
    }

    Bar(string s) : this(0)
    {
      text = s;
    }

    public void Print(string s)
    {
      s.Replace(" ", "_");
      int value = s.Length;
      if (s != null && s.Length != 0)
        Console.WriteLine(s + " " + value);
    }

    public float Sum(float[,] array)
    {
      float sum = 0.0f;
      for (int i = 0; i < array.GetLength(0); ++i)
        for (int j = 0; j < array.GetLength(1); ++i)
          sum += array[i, j];
      return sum;
    }

    public void Product(float [] numbers)
    {
      // try converting to linq :)
      float c = 1;
      for (int i = 0; i < numbers.Length; ++i)
        c *= numbers[i];
      //return c;
    }
  }

  [TestFixture]
  public class BarTest
  {
    [Test]
    public void Construction()
    {
      new Bar<string>(10);
    }
  }
}