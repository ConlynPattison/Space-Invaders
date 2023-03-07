using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    public float unitsPerSecond = 15f;
    
    private Rigidbody2D _rigidBody2D;

    // private Animator playerAnimator;

    //-----------------------------------------------------------------------------
    void Start()
    {
        // playerAnimator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
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
}
