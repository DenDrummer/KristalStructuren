
using UnityEngine;

public class Teleport : MonoBehaviour
{

    private TeleportPlayer teleportPlayer;
    private float heldTime = 0;

    // Use this for initialization
    void Start()
    {
        teleportPlayer = GameObject.Find("Player").GetComponent<TeleportPlayer>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            heldTime += Time.deltaTime;

            if (heldTime >= 2f)
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

    /*public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            teleportPlayer.Teleport(transform.position);
        }
    }*/

    public void TeleportToAtom()
    {
        teleportPlayer.Teleport(transform.position);
    }
}
