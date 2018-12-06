using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour {

    List<GameObject> gameObjects = new List<GameObject>();

    public void Teleport(Vector3 position, float size)
    {
        gameObjects.ForEach(g => g.SetActive(true));
        gameObjects.Clear();

        transform.position = position;
        Debug.Log(position);

        Collider[] colliders = Physics.OverlapSphere(position, size / 2 + 0.1f);
        new List<Collider>(colliders).ForEach(c => gameObjects.Add(c.gameObject));
        gameObjects.ForEach(g => g.SetActive(false));
    }
}
