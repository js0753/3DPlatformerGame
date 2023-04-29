using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject playerModel;
    public Vector3 unitForward;
    public Vector3 unitBackward;
    public Vector3 unitLeft;
    public Vector3 unitRight;
    public float verticalVelocity;
    public float upwardForce;
    float gravity = -9.8f ;
    void Start()
    {
        unitForward = new Vector3(0,0,0.01f);
        unitBackward= new Vector3(0,0,-0.01f);
        unitLeft = new Vector3(-0.01f, 0, 0);
        unitRight = new Vector3(0.01f, 0, 0);
        verticalVelocity = 0.0f;
        upwardForce = 0.0f;
    }
    

    // Update is called once per frame
    void Update()
    {
        
        verticalVelocity += (upwardForce + gravity) * Time.deltaTime;
        //bool hasColliderAtNewPos = Physics.OverlapSphere(playerModel.transform.position + new Vector3(0.0f, verticalVelocity,0.0f), 0.1f).Length > 0;
        Collider[] colliders = Physics.OverlapBox(playerModel.transform.position + new Vector3(0.0f, verticalVelocity, 0.0f), new Vector3(0.5f,0.5f,0.5f) / 2f);
        bool hasColliderAtNewPos = false;
        foreach (Collider collider in colliders)
        {
            // Check if the collider has a specific tag
            if (collider.CompareTag("Player")==false)
            {
                // Set the flag to true and exit the loop
                hasColliderAtNewPos = true;
                break;
            }
        }
        if (hasColliderAtNewPos)
        {
            Debug.Log("On Floor!");
            verticalVelocity = 0.0f;
            upwardForce = -gravity;

        }
        else
        {
            upwardForce = 0.0f;
        }
        if (Input.GetButton("MyJump") && hasColliderAtNewPos)
        {
            verticalVelocity = 200.0f * Time.deltaTime;
        }
        playerModel.transform.position = playerModel.transform.position + new Vector3(0.0f, verticalVelocity, 0.0f);
        if (Input.GetButton("Forward")) {
            playerModel.transform.position += unitForward;
        }
        if (Input.GetButton("Backward"))
        {
            playerModel.transform.position += unitBackward;
        }
        if (Input.GetButton("Left"))
        {
            playerModel.transform.position += unitLeft;
        }
        if (Input.GetButton("Right"))
        {
            playerModel.transform.position += unitRight;
        }
        
    }
}
