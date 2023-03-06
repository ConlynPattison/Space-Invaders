using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    public GameObject EnemyTopPrefab;
    public GameObject EnemyMiddlePrefab;
    public GameObject EnemyBottomPrefab;
    public GameObject EnemyParent;

    public float EnemyScale = 3f;

    private int _roundsCompleted;
    private int _enemiesPerRow;
    private float _distanceBetweenEnemies;
    private bool _movingRight;
    private Transform _rootTransform;

    // Start is called before the first frame update
    void Start()
    {
        _roundsCompleted = 0;
        _distanceBetweenEnemies = 0.75f;
        _enemiesPerRow = 11;
        _movingRight = true;
        _rootTransform = EnemyParent.transform;
        SpawnEnemies();
    }
    
    
    private void SpawnEnemies()
    {
        Vector3 spawnerLocation = transform.position;
        
        // Top row
        for (float x = 0; x < _enemiesPerRow * _distanceBetweenEnemies; x += _distanceBetweenEnemies)
        {
            Instantiate(EnemyTopPrefab, new Vector3(spawnerLocation.x + x, spawnerLocation.y, 0), Quaternion.identity, _rootTransform);
        }
        
        // Middle Rows
        for (float y = -_distanceBetweenEnemies; y >= -2 * _distanceBetweenEnemies; y -= _distanceBetweenEnemies)
        {
            for (float x = 0; x < _enemiesPerRow * _distanceBetweenEnemies; x += _distanceBetweenEnemies)
            {
                Instantiate(EnemyMiddlePrefab, new Vector3(spawnerLocation.x + x, spawnerLocation.y + y, 0), Quaternion.identity, _rootTransform);
            }
        }
        // Bottom Rows
        for (float y = -3 * _distanceBetweenEnemies; y >= -4 * _distanceBetweenEnemies; y -= _distanceBetweenEnemies)
        {
            for (float x = 0; x < _enemiesPerRow * _distanceBetweenEnemies; x += _distanceBetweenEnemies)
            {
                Instantiate(EnemyBottomPrefab, new Vector3(spawnerLocation.x + x, spawnerLocation.y + y, 0), Quaternion.identity, _rootTransform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
