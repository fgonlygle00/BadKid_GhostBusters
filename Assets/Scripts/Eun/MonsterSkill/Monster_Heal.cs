using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Heal : MonoBehaviour
{
    public int[] Healindex;
    [SerializeField]private float healPersent;
    [SerializeField]private float _curHealPersent;

    [SerializeField] private AudioSource _audioSource;

    public GameObject particleObject;
    private void Start()
    {

        _audioSource.clip = AudioManager.instance._backGroundMusics[5];
        _curHealPersent = healPersent;
        particleObject.SetActive(false);
    }


    public float Heal()
    {

        StartCoroutine(PlayHeal());
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


    IEnumerator PlayHeal()
    {
        _audioSource.Play();
        particleObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        _audioSource.Stop();
        particleObject.SetActive(false);

    }
}
