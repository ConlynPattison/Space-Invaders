using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    public TextMeshProUGUI livesText;
    public float unitsPerSecond = 15f;
    public int initalLives = 3;
    
    private Rigidbody2D _rigidBody2D;
    private int _livesRemaining;

    // private Animator playerAnimator;

    //-----------------------------------------------------------------------------
    void Start()
    {
        // playerAnimator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        livesText.text = $"{initalLives}";
        _livesRemaining = initalLives;
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
        
        GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity, shootOffsetTransform);
        Debug.Log("Bang!");

        Destroy(shot, 3f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Enemy"))
            return;
        
        Destroy(col.gameObject);
        
        _livesRemaining--;
        if (_livesRemaining < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            livesText.text = $"{_livesRemaining}";
        }
    }
}
