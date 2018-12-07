using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCameraManager : MonoBehaviour {

	void Start () {
        transform.LookAt(Camera.main.transform);
    }
}
