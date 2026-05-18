using UnityEngine;

public class warriarBlueMovementScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;//リジッド
    [SerializeField] Animator animator;
    [SerializeField] float speed = 5f;
    [Header("Attack Settings"),Tooltip(""),SerializeField] 
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    //player statas
    public int maxHealth = 100;
    private int playerAttackDamage = 2;
    //

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Attack", true);
            Attack();
        }
        else
        {
            animator.SetBool("Attack", false);
        }

        HandleMovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)//この関数は、プレイヤーが敵と衝突したときに呼び出されます。衝突したオブジェクトが敵であれば、プレイヤーの体力を減らす処理を行います。
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            // 敵と衝突した場合の処理
            // 例: プレイヤーの体力を減らす
        }
    }

    void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(x, y);
        if (moveInput.sqrMagnitude > 1) moveInput.Normalize();

        rb.linearVelocity = moveInput * speed;

        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        float currentSpeed = moveInput.magnitude;
        animator.SetFloat("Speed", currentSpeed);
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.gameObject.name + " に当たった！");
            // ここで敵にダメージを与える処理を追加
            //EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();    
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

}