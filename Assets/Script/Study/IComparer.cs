using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAge
{
    public string Name { get; set; }
    public int age { get; set; }

    public PlayerAge(string name, int age)
    {
        Name = name;
        this.age = age;
    }

}
public class PlayerAgeCompare : IComparer<PlayerAge>
{
    public int Compare(PlayerAge x, PlayerAge y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentException("Cannot compare null values.");
        }
        if (x.age < y.age)
        {
            return -1;
        }
        else if (x.age > y.age) { return 1; }
        else { return 0; }
      //  If x.Age is less than y.Age, return -1.
          //If x.Age is greater than y.Age, return 1.
      //If x.Age is equal to y.Age, return 0
    }
}

public class IComparer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
