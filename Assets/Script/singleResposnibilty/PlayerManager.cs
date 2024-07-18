using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public int health;
    public string playerName;
    // Start is called before the first frame update
    void Move()
    {
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, 0, move);
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            Debug.Log(playerName + " is dead");
        }
    }
    void Update()
    {
        Move();
        CheckHealth();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
public class PlayerData
{
    public string PlayerName { get; set; }
    public int Health { get; set; }
    public float Speed { get; set; }

    public PlayerData(string playerName, int health, float speed)
    {
        PlayerName = playerName;
        Health = health;
        Speed = speed;
    }
}
public class PlayerMovement
{
    //private PlayerData playerData;

    void Start()
    {
      //  playerData = GetComponent<Player>().Data;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
       // float move = Input.GetAxis("Vertical") * playerData.Speed * Time.deltaTime;
       // transform.Translate(0, 0, move);
    }
}
public class PlayerHealth
{
    private PlayerData playerData;

    void Start()
    {
        //playerData = GetComponent<Player>().Data;
    }

    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        if (playerData.Health <= 0)
        {
            Debug.Log(playerData.PlayerName + " is dead");
        }
    }

    public void TakeDamage(int damage)
    {
        playerData.Health -= damage;
    }
}
