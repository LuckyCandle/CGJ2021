using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUserInput : MonoBehaviour
{
    [Header("====== 输入信号量 =====")]
    public float Jup;
    public float Jright;

    //1.pressing signal
    public bool run = false;
    public bool faster = false;
    public bool lower = false;
    //2.trigger signal
    public bool take = false;

    [Header("====== 其他 =====")]
    public bool inputEnabled = true;

    /*    // Update is called once per frame
        void Update()
        {

        }*/
    protected void InputProcess() {

    }



    private Vector2 SquareToCircle(Vector2 SquareAxis)
    {
        float Circle_X = SquareAxis.x * Mathf.Sqrt(1 - SquareAxis.y * SquareAxis.y / 2);
        float Circle_Y = SquareAxis.y * Mathf.Sqrt(1 - SquareAxis.x * SquareAxis.x / 2);
        return new Vector2(Circle_X, Circle_Y);
    }


}
