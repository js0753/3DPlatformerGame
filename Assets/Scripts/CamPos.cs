using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPos : MonoBehaviour
{
    public Camera playerCam;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 camPos = playerCam.transform.position;
        Vector3 playerPos = Player.transform.position;
        Vector3 gap = new Vector3(-0.1f, 1.12f, -2.085f);
        playerCam.transform.position = playerPos + gap;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = playerCam.transform.position;
        Vector3 playerPos = Player.transform.position;
        Vector3 gap = new Vector3(-0.1f, 1.12f, -2.085f);
        playerCam.transform.position = playerPos + gap;

    }
}
