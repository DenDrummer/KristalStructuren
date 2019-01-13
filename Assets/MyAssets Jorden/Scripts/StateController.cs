using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StateController : MonoBehaviour
{
    private List<GameObject> ExitStateButtons;
    private List<GameObject> EnterStateButtons;
    private int FreeMoveCountDown;

    void Start()
    {
        ExitStateButtons = GameObject.FindGameObjectsWithTag("exitStateButton").ToList();
        EnterStateButtons = GameObject.FindGameObjectsWithTag("enterStateButton").ToList();
        SetStateButtonsToDefault();
        FreeMoveCountDown = -1;
    }

    public void ChangeState(string state)
    {
        #region handle the old state
        SetStateButtonsToDefault();
        FreeMoveCountDown = -1;

        switch (UserStats.State)
        {
            case State.Default:
                break;
            case State.FreeMove:
                break;
            case State.MeasureDistance:
                ExitMeasureDistance();
                break;
            case State.Teleport:
                ExitTeleport();
                break;
            default:
                break;
        }
        #endregion

        #region handle the new state
        switch (state)
        {
            case "Default":
                ChangeState(State.Default);
                break;
            case "FreeMove":
                DelayedFreeMove();
                break;
            case "MeasureDistance":
                MeasureDistance();
                break;
            case "Teleport":
                Teleport();
                break;
            default:
                throw new Exception(state + " is not a valid state.");
        }
        #endregion
    }

    private void ExitTeleport()
    {
        UserStats.DisabledObjects.ForEach(go => go.SetActive(true));
    }

    private static void ExitMeasureDistance()
    {
        GameObject[] atomGuis = GameObject.FindGameObjectsWithTag("atomgui");
        if (atomGuis.Length > 0)
        {
            foreach (GameObject atomGui in atomGuis)
            {
                atomGui.SetActive(false);
            }
        }
    }

    private void MeasureDistance()
    {
        //get the transform of the root atom object for the currently enabled MeasurePanel
        UserStats.FirstLocation = GameObject.Find("MeasurePanel").transform.parent.parent.parent.parent.parent.parent;
        UserStats.SecondLocation = GameObject.Find("Main Camera").transform;
        ChangeState(State.MeasureDistance);
        //TODO: update measured distance
    }

    private void DelayedFreeMove()
    {
        EnterStateButtons.Find(go => go.name.Equals("FreeMoveOnButton")).SetActive(false);
        ExitStateButtons.Find(go => go.name.Equals("FreeMoveOffButton")).SetActive(true);
        ExitStateButtons.Find(go => go.name.Equals("FreeMoveOffButton")).GetComponent<Button>().Select();
        FreeMoveCountDown = 10;
    }

    void Update()
    {
        if (FreeMoveCountDown > -1)
        {
            FreeMoveCountDown--;
        }
        if (FreeMoveCountDown == 0)
        {
            FreeMove();
        }
    }

    private void Teleport()
    {
        EnterStateButtons.Find(go => go.name.Equals("TeleportModeOnButton")).SetActive(false);
        ExitStateButtons.Find(go => go.name.Equals("TeleportModeOffButton")).SetActive(true);
        ExitStateButtons.Find(go => go.name.Equals("TeleportModeOffButton")).GetComponent<Button>().Select();
        ChangeState(State.Teleport);
    }

    private void SetStateButtonsToDefault()
    {
        EnterStateButtons.ForEach(go => go.SetActive(true));
        ExitStateButtons.ForEach(go => go.SetActive(false));
    }

    private void FreeMove()
    {
        ChangeState(State.FreeMove);
    }

    public void ChangeState(State state)
    {
        Debug.Log($"Changed state to {state.ToString()} from {UserStats.State.ToString()}");
        UserStats.State = state;
    }
}
