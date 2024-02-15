using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Flame_Tower : Tower_Prototype
{
    // 보류
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;
    // public string towerName; //타워 이름
    //
    // public string bulletType; //총알 타입
    // public float installationCost; //설치비용
    public GameObject flame_Summon;



    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //기본 공격 주기적으로 
        InvokeRepeating("UseSkill", 0f, skillCastRate); //스킬 주기적으로
    }

    public void UseSkill()
    {
        Monster_Controller targetMonster = MonsterTargeting();
        if (targetMonster != null)
        {
            GameObject flame = Instantiate(flame_Summon, targetMonster.transform.position, Quaternion.identity); //플레임 프리펩 인스턴스 생성

            Flame_Summon flameScript = flame.GetComponent<Flame_Summon>(); //플레임 인스턴스의 스크립트를 가져온다

            if (flameScript != null)
            {
                if (isUpgraded)
                {
                    flameScript.SetAttackDamage(attackDamage * upgrade_Factor); //업그레이드 시 계수 추가
                    flameScript.checkUpgrade(isUpgraded);
                }
                else
                {
                    flameScript.SetAttackDamage(attackDamage);
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
