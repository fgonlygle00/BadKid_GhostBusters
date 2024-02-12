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
        if (collision.gameObject.CompareTag("Monster"))   //충돌체가 몬스터 태그인 경우
        {
            Monster_Controller monsterStatus = collision.gameObject.GetComponent<Monster_Controller>(); //해당 몬스터의 스테이터스에 접근

            // Check if Monster_Status component is not null
            if (monsterStatus != null)
            {
                // Subtract bulletDamage from the monster's hp
                monsterStatus.Hit(bulletDamage);
            }

            // Destroy the bullet on collision with a monster
            Destroy(gameObject);
        }
    }
}
