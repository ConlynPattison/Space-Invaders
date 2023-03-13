using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    public TextMeshProUGUI livesText;
    public float unitsPerSecond = 15f;
    public int initialLives = 3;

    public delegate void PlayerOutOfLives();
    public static event PlayerOutOfLives OnPlayerOutOfLives;

    private Animator _animator;
    private Rigidbody2D _rigidBody2D;
    private int _livesRemaining;

    // private Animator playerAnimator;

    //-----------------------------------------------------------------------------
    void Start()
    {
        // playerAnimator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        livesText.text = $"{initialLives}";
        _livesRemaining = initialLives;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // Shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShotRequested();
        }
    }

    private void FixedUpdate()
    {
        _rigidBody2D.velocity = Input.GetAxis("Horizontal") * unitsPerSecond * Vector2.right;
    }

    private void ShotRequested()
    {
        // playerAnimator.SetTrigger("ShootTrigger");
        if (shootOffsetTransform.hierarchyCount != 2)
            return;
        
        _animator.SetTrigger("Shooting");
        
        GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity, shootOffsetTransform);

        Destroy(shot, 2f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Enemy"))
            return;
        
        Destroy(col.gameObject);
        
        _livesRemaining--;
        if (_livesRemaining < 0)
        {
            OnPlayerOutOfLives();
            Destroy(gameObject);
        }
        else
        {
            livesText.text = $"{_livesRemaining}";
        }
    }
}
