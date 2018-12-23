
using UnityEngine;

public class VrControllerListenerQuantum : MonoBehaviour {
    KeyCode BluetoothReturn = (KeyCode)10;

    // Update is called once per frame
    void Update()
    {
        //For VR controller
        if (Input.GetKeyDown(BluetoothReturn))
        {
            transform.GetComponent<Teleport>().TeleportToAtom();
        }
    }
}
