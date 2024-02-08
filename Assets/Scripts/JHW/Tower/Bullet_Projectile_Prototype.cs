using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectile", menuName = "ScriptableObjects/Projectile")]
public class ProjectilePrototype : ScriptableObject
{
    public float bulletSpeed;
    public float bulletDamageMultiplier; // 타워 공격력에 비례하는 값
    public float bulletWeight;
    public GameObject monsterPrefab;

    public void OnCollisionWithMonster(Collider monsterCollider)
    {
        // 몬스터와 충돌 시 실행되는 로직
        Monster monster = monsterCollider.GetComponent<Monster>();
        if (monster != null)
        {
            ApplyDamageToMonster(monster);
            // 여기에 필요한 추가 로직을 추가할 수 있습니다.
        }
    }

    void ApplyDamageToMonster(Monster monster)
    {
        float damage = bulletDamageMultiplier * /* 타워의 공격력 가져오기 */;
        monster.TakeDamage(damage);
    }
}
