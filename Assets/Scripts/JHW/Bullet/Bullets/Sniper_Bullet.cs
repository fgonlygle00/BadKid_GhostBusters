using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Sniper_Bullet : Bullet_Prototype
{
    private void Update()
    {
        if (targetMonster != null)
        {
            // 타겟 방향 구하기
            Vector3 direction = (targetMonster.transform.position - transform.position).normalized;

            // 타겟 방향으로 회전
            transform.LookAt(targetMonster.transform);

            // 타겟 방향으로 이동
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
            if (targetMonster != null && monsterStatus != null)
            {
                if (targetMonster == monsterStatus)
                {
                    monsterStatus.Hit(bulletDamage); //충돌체가 '타겟 몬스터'인 경우에만
                    Destroy(gameObject);
                }
            }
        }
    }
}
