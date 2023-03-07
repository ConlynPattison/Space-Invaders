using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemyComplete : MonoBehaviour
{

    public int scorePerHit = 0;
    public float randomEnemySpeed = 3f;
    public float castOffset = 0.25f;

    public GameObject bulletPrefab;

    public delegate void EnemyDestroyed(int score);
    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed;
    
    private bool _isRandomEnemy;

    private static float _shootChance = 0.1f;

    private void Start()
    {
        _isRandomEnemy = CompareTag("Random");
        if (_isRandomEnemy)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * randomEnemySpeed;
        }
    }

    private void Update()
    {
        TryShoot();
    }

    private void TryShoot()
    {
        if (_isRandomEnemy)
            return;

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position + Vector3.down*castOffset, Vector2.down, 8f);
        if (hitInfo.collider != null && !hitInfo.collider.CompareTag("Enemy"))
        {
            Debug.DrawLine(transform.position + Vector3.down * castOffset, transform.position + Vector3.down * 8f, Color.magenta);
            if (Random.Range(0f, 1000f) <= _shootChance)
            {
                Instantiate(bulletPrefab, transform.position + Vector3.down, Quaternion.identity);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");

        if (_isRandomEnemy)
            OnEnemyAboutToBeDestroyed(Random.Range(3, 8) * 50);
        else
            OnEnemyAboutToBeDestroyed(scorePerHit);
        // todo - trigger death animation
        Destroy(collision.gameObject); // destroy bullet
        Destroy(gameObject);           // destroy self
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_isRandomEnemy && other.CompareTag("RightBorder"))
            Destroy(gameObject);
    }

    public static void SetShootChance(float newChance)
    {
        _shootChance = newChance;
    }
}
