using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Sniper_Tower : Tower_Prototype
{

    // 추가 속성
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;


    private void Update()
    {
        LookTargetMonster();
    }

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
                if (isUpgraded)
                {
                    bulletScript.SetAttackDamage(attackDamage * upgrade_Factor); //업그레이드 시 계수 추가
                }
                else
                {
                    bulletScript.SetAttackDamage(attackDamage);
                }
                bulletScript.SetTargetMonster(targetMonster); //불릿의 타겟을 타겟 몬스터로 설정
                bulletScript.Upgraded(isUpgraded);
            }
            else
            {
            }
        }
    }


    public override Monster_Controller MonsterTargeting() //몬스터를 타겟팅하는 메서드
    {
        if (Monster_Manager.Instanse._monsters.Count == 0)
        {
            return null;
        }

        Monster_Controller targetMonster = null;
        float maxMoveDistance = float.MinValue;

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters) //몬스터 리스트 중에서 가장 앞서나가는 몬스터를 찾는다.
        {
            if(monster != null)
            {
                float monsterMoveDistance = monster.GetComponent<Monster_Controller>().moveDistanse; //moveDistanse값이 가장 높은 몬스터를 찾는다.

                if (monsterMoveDistance > maxMoveDistance)
                {
                    maxMoveDistance = monsterMoveDistance;
                    targetMonster = monster;
                }
            }
        }

        return targetMonster;  //가장 앞선 몬스터를 리턴
    }
    

    void LookTargetMonster() //몬스터를 바라보는 메서드
    {
        Monster_Controller targetMonster = MonsterTargeting();

        if (targetMonster != null)
        {
            Vector3 direction = targetMonster.transform.position - transform.position;
            direction.y = 0f; // Optional: Keep the rotation only in the horizontal plane

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
