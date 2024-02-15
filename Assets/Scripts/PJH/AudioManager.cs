using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] _backGroundMusics;
    private AudioSource _audioSource;

    public static AudioManager instanse;
    public void Awake()
    {
        instanse = this;
    }

    private void Start()
    {
        _audioSource.clip = _backGroundMusics[0];
    }

    public void PlayBGM()
    {
        switch(Monster_Manager.Instanse.Wave)
        {
            case 5: _audioSource.clip = _backGroundMusics[1]; break;
            case 10: _audioSource.clip = _backGroundMusics[2]; break;
            case 15: _audioSource.clip = _backGroundMusics[3]; break;
            case 20: _audioSource.clip = _backGroundMusics[4]; break;
            default: _audioSource.clip = _backGroundMusics[0]; break;
        }

        _audioSource.Play();
    }
}
