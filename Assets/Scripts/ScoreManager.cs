using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyComplete.OnEnemyAboutToBeDestroyed += EnemyOnOnEnemyAboutToBeDestroyed;
    }

    private void EnemyOnOnEnemyAboutToBeDestroyed(int score)
    {
        Debug.Log($"event received for tallying the score: {score}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
