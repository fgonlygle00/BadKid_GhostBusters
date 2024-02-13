using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet_Prototype : MonoBehaviour
{
    public float bulletSpeed = 1f;
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

    private void Update()
    {
        if (targetMonster != null)
        {
            Vector3 direction = (targetMonster.transform.position - transform.position).normalized;

            transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("물체와 충돌했습니다.");
        if (other.CompareTag("Monster")) // 충돌체가 몬스터 태그인 경우
        {
            Debug.Log("몬스터와 충돌한 걸 확인했습니다.");
            Monster_Controller monsterStatus = other.GetComponent<Monster_Controller>(); // 해당 몬스터의 스테이터스에 접근
            if (monsterStatus != null)
            {
                monsterStatus.Hit(bulletDamage);
            }

            Debug.Log("나 삭제됨!");
            Destroy(gameObject);
        }
    }
}
