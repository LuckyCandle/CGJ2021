using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    public Transform[] ways1;//路径点的位置
    public Transform tagret;//移动的物体
    public float speed;
    private int index1;


    private void Start()
    {
        index1 = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown("up")) {
            speed *= 2;
        }

        MoveToway1();
    }


    public void MoveToway1()
    {
        if (index1 > ways1.Length - 1) { return; }
        tagret.localPosition = Vector3.MoveTowards(tagret.localPosition, ways1[index1].localPosition, speed * Time.deltaTime);
        if (Vector3.Distance(ways1[index1].localPosition, tagret.localPosition) < 0.01f)
        {
            index1++;

            if (index1 == ways1.Length)
            {
                tagret.localPosition = ways1[index1 - 1].localPosition;

            }
        }
    }



}
