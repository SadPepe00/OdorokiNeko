using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public float shootCooldown = 0.5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 mousePos;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Получаем ввод от игрока
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Стрельба при нажатии левой кнопки мыши
        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    void FixedUpdate()
    {
        // Перемещение игрока
        if (moveInput != Vector2.zero)
        {
            rb.velocity = moveInput.normalized * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        // Определяем направление от игрока к курсору
        Vector2 shootDirection = (mousePos - (Vector2)transform.position).normalized;

        // Создаем пулю и направляем ее в сторону курсора
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);

        // Задержка перед следующим выстрелом
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
       Destroy(bullet);
    }
}
