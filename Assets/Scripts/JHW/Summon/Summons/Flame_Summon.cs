using System.Threading;
using UnityEngine;

public class Flame_Summon : MonoBehaviour
{
    float creationTime = 1f;
    float flameRadius = 35f;
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
    }

    void Flame_floor()
    {
        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
        {
            // ���� ��ġ�� �����´�
            Vector3 monsterPosition = monster.transform.position;

            // ��ǥ ���� ���� �ִ� ���͵鿡�� ġ�� ���ҿ� ƽ���� �ش�
            if (Vector3.Distance(transform.position, monsterPosition) <= flameRadius)
            {
                    monster.Hit(monster.maxHP() * 0.01f + summononDamage *0.1f);
                    if (isUpgrade == true)
                    {
                        monster.HPDown(0f);
                    }
                    else
                    {
                        monster.HPDown(0.5f);
                    }
            }
        }
    }
    }

    void DestroySummon()
    {
        // ��ȯ���� �����ϰų� �ʿ��� �߰� ������ ���⿡ ����
        Destroy(gameObject);
    }
}
