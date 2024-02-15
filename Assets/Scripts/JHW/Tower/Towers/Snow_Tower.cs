using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Snow_Tower : Tower_Prototype
{
    // 보류
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;
    // public string towerName; //타워 이름
    //
    // public string bulletType; //총알 타입
    // public float installationCost; //설치비용
    public GameObject snow_Summon;



    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //기본 공격 주기적으로 
        InvokeRepeating("UseSkill", 0f, skillCastRate); //스킬 주기적으로
    }

    public void UseSkill()
    {
        Monster_Controller targetMonster = MonsterTargeting_Random();
        if (targetMonster != null)
        {
            Vector3 direction = targetMonster.transform.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.LookRotation(direction);

            Vector3 pos = targetMonster.transform.position;
            pos.y += 1f;

            GameObject snow = Instantiate(snow_Summon, pos, Quaternion.identity); //눈구름 프리펩 인스턴스 생성

            Snow_Summon snowScript = snow.GetComponent<Snow_Summon>(); //스노우 인스턴스의 스크립트를 가져온다

            if (snowScript != null)
            {
                if (isUpgraded)
                {
                    snowScript.SetAttackDamage(attackDamage * upgrade_Factor); //업그레이드 시 계수 추가    
                }
                else
                {
                    snowScript.SetAttackDamage(attackDamage);
                }
                snowScript.checkUpgrade(isUpgraded);
            }
        }
    }

    public Monster_Controller MonsterTargeting_Random()
    {
        if (Monster_Manager.Instanse._monsters.Count == 0)
        {
            return null;
        }

        List<Monster_Controller> validMonsters = new List<Monster_Controller>();

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
            {
                // 이 오브젝트의 위치를 가져오기
                Vector3 monsterPosition = monster.transform.position;

                // 좌표 범위 내에 있는지 확인
                if (Vector3.Distance(center, monsterPosition) <= radius)
                {
                    validMonsters.Add(monster);
                }
            }
        }

        // 좌표 범위 내에 있는 유효한 몬스터가 없다면 null 반환
        if (validMonsters.Count == 0)
        {
            return null;
        }

        // 무작위로 몬스터 선택하여 반환
        int randomIndex = Random.Range(0, validMonsters.Count);
        return validMonsters[randomIndex];
    }
}
