using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;//リジッド
    [SerializeField] Animator animator;
    [Header("Attack Settings"),Tooltip("当たり判定オブジェクト参照"),SerializeField] 
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;

    public int maxHealth = 100;    //player statas
    public int playerAttackDamage = 10;
    public float speed = 5f;
    Enemy enemyScript;//敵のスクリプトへの参照

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

    void HandleMovement() //移動処理
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

    void Attack() //攻撃処理
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

        foreach (Collider2D enemy in hitEnemies) //攻撃範囲内の敵を全て取得
        {
             enemy.GetComponent<Enemy>().TakeDamage(playerAttackDamage);//相手のTakeDamageメソッドを呼び、自分の攻撃力を渡す
        }
    }      

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

}