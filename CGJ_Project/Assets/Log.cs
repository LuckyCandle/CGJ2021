using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Log : MonoBehaviour
{
    // Start is called before the first frame update
    
    public ObiRope rope;
    public ObiRopeCursor cursor;

    void Start()
    {
        rope = GetComponent<ObiRope>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(rope.CalculateLength());
    }
    private void FixedUpdate()
    {
        
    }
}
