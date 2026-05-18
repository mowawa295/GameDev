using System.Security.Cryptography;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 3f;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        Movement();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Attack");
    }
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        //Debug.Log(x);
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);

        animator.SetFloat("Speed", Mathf.Abs(x));

    }
}
