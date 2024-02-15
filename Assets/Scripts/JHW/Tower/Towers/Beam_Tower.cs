using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Beam_Tower : Tower_Prototype
{
    // 기본 속성


    // 추가 속성
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;

    Monster_Controller past_Monster = null;
    public float sum = 0;


    public override void BasicAttack() //기본공격
    {
        Monster_Controller targetMonster = MonsterTargeting(); //타겟 몬스터를 리턴받는다

        if (targetMonster != null)
        {
            if (isUpgraded == true)
            {
                if (targetMonster == past_Monster)
                {
                    if (sum <= attackDamage * upgrade_Factor)
                    {
                        sum += 0.4f;
                    }
                }
                else
                {
                    sum = 0;
                }
                Vector3 direction = targetMonster.transform.position - transform.position;
                direction.y = 0f;
                transform.rotation = Quaternion.LookRotation(direction);

                Vector3 currentPosition = transform.position;
                currentPosition.y += 5f;

                GameObject bullet = Instantiate(bulletPrefab, currentPosition, Quaternion.identity); //총알 프리펩 인스턴스 생성

                Bullet_Prototype bulletScript = bullet.GetComponent<Bullet_Prototype>(); //총알 인스턴스의 불릿 프로토타입 스크립트를 가져온다

                if (bulletScript != null)
                {

                    bulletScript.SetAttackDamage(attackDamage*1.15f + sum); //불릿의 공격력을 타워 공격력으로 설정 // 빔 타워는 업그레이드 시 공증이 붙는다
                    bulletScript.SetTargetMonster(targetMonster); //불릿의 타겟을 타겟 몬스터로 설정
                    past_Monster = targetMonster;
                }
                else
                {
                }
            }
            else
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

                    bulletScript.SetAttackDamage(attackDamage); //불릿의 공격력을 타워 공격력으로 설정 // 빔 타워는 공증이 붙는다
                    bulletScript.SetTargetMonster(targetMonster); //불릿의 타겟을 타겟 몬스터로 설정
                }
                else
                {
                }
            }
        }
    }


    public override Monster_Controller MonsterTargeting()
    {
        if (Monster_Manager.Instanse._monsters.Count == 0)
        {
            return null;
        }

        Monster_Controller max_hp_Monster = null;
        float max_hp = 0;

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
            {
                // 이 오브젝트의 위치를 가져오기
                Vector3 monsterPosition = monster.transform.position;
                float hp = monster.ReturnHP();

                // 좌표 범위 내에 있는지 확인
                if (Vector3.Distance(center, monsterPosition) <= radius)
                {
                    // 'hp'값이 현재 최대값보다 큰지 확인
                    if (hp > max_hp)
                    {
                        max_hp = hp;
                        max_hp_Monster = monster;
                    }
                }
            }
        }
        if (max_hp == 0)
        {
            max_hp_Monster = null;
            return max_hp_Monster;
        }



        return max_hp_Monster;
    }
}
