using System.Threading;
using UnityEngine;

public class Snow_Summon : MonoBehaviour
{
    float creationTime = 0.7f;
    float snowRadius = 40f;
    float ticRate = 0.23f;
    float summononDamage;
    bool isUpgrade;

    void Start()
    {
        InvokeRepeating("Snow_Rain", 0f, ticRate);
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

    void Snow_Rain()
    {
        foreach (Monster_Controller monster in Monster_Manager.Instanse._monsters)
        {
            if (monster != null)
        {
            // ���� ��ġ�� �����´�
            Vector3 monsterPosition = monster.transform.position;

            // ��ǥ ���� ���� �ִ� ���͵鿡�� ���ο츦 �ش�
            if (Vector3.Distance(transform.position, monsterPosition) <= snowRadius)
            {
                    monster.Hit(summononDamage * 0.3f);
                    if (isUpgrade == true)
                    {
                        monster.MovementDown(0.001f);
                    }
                    else
                    {
                        monster.MovementDown(0.1f);
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
