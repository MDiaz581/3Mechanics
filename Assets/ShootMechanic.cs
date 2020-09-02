using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMechanic : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bPrefab;
    public float bForce = 10f;
    private Vector2 mPos;
    private Vector2 shootDir;
    private Rigidbody2D rb;

    public float angle;
    public Camera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mPos = cam.ScreenToWorldPoint(Input.mousePosition);

        shootDir = mPos - rb.position;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("shoot");
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        rb2D.AddForce(shootDir * bForce, ForceMode2D.Impulse);
    }
}
