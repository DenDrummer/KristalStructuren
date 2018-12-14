using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleport : MonoBehaviour,IPointerClickHandler {

	private TeleportPlayer teleportPlayer;
	private float heldTime = 0;

	// Use this for initialization
	void Start () {
		teleportPlayer = GameObject.Find("Player").GetComponent<TeleportPlayer>();
		string path = Application.persistentDataPath + "/test.txt";
		if (!File.Exists(path))
		{
			using (StreamWriter sw = File.CreateText(path))
			{
				sw.WriteLine("Testing");
			}
		}
		else
		{
			using (StreamWriter sw = File.AppendText(path))
			{
				sw.WriteLine("File Found");
			}
		}
	}

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			heldTime += Time.deltaTime;

			if(heldTime >= 2f)
			{
				teleportPlayer.Teleport(new Vector3(0, 1, -10));
				heldTime = 0;
			}
		}
		else
		{
			heldTime = 0;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			teleportPlayer.Teleport(transform.position);
		}
	}
}
