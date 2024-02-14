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

    public virtual void SetAttackDamage(float damage)
    {
        bulletDamage = damage;
    }

    public virtual void SetTargetMonster(Monster_Controller target)
    {
        targetMonster = target;
    }

    public virtual void Upgraded()
    {

    }

    private void Update()
    {
        if (targetMonster != null)
        {
            Vector3 direction = (targetMonster.transform.position - transform.position).normalized;

            transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) // 충돌체가 몬스터 태그인 경우
        {
            Monster_Controller monsterStatus = other.GetComponent<Monster_Controller>(); // 해당 몬스터의 스테이터스에 접근
            if (monsterStatus != null)
            {
                monsterStatus.Hit(bulletDamage);
            }

            Destroy(gameObject);
        }
    }
}
