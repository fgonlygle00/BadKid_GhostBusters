using System.Threading;
using UnityEngine;

public class Snow_Summon : MonoBehaviour
{
    float creationTime = 0.6f;
    float snowRadius = 40f;
    float ticRate = 0.2f;
    float summononDamage;
    bool isUpgrade;

    void Start()
    {
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
            ticRate = 0.15f;
            snowRadius = 60f;
        }
        InvokeRepeating("Snow_Rain", 0f, ticRate);
    }

    void Snow_Rain()
    {
        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
        {
            // 몬스터 위치를 가져온다
            Vector3 monsterPosition = monster.transform.position;

            // 좌표 범위 내에 있는 몬스터들에게 슬로우를 준다
            if (Vector3.Distance(transform.position, monsterPosition) <= snowRadius)
            {
                    monster.Hit(summononDamage * 0.3f);
                    if (isUpgrade == true)
                    {
                        monster.MovementDown(0.001f);
                    }
                    else
                    {
                        monster.MovementDown(0.01f);
                    }
            }
        }
    }

    }

    void DestroySummon()
    {
        Destroy(gameObject);
    }
}
