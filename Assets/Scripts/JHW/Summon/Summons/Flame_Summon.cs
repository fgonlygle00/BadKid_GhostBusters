using System.Threading;
using UnityEngine;

public class Flame_Summon : MonoBehaviour
{
    float creationTime = 1.2f;
    float flameRadius = 50f;
    float ticRate = 0.1f;
    float summononDamage;
    bool isUpgrade;

    void Start()
    {
        InvokeRepeating("Flame_floor", 0f, ticRate);
        Invoke("DestroySummon", creationTime);
    }
    public void SetAttackDamage(float damage)
    {
        summononDamage = damage;
    }

    public void checkUpgrade(bool _isUpgrade)
    {
        isUpgrade = _isUpgrade;
        if (isUpgrade == true)
        {
            ticRate = 0.07f;
        }
    }

    void Flame_floor()
    {
        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
        {
            // 몬스터 위치를 가져온다
            Vector3 monsterPosition = monster.transform.position;

            // 좌표 범위 내에 있는 몬스터들에게 치유 감소와 틱뎀을 준다
            if (Vector3.Distance(transform.position, monsterPosition) <= flameRadius)
            {
                    
                    if (isUpgrade == true)
                    {
                        monster.HPDown(0.1f);
                        monster.Hit(monster.maxHP() * 0.012f + summononDamage * 0.06f);
                    }
                    else
                    {
                        monster.HPDown(0.5f);
                        monster.Hit(monster.ReturnHP() * 0.01f + summononDamage * 0.05f);
                    }
            }
        }
    }
    }

    void DestroySummon()
    {
        // 소환물을 제거하거나 필요한 추가 로직을 여기에 구현
        Destroy(gameObject);
    }
}
