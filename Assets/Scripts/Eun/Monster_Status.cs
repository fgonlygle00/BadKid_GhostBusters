using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//임시 이름
public enum Monster_Type
{
    monster,
    boss
}

[System.Serializable]
public class Status
{
    public float hp;
    public float attack;
    public float speed;

    public void Set(float H,float A, float S)
    {
        hp = H;
        attack = A;
        speed = S;
    }

}

[CreateAssetMenu(fileName = "NewMonsterStatus", menuName = "Monster_Status")]
public class Monster_Status : ScriptableObject
{
    [Header("Status")]
    public Monster_Type monster_Type;
    public Status status;

}

