using UnityEngine;
using UnityEngine.Video;

public class EndingVideoPlay : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _endingVdieo;


    public void PlayVideo()
    {
        _uiPanel.SetActive(false);
        _endingVdieo.SetActive(true);
    }
}
