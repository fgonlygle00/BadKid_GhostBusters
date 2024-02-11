using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//임시 이름
public enum Monster_Type
{
    monster1,
    monster2,
    monster3,
    monster4,
    monster5
}

[CreateAssetMenu(fileName = "NewMonsterStatus", menuName = "Monster_Status")]
public class Monster_Status : ScriptableObject
{
    [Header("Status")]
    public Monster_Type monster_Type;
    public int hp;
    public int attack;
    public float speed;
}

