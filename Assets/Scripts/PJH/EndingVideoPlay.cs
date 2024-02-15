using UnityEngine;
using UnityEngine.Video;

public class EndingVideoPlay : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _creditPanel;
    [SerializeField] private GameObject _endingVdieo;

    public void PlayVideo()
    {
        _uiPanel.SetActive(false);
        _creditPanel.SetActive(true);
        _endingVdieo.SetActive(true);
    }
}
