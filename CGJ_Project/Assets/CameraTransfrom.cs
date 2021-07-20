using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransfrom : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 dif;
    private Transform train_trans;
    public GameObject train;
    void Start()
    {
        train_trans = train.transform;
        dif = transform.position - train_trans.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
