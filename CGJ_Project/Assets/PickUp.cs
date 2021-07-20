using cakeslice;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Outline outline;
    private bool canGetGas;
    private ThirdPersonController thirdPersonController;

    public AK.Wwise.Event pickup;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (canGetGas) {
            if (Input.GetKeyDown("r"))
            {
                thirdPersonController.isCarryGas = true;
                thirdPersonController.MoveSpeed -= thirdPersonController.walkSpeedChange;
                thirdPersonController.SprintSpeed -= thirdPersonController.runSpeedChange;
                GameObject.Destroy(this.gameObject);

                pickup.Post(camera);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            thirdPersonController = other.GetComponent<ThirdPersonController>();
            outline = this.GetComponent<Outline>();
            outline.eraseRenderer = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canGetGas = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.eraseRenderer = true;
            canGetGas = false;
        }
    }
}
