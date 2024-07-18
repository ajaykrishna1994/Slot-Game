using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalMoney
{
    public int Totalearning {  get; set; }    
}
public class SeaonBonus
{
    public int bonus { get; set; }
}
public interface ICovariant<out T>
{
    T GetItem();
}
public class MoneyManager: ICovariant<SeaonBonus>
{
    private SeaonBonus SeaonBonus;
    public MoneyManager(SeaonBonus seaonBonus)
    {
        SeaonBonus = seaonBonus;
    }
    public SeaonBonus GetItem()
    {
        return SeaonBonus;

    }
}
public class CashCollecter
{
    public virtual void Speak() => Console.WriteLine("start");

}
public class dog: CashCollecter
{

    public override void Speak() => Console.WriteLine("win");
}
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
