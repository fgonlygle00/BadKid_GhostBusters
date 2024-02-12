using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet_Prototype : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage; // 타워 공격력에 비례하는 값
    public float bulletWeight;
    public Monster_Controller targetMonster = null;

    public void SetAttackDamage(float damage)
    {
        bulletDamage = damage;
    }

    // Set the target monster for the bullet
    public void SetTargetMonster(Monster_Controller target)
    {
        targetMonster = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if colliding with an object tagged as "Monster"
        if (collision.gameObject.CompareTag("Monster"))
        {
            // Access Monster_Status component of the collided monster
            Monster_Status monsterStatus = collision.gameObject.GetComponent<Monster_Status>();

            // Check if Monster_Status component is not null
            if (monsterStatus != null)
            {
                // Subtract bulletDamage from the monster's hp
                monsterStatus.hp -= bulletDamage;
             

                // Ensure HP doesn't go below 0
                if (monsterStatus.hp < 0)
                {
                    monsterStatus.hp = 0;
                }
            }

            // Destroy the bullet on collision with a monster
            Destroy(gameObject);
        }
    }
}
