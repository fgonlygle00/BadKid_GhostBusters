using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScail_Controller : MonoBehaviour
{
    public void TimeScailUp()
    {
        Time.timeScale = 2f;
    }

    public void TimeScailDown()
    {
        Time.timeScale = 1f;
    }
}
