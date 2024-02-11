//using System.Collections.Generic;
//using System.Threading;
//using UnityEngine;

//public class Tower_Prototype : MonoBehaviour
//{
//    // 기본 속성
//    public float attackDamage;
//    public float skillDamage;
//    public float baseAttackRate;
//    public float skillCastRate;
//    public float buffValue;
//    public float installationCost;
//    public string towerName;
//    public string towerType;
//    public string bulletType;
//    public GameObject bulletPrefab;

//    // 추가 속성
//    // public int level;
//    // public float upgradeCost;
//    // public float upgradedAttackDamage;
//    // public float upgradedAttackRate;
//    // public float upgradedSkillCastRate;

//    private void Start()
//    {
//        InvokeRepeating("BasicAttack", 0f, baseAttackRate);
//        InvokeRepeating("UseSkill", 0f, skillCastRate);
//    }

//    void BasicAttack()
//    {
//        GameObject targetMonster = MonsterTargeting();

//        if (targetMonster != null)
//        {
//            // Instantiate the bullet prefab
//            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

//            // Access the Bullet script on the instantiated bullet object
//            Bullet bulletScript = bullet.GetComponent<Bullet>();

//            // Check if the Bullet script is not null
//            if (bulletScript != null)
//            {
//                // Set the bullet's attack damage and target monster
//                bulletScript.SetAttackDamage(attackDamage);
//                bulletScript.SetTargetMonster(targetMonster);
//            }
//            else
//            {
//                Debug.LogError("Bullet script not found on the bullet prefab.");
//            }
//        }
//    }
//    void UseSkill()
//    {
//        MonsterTargeting();
//        // 스킬 사용 로직 추가
//        // UniqueSkillEffect();
//    }

//    GameObject MonsterTargeting()
//    {
//        List<GameObject> monsterList = monsterManager.Monster_list;

//        GameObject targetMonster = null;
//        float maxMoveDistance = float.MinValue;

//        foreach (GameObject monster in monsterList)
//        {
//            // Assuming 'Monster' class has a 'move_distance' variable
//            float monsterMoveDistance = monster.GetComponent<Monster>().move_distance;

//            if (monsterMoveDistance > maxMoveDistance)
//            {
//                maxMoveDistance = monsterMoveDistance;
//                targetMonster = monster;
//            }
//        }

//        return targetMonster;
//    }

//    void LookTargetMonster()
//    {
//        // Get the target monster from MonsterTargeting method
//        GameObject targetMonster = MonsterTargeting();

//        if (targetMonster != null)
//        {
//            // Calculate the direction to the target monster
//            Vector3 direction = targetMonster.transform.position - transform.position;
//            direction.y = 0f; // Optional: Keep the rotation only in the horizontal plane

//            // Rotate towards the target monster
//            transform.rotation = Quaternion.LookRotation(direction);
//        }
//    }

//    // void UniqueSkillEffect()
//    // {
//    //     고유한 스킬 효과 로직 추가
//    // }
//}
