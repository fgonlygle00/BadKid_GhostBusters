using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gun_Tower : Tower_Prototype
{

    public override void BasicAttack() //기본공격
    {
        Monster_Controller targetMonster = MonsterTargeting(); //타겟 몬스터를 리턴받는다

        if (targetMonster != null)
        {
            Vector3 direction = targetMonster.transform.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.LookRotation(direction);

            Vector3 currentPosition = transform.position;
            currentPosition.y += 5f;

            GameObject bullet = Instantiate(bulletPrefab, currentPosition, Quaternion.identity); //총알 프리펩 인스턴스 생성

            Bullet_Prototype bulletScript = bullet.GetComponent<Bullet_Prototype>(); //총알 인스턴스의 불릿 프로토타입 스크립트를 가져온다

            if (bulletScript != null)
            {

                bulletScript.SetAttackDamage(attackDamage); //불릿의 공격력을 타워 공격력으로 설정
                bulletScript.SetTargetMonster(targetMonster); //불릿의 타겟을 타겟 몬스터로 설정
            }
            else
            {
            }

        if( isUpgraded == true)   //업그레이드시, 총알 2배
            {
                Vector3 currentPosition2 = transform.position;
                currentPosition2.y += 25f;

                GameObject bullet2 = Instantiate(bulletPrefab, currentPosition2, Quaternion.identity); //총알 프리펩 인스턴스 생성

                Bullet_Prototype bulletScript2 = bullet2.GetComponent<Bullet_Prototype>(); //총알 인스턴스의 불릿 프로토타입 스크립트를 가져온다

                if (bulletScript2 != null)
                {

                    bulletScript2.SetAttackDamage(attackDamage * upgrade_Factor); //불릿의 공격력을 타워 공격력으로 설정
                    bulletScript2.SetTargetMonster(targetMonster); //불릿의 타겟을 타겟 몬스터로 설정
                }
                else
                {
                }
            }
        }
    }

}
