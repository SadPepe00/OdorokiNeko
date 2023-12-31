using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float speed = 10f;
    [SerializeField]
    private float lifeTime = 3f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,lifeTime);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
