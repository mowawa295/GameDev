using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyMaxHealth = 50f;
    public void TakeDamage(int damage)// ダメージ量(damage)を引数として受け取るように変更

    {
        enemyMaxHealth -= damage;
        Debug.Log("敵に " + damage + " ダメージ！ 残りHP: " + enemyMaxHealth);
        if (enemyMaxHealth <= 0)        // 体力が0以下になったら消滅
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}