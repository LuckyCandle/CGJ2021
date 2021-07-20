using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : IUserInput
{
    [Header("====== 键位设置 =====")]
    //键盘变量定义
    public string up = "up";
    public string down = "down";
    public string get = "r";

    [Header("====== 鼠标设置 =====")]
    public bool mouseEnabled = true;
    public float mouseXsensitivity = 3.0f;
    public float mouseYsensitivity = 3.0f;

    private ButtonManager speed_up = new ButtonManager();
    private ButtonManager speed_down = new ButtonManager();
    private ButtonManager get_gas = new ButtonManager();

    // Update is called once per frame
    void Update()
    {
        speed_up.getPressState(Input.GetKey(up));
        speed_down.getPressState(Input.GetKey(down));
        get_gas.getPressState(Input.GetKey(get));

        Jup = Input.GetAxis("Mouse Y") * mouseYsensitivity;
        Jright = Input.GetAxis("Mouse X") * mouseXsensitivity;

        InputProcess();

        faster = speed_up.IsPressing;
        lower = speed_down.IsPressing;
        take = get_gas.OnPressed;
    }
}
