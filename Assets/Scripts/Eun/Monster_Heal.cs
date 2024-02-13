using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Heal : MonoBehaviour
{
    public int[] Healindex;
    [SerializeField] private float _healPersent;


    public float Heal()
    {
        Debug.Log((_healPersent / 100));
        return (_healPersent / 100);
    }

}
