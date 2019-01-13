using UnityEngine;

public class MeasurePanelWatcher : MonoBehaviour
{
    [SerializeField]
    private StateController stateController;

    void OnEnable()
    {
        stateController.ChangeState(State.MeasureDistance);
    }

    void OnDisable()
    {
        if (UserStats.State.Equals(State.MeasureDistance))
        {
            stateController.ChangeState(State.Default);
        }
    }
}
