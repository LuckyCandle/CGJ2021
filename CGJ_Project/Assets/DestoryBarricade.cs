using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using cakeslice;

public class DestoryBarricade : MonoBehaviour
{
    public Outline[] outlines;
    public ThirdPersonController thirdPersonController;
    public bool canDestroy;

    public AK.Wwise.Event crash;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDestroy) {
            if (Input.GetKeyDown("r")) {
                crash.Post(camera);
                this.transform.GetComponentInParent<Animation>().Play();
                this.transform.GetComponentInParent<BoxCollider>().enabled = false;
                GameObject.Destroy(this.gameObject);
                foreach (var outline in outlines)
                {
                    outline.eraseRenderer = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            thirdPersonController = other.GetComponent<ThirdPersonController>();
            outlines = this.transform.parent.GetComponentsInChildren<Outline>();
            foreach (var outline in outlines)
            {
                outline.eraseRenderer = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canDestroy = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var outline in outlines)
            {
                outline.eraseRenderer = true;
            }
            canDestroy = false;
        }
    }
}
