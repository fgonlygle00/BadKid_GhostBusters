//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;
//using UnityEngine;

//public class Bullet_Prototype : MonoBehaviour
//{
//    public float bulletSpeed;
//    public float bulletDamage; // Ÿ�� ���ݷ¿� ����ϴ� ��
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
//        // ���Ϳ� �浹 �� ����Ǵ� ����
//        Monster monster = monsterCollider.GetComponent<Monster>();
//        if (monster != null)
//        {
//            ApplyDamageToMonster(monster);
//            // ���⿡ �ʿ��� �߰� ������ �߰��� �� �ֽ��ϴ�.
//        }
//    }

//    void ApplyDamageToMonster(Monster monster)
//    {
//        monster.TakeDamage(bulletDamage);
//    }
//}
