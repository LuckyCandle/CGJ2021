using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSensor : MonoBehaviour
{
    //�½���һ��������ײ��
    public CapsuleCollider capsuleCollider;
    //����ƫ��������ײ���Ҵ�С��΢�����Լ�Сһ��
    public float offset = 0.01f;

    //�Լ�����һ��������ײ������Ҫ�Ĳ���������������λ����Ͱ뾶
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
