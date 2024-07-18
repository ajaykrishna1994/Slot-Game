using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlotSymbol
{
    void Display();
}
public class Diamond : ISlotSymbol
{
    public void Display()
    {
        Debug.Log("cherry details"); 
    }
}
public class Crown: ISlotSymbol
{
    public void Display()
    {
        Debug.Log("Crown details");
    }
}

public class SlotMachine : MonoBehaviour
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
