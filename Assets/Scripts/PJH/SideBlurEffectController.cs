using UnityEngine;

public class SideBlurEffectController : MonoBehaviour
{
    private ParticleSystem _sideBlur;

    // Start is called before the first frame update
    private void Awake()
    {
        TryGetComponent<ParticleSystem>(out _sideBlur);
        _sideBlur.Simulate(5.0f, true, false);
    }

    void Start()
    {
        
        _sideBlur.Play();
    }
}
