using UnityEngine;
using System.Collections.Generic;

public class GarlicBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> markedEnemies;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); // Deal damage to the enemy
            markedEnemies.Add(col.gameObject); // Mark the enemy as hit 
        }
        {
            // Handle other cases or logic here
        }
    }
}
