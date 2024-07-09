using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public virtual void Speak() => Console.WriteLine("Animal speaks");

}
public class dog: Animal
{

    public override void Speak() => Console.WriteLine("Dog speak");
}
public delegate Animal AnimalDelegate();
public class GameManager : MonoBehaviour
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
