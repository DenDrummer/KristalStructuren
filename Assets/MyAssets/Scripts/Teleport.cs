using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleport : MonoBehaviour,IPointerClickHandler {

    private TeleportPlayer teleportPlayer;

    // Use this for initialization
    void Start () {
        teleportPlayer = GameObject.Find("Player").GetComponent<TeleportPlayer>();
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            teleportPlayer.Teleport(transform.position,transform.lossyScale.x);
        }
    }
}
