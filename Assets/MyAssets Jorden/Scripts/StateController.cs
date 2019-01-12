
using System;
using System.Threading;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public void ChangeState(string state)
    {
        switch (state)
        {
            case "Default":
                ChangeState(State.Default);
                break;
            case "FreeMove":
                Thread th = new Thread(new ThreadStart(DelayedFreeMove));
                th.Start();
                break;
            case "MeasureDistance":
                ChangeState(State.MeasureDistance);
                break;
            case "SelectAtom":
                ChangeState(State.SelectAtom);
                break;
            case "Teleport":
                ChangeState(State.Teleport);
                break;
            default:
                throw new Exception(state + " is not a valid state.");
        }
    }

    private void DelayedFreeMove()
    {
        Thread.Sleep(100);
        ChangeState(State.FreeMove);
    }

    public void ChangeState(State state)
    {
        UserStats.State = state;
    }
}
