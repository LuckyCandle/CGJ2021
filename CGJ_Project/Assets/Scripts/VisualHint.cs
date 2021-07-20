using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualHint : MonoBehaviour
{
    public float rotateVel;
    public float moveVel;
    public float moveDist;
    bool isMovingUp;
    float upY;
    float downY;


    // Start is called before the first frame update
    void Start()
    {
        isMovingUp = true;
        upY = transform.position.y + moveDist;
        downY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateVel * Time.deltaTime, 0);
        
        if(isMovingUp)
        {
            float newY = Mathf.MoveTowards(transform.position.y, upY, moveVel * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
        else
        {
            float newY = Mathf.MoveTowards(transform.position.y, downY, moveVel * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        if(transform.position.y >= upY || transform.position.y <=downY)
        {
            isMovingUp = !isMovingUp;
        }
    }
}
