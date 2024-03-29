using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D rb;
    private float mx;
    private float my;

    private Animator animator;

    private Vector2 mousePos;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float fireRate = 0.5f;
    private float fireTimer;
    private DataManager data_Manager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        data_Manager = FindObjectOfType<DataManager>();
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            data_Manager.level_num = 0;
        }
    }

    private void FixedUpdate()
    {
        if (mx != 0 || my != 0)
        {
            animator.SetFloat("X", mx);
            animator.SetFloat("Y", my);
            animator.SetBool("IsWalking",true);
            animator.SetBool("IsShooting", false);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        rb.velocity = new Vector2(mx, my).normalized*speed;
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position,firePoint.rotation);
        animator.SetBool("IsShooting", true);
    }
}
    