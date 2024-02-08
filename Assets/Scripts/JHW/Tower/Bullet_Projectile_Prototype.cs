using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectile", menuName = "ScriptableObjects/Projectile")]
public class ProjectilePrototype : ScriptableObject
{
    public float bulletSpeed;
    public float bulletDamageMultiplier; // Ÿ�� ���ݷ¿� ����ϴ� ��
    public float bulletWeight;
    public GameObject monsterPrefab;

    public void OnCollisionWithMonster(Collider monsterCollider)
    {
        // ���Ϳ� �浹 �� ����Ǵ� ����
        Monster monster = monsterCollider.GetComponent<Monster>();
        if (monster != null)
        {
            ApplyDamageToMonster(monster);
            // ���⿡ �ʿ��� �߰� ������ �߰��� �� �ֽ��ϴ�.
        }
    }

    void ApplyDamageToMonster(Monster monster)
    {
        float damage = bulletDamageMultiplier * /* Ÿ���� ���ݷ� �������� */;
        monster.TakeDamage(damage);
    }
}
