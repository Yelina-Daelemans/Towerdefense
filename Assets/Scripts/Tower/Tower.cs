using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange = 1f; // Range within which the tower can detect and attack enemies 

    public float attackRate = 1f; // How often the tower attacks (attacks per second) 

    public int attackDamage = 1; // How much damage each attack does 

    public float attackSize = 1f; // How big the bullet looks 



    public GameObject bulletPrefab; // The bullet prefab the tower will shoot 

    public TowerType type; // the type of this tower 

    private float lastAttackTime;

    // Draw the attack range in the editor for easier debugging 

    void OnDrawGizmosSelected()

    {

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRange);

    }
    void Update()
    {
        // Check if it's time to attack
        if (Time.time - lastAttackTime >= 1f / attackRate)
        {
            // Find enemies within range
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    // Shoot the enemy
                    Shoot(collider.gameObject);
                    break; // Only shoot one enemy per update
                }
            }
        }
    }

    void Shoot(GameObject enemy)
    {
        // Instantiate bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Set bullet properties
        Projectile projectile = bullet.GetComponent<Projectile>();
        projectile.damage = attackDamage;
        projectile.target = enemy.transform;
        bullet.transform.localScale = new Vector3(attackSize, attackSize, 1);

        // Update last attack time
        lastAttackTime = Time.time;
    }
}
