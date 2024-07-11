using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using UnityEngine;

public class SampleClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public void PrintInfo()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }
}

public class Reflection : MonoBehaviour
{
    // type is an instance of the Type class, and it holds metadata information about the SampleClass.
   
    void Start()
    {
        // It represents the metadata of a property in a class.
        //Purpose: Represents an entire type (class, interface, enum, etc.).
        //here print class name
        Type type = typeof( SampleClass );
      Debug.Log($"Type Name: {type.Name}");

        // //Type and PropertyInfo store metadata, but they serve different
        //Represents a single property of a type.
        //Type of the property (e.g., int, string).
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            // print variable name
            Debug.Log(property.Name);
            //variable type
            Debug.Log(property.PropertyType.Name);
        }
        SampleClass sampleClass = new SampleClass();    
        
        PropertyInfo nameProperty= type.GetProperty("Name");
        nameProperty.SetValue(sampleClass,"aj");
        string name = (string)nameProperty.GetValue(sampleClass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
