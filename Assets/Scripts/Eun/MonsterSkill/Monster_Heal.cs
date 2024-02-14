using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Heal : MonoBehaviour
{
    public int[] Healindex;
    [SerializeField]private float healPersent;
    [SerializeField]private float _curHealPersent;

    private void Start()
    {
        _curHealPersent = healPersent;
    }


    public float Heal()
    {
        Debug.Log((_curHealPersent / 100));
        return (_curHealPersent / 100);
    }

    public void ReturnHealPersent(float down)
    {
        _curHealPersent *= down;
    }

    public void ResetHeal()
    {
        _curHealPersent = healPersent;
    }

}
