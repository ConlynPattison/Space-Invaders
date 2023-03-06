using System;
using UnityEngine;

public class EnemyComplete : MonoBehaviour
{

    public int scorePerHit = 0;

    public delegate void EnemyDestroyed(int score);
    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed;
    //-----------------------------------------------------------------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    
        OnEnemyAboutToBeDestroyed(scorePerHit);
        // todo - trigger death animation
        Destroy(collision.gameObject); // destroy bullet
        Destroy(gameObject);
    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     Debug.Log("Ouch!");
    //
    //     // todo - trigger death animation
    //     OnEnemyAboutToBeDestroyed(50);
    //     Destroy(col.gameObject); // destroy bullet
    // }
}
