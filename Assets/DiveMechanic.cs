using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveMechanic : MonoBehaviour
{
    public int maxJumps;
    public int jumps;
    public float jumpForce;
    public float diveSpeed;
    public float diveDir;
    public float maxSpeed;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumps > 0)
            {
                Debug.Log("space!");
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumps -= 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(transform.right * diveSpeed * diveDir, ForceMode2D.Impulse);
            rb.AddForce(transform.up * jumpForce/3 * Mathf.Abs(diveDir), ForceMode2D.Impulse);

        }
            if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("left");
            diveDir = -1;
        } else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("right");
            diveDir = 1;

        } else
        {
            diveDir = 0;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");

        jumps = maxJumps;
    }

}
