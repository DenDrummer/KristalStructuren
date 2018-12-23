
using System;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public void ChangeState(string state)
    {
        switch (state)
        {
            case "Default":
                UserStats.State = State.Default;
                break;
            case "FreeMove":
                UserStats.State = State.FreeMove;
                break;
            case "MeasureDistance":
                UserStats.State = State.MeasureDistance;
                break;
            case "SelectAtom":
                UserStats.State = State.SelectAtom;
                break;
            case "Teleport":
                UserStats.State = State.Teleport;
                break;
            default:
                throw new Exception(state + " is not a valid state.");
        }
    }

    public void ChangeState(State state)
    {
        UserStats.State = state;
    }
}
