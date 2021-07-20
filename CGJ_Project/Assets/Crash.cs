using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    // Start is called before the first frame update
    public float trainSpeed;
    public float crashSpeed = 3.5f;

    public AK.Wwise.Event crash;
    public GameObject camera;
    void Start()
    {
        camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        trainSpeed = this.GetComponentInParent<TrainController>().current_speed;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Barricade" && trainSpeed >= crashSpeed)
        {
            other.transform.GetComponentInParent<Animation>().Play();
            other.transform.GetComponentInParent<BoxCollider>().enabled = false;
            GameObject.Destroy(other.gameObject);
            crash.Post(camera);
        }
        else {
/*            other.transform.GetChild(1).gameObject.SetActive(true);
            this.GetComponentInParent<TrainController>().isCrash = true;*/
        }
    }

/*    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Barricade") { 
            trainSpeed = Mathf.Lerp(trainSpeed, 0, 0.5f);
        }
    }*/
}
