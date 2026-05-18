using UnityEngine;

public class enemy : MonoBehaviour
{
    warriarBlueMovementScript warriarBlueMovementScript;

    public float speed = 5f; // Enemy movement speed
    public float enemyMaxHealth = 50f; // Enemy maximum health

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage()
    {
        enemyMaxHealth -= warriarBlueMovementScript.playerAttackDamage;

    }
}
