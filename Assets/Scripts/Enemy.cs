using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public delegate void EnemyDestroyed(int score=0); // new custom type

    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed; // mechanism for publishing what happened for those subscribed

    public int pointValue = 50;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      
      OnEnemyAboutToBeDestroyed(50);
      OnEnemyAboutToBeDestroyed.Invoke();

      Destroy(gameObject);
    }
}
