using UnityEngine;
using UnityEngine.UI;

public class TimeScail_Controller : MonoBehaviour
{
    [SerializeField] private Text _timeSpeed;

    public void TimeScailUp()
    {
        Time.timeScale = 2f;
        _timeSpeed.text = "2";
    }

    public void TimeScailDown()
    {
        Time.timeScale = 1f;
        _timeSpeed.text = "1";
    }
}
