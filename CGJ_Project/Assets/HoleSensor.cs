using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSensor : MonoBehaviour
{
    //新建立一个胶囊碰撞器
    public CapsuleCollider capsuleCollider;
    //设置偏移量让碰撞胶囊大小稍微沉降以及小一点
    public float offset = 0.01f;

    //自己创建一个胶囊碰撞器所需要的参数，上下两个三位坐标和半径
    private Vector3 point1;
    private Vector3 point2;
    private float radius;

    public AK.Wwise.Event die;
    public GameObject camera;

    // Start is called before the first frame update
    void Awake()
    {
        radius = capsuleCollider.radius - 0.05f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        point1 = transform.position + transform.up * (radius - offset);
        point2 = transform.position + transform.up * (capsuleCollider.height - offset) - transform.up * radius;

        Collider[] colliders = Physics.OverlapCapsule(point1, point2, radius, LayerMask.GetMask("Hole"));
        if (colliders.Length > 0)
        {
            SendMessage("DropInHole");
            // Wwise

            die.Post(camera);
        }
    }
}
