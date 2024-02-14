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
