using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower_Prototype : MonoBehaviour
{
    // 기본 속성
    public float attackDamage = 2; //기본공
    public float Defalt_attackDamage = 2;
    public float baseAttackRate = 1f; //공속
    public float skillCastRate = 3f; //스킬쿨
    public float buffValue; //버프값
    public bool isUpgraded;
    public GameObject bulletPrefab; //총알 프리펩
    public string towerType; //타워 타입
    public int arr_Index; //이 타워의 배열칸 위치
    public float upgrade_Factor; // <<< 업그레이드 시 공격력 증가 배율 


    //사거리 중심점과 반경
    public Vector3 center;
    public float radius;


    // 보류
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;
    // public string towerName; //타워 이름
    //
    // public string bulletType; //총알 타입
    // public float installationCost; //설치비용

    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //기본 공격 주기적으로 
        /*InvokeRepeating("UseSkill", 0f, skillCastRate); //스킬 주기적으로*/
    }

    private void Update()
    {
    }

    private void OnMouseOver()
    {
        // 마우스 왼쪽 버튼이 눌렸을 때 체크
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Clicked on Object: " + gameObject.name);
            Upgrade();
        }

        // 마우스 오른쪽 버튼이 눌렸을 때 체크
        if (Input.GetMouseButtonDown(1))
        {
            if (GoodsData.instance._cookies >= 10)
            { 
                Tower_Manager.Instance.ReRoll(arr_Index);
                Destroy(gameObject);
            }

            Debug.Log("Right Clicked on Object: " + gameObject.name);
        }
    }

    public virtual void Upgrade()  //업그레이드 메서드
    {
        if (isUpgraded == false)
        {
            isUpgraded = true;
            Defalt_attackDamage *= upgrade_Factor;
        }
        else
        {
            //여기에 업그레이드가 불가능할 시 작동을 입력하세요
        }
    }

    public void Buffed(float newValue)  //버프 받기 메서드
    {
        if (newValue >= 1)
        {
            attackDamage = Defalt_attackDamage*Tower_Manager.Instance.Buff_Value_Arr[arr_Index]; //기본공격력 * 버프값
        }

    }


    public virtual void BasicAttack() //기본공격
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
        }
    }

    public virtual Monster_Controller MonsterTargeting()
    {

        if (Monster_Manager.Instanse._monsters.Count == 0)
        {
            return null;
        }

        Monster_Controller max_moveDistanse_Monster = null;
        float max_moveDistanse = float.MinValue;

        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
            {
                // 이 오브젝트의 위치를 가져오기
                Vector3 monsterPosition = monster.transform.position;

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
    


    void LookTargetMonster() //몬스터를 바라보는 메서드
    {
        Monster_Controller targetMonster = MonsterTargeting();

        if (targetMonster != null)
        {
            Vector3 direction = targetMonster.transform.position - transform.position;
            direction.y = 0f;

            transform.rotation = Quaternion.LookRotation(direction);
        }

    }

    public void Index_Get(int index)
    {
        arr_Index = index;
        if (arr_Index >= 0 && arr_Index <= 7)
        {
            center = new Vector3(70f, 0f, 190f);
            radius = 120f;
        }
        else if (arr_Index >= 8 && arr_Index <= 13)
        {
            center = new Vector3(289f, 0f, 86f);
            radius = 125f;
        }
        else if (arr_Index >= 14 && arr_Index <= 17)
        {
            center = new Vector3(356f, 0f, 279f);
            radius = 110f;
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
}
