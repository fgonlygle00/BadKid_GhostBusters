//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;
//using UnityEngine;

//public class Bullet_Prototype : MonoBehaviour
//{
//    public float bulletSpeed;
//    public float bulletDamage; // 타워 공격력에 비례하는 값
//    public float bulletWeight;
//    public GameObject monsterPrefab;
//    public GameObject targetMonster = null;

//    public void SetAttackDamage(float damage)
//    {
//        bulletDamage = damage;
//    }

//    // Set the target monster for the bullet
//    public void SetTargetMonster(GameObject target)
//    {
//        targetMonster = target;
//    }

//    public void OnCollisionWithMonster(Collider monsterCollider)
//    {
//        // 몬스터와 충돌 시 실행되는 로직
//        Monster monster = monsterCollider.GetComponent<Monster>();
//        if (monster != null)
//        {
//            ApplyDamageToMonster(monster);
//            // 여기에 필요한 추가 로직을 추가할 수 있습니다.
//        }
//    }

//    void ApplyDamageToMonster(Monster monster)
//    {
//        monster.TakeDamage(bulletDamage);
//    }
//}
