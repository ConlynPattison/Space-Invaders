using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    private int _score;
    
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        EnemyComplete.OnEnemyAboutToBeDestroyed += EnemyOnOnEnemyAboutToBeDestroyed;
    }

    private void EnemyOnOnEnemyAboutToBeDestroyed(int score)
    {
        _score += score;
        Debug.Log($"event received for tallying the score: {score}");
        scoreText.text = $"SCORE\n{_score}";
    }
}
