using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Density_Enhance_Tower : MonoBehaviour
{
    // 기본 속성
    public float attackDamage = 2; //기본공
    public float skillDamage; //스공
    public float baseAttackRate = 1f; //공속
    public float skillCastRate = 5f; //스킬쿨
    public float buffValue; //버프값
    public float installationCost; //설치비용
    public string towerName; //타워 이름
    public string towerType; //타워 타입
    public string bulletType; //총알 타입
    public GameObject bulletPrefab; //총알 프리펩
    private int arr_Index;


    //사거리 중심점과 반경
    private Vector3 center;
    private float radius;


    // 추가 속성
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;

    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //기본 공격 주기적으로 
        InvokeRepeating("UseSkill", 0f, skillCastRate); //스킬 주기적으로
    }

    private void Update()
    {
        LookTargetMonster();
    }


    void BasicAttack() //기본공격
    {
        Monster_Controller targetMonster = MonsterTargeting(); //타겟 몬스터를 리턴받는다

        if (targetMonster != null)
        {
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
        }
    }
    void UseSkill()
    {
        MonsterTargeting();
        // 스킬 사용 로직 추가
        // UniqueSkillEffect();
    }


    /*

    Monster_Controller MonsterTargeting()
    {
        List<Monster_Controller> monsterList = Monster_Manager.Instanse._monsters;

        Monster_Controller max_moveDistanse_Monster = null;
        float max_moveDistanse = float.MinValue;

        foreach (Monster_Controller monster in monsterList)
        {
            // 이 오브젝트의 위치를 가져오기
            Vector3 monsterPosition = monster.transform.position;
            Vector3 center = transform.position;

            // 레이캐스트를 이용하여 몬스터의 위치와의 충돌을 감지
            RaycastHit hit;
            if (Physics.Raycast(center, monsterPosition - center, out hit, 150f))
            {
                // 충돌한 오브젝트가 몬스터인지 확인
                Monster_Controller hitMonster = hit.collider.GetComponent<Monster_Controller>();
                if (hitMonster != null)
                {
                    // 'moveDistanse'값이 현재 최대값보다 큰지 확인
                    if (hitMonster.moveDistanse > max_moveDistanse)
                    {
                        max_moveDistanse = hitMonster.moveDistanse;
                        max_moveDistanse_Monster = hitMonster;
                    }
                }
            }
        }

        return max_moveDistanse_Monster;
    }
    */


     Monster_Controller MonsterTargeting()
    {
        List<Monster_Controller> monsterList = Monster_Manager.Instanse._monsters;


        Monster_Controller max_moveDistanse_Monster = null;
        float max_moveDistanse = float.MinValue;

        foreach (Monster_Controller monster in monsterList)
        {
            if (monster != null)
            {
                // 이 오브젝트의 위치를 가져오기
                Vector3 monsterPosition = monster.transform.position;
                Vector3 center = transform.position;

                // 좌표 범위 내에 있는지 확인
                if (Vector3.Distance(center, monsterPosition) <= radius)
                {
                    // 'moveDistanse'값이 현재 최대값보다 큰지 확인
                    if (monster.moveDistanse > max_moveDistanse)
                    {
                        max_moveDistanse = monster.moveDistanse;
                        max_moveDistanse_Monster = monster;
                    }
                }
            }
        }

        return max_moveDistanse_Monster;
    }
    

    /* Monster_Controller MonsterTargeting() //몬스터를 타겟팅하는 메서드
    {
        List<Monster_Controller> monsterList = Monster_Manager.Instanse._monsters; //몬스터 리스트를 불러온다.

        Monster_Controller targetMonster = null;
        float maxMoveDistance = float.MinValue;

        foreach (Monster_Controller monster in monsterList) //몬스터 리스트 중에서 가장 앞서나가는 몬스터를 찾는다.
        {
            float monsterMoveDistance = monster.GetComponent<Monster_Controller>().moveDistanse; //moveDistanse값이 가장 높은 몬스터를 찾는다.

            if (monsterMoveDistance > maxMoveDistance)
            {
                maxMoveDistance = monsterMoveDistance;
                targetMonster = monster;
            }
        }

        return targetMonster;  //가장 앞선 몬스터를 리턴
    }
    */

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

    public void Index_Get(int index)
    {
        arr_Index = index;
        if (arr_Index >= 0 && arr_Index <= 7)
        {
            center = new Vector3(70f, 19.1f, 190f);
            radius = 113f;
        }
        else if (arr_Index >= 8 && arr_Index <= 13)
        {
            center = new Vector3(289f, 19.1f, 86f);
            radius = 125f;
        }
        else if (arr_Index >= 14 && arr_Index <= 17)
        {
            center = new Vector3(356f, 19.1f, 279f);
            radius = 102f;
        }
        else
        {
            // Handle invalid arr_Index here if needed
        }
    }

    // void UniqueSkillEffect()
    // {
    //     고유한 스킬 효과 로직 추가
    // }
}
