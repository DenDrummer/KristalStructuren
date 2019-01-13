using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUpdater : MonoBehaviour
{
    [SerializeField]
    private Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.Round((UserStats.FirstLocation.position - UserStats.SecondLocation.position).magnitude * 1000f) / 1000f + "  Ångström";
    }
}
