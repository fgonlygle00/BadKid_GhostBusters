using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Cannon_Tower : Tower_Prototype
{
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
                // �� ������Ʈ�� ��ġ�� ��������
                Vector3 monsterPosition = monster.transform.position;

                // ��ǥ ���� ���� �ִ��� Ȯ��
                if (Vector3.Distance(center, monsterPosition) <= radius)
                {
                    validMonsters.Add(monster);
                }
            }
        }

        // ��ǥ ���� ���� �ִ� ��ȿ�� ���Ͱ� ���ٸ� null ��ȯ
        if (validMonsters.Count == 0)
        {
            return null;
        }

        // �������� ���� �����Ͽ� ��ȯ
        int randomIndex = Random.Range(0, validMonsters.Count);
        return validMonsters[randomIndex];
    }
}
