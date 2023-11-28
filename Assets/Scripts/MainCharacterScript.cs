using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D rb;
    private float mx;
    private float my;

    private Vector2 mousePos;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float fireRate = 0.5f;
    private float fireTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x)*Mathf.Rad2Deg - 90f;

        firePoint.transform.localRotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
        else 
        {
            fireTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized*speed;
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position,firePoint.rotation);
    }
}
    