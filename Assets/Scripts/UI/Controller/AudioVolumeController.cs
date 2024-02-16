using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _audioBGMVolume;
    
    private void Awake()
    {
        _audioBGMVolume.value = 1.0f;
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume()
    {
        _audioSource.volume = _audioBGMVolume.value * 0.1f;
    }
}
