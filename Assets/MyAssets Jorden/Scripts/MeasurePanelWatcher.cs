using System;
using UnityEngine;

[Obsolete("MeasurePanelWatcher is deprecated, please use Event Triggers to call methods from StateController")]
public class MeasurePanelWatcher : MonoBehaviour
{
    [SerializeField]
    private StateController stateController;

    void OnEnable()
    {
        stateController.ChangeState("MeasureDistance");
    }

    void OnDisable()
    {
        if (UserStats.State.Equals(State.MeasureDistance))
        {
            stateController.ChangeState("Default");
        }
    }
}
