using System;
using UnityEngine;

public class EnemyComplete : MonoBehaviour
{
    public delegate void EnemyDestroyed(int score);
    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed;
    //-----------------------------------------------------------------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    
        OnEnemyAboutToBeDestroyed(50);
        // todo - trigger death animation
        Destroy(collision.gameObject); // destroy bullet
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
