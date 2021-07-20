using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private int intensity;
    private Light pointLight;
    public GameObject Train;
    private TrainController trainController;

    [Header("===== 瓦斯消耗加速比 =====")]
    public int gas_consume_ratio = 2;


    public AK.Wwise.Event turnon;
    public AK.Wwise.Event turnoff;
    public GameObject camera;

    private void Awake()
    {
        camera = Camera.main.gameObject;
        pointLight = GetComponent<Light>();
        trainController = Train.GetComponent<TrainController>();
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;//检测结果         
            if (Physics.Raycast(ray, out hitInfo, 200))//如果碰撞到了
            {
                this.transform.LookAt(new Vector3(hitInfo.point.x, 2, hitInfo.point.z));
            }

            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.None;

                if (intensity > 0)
                {
                    turnoff.Post(camera);
                    intensity = 0;
                    trainController.ratio = 1;
                }
                else
                {
                    turnon.Post(camera);
                    this.transform.LookAt(Train.transform.forward);
                    intensity = 5;
                    trainController.ratio = gas_consume_ratio;
                }
                
            }
        }
       

        pointLight.intensity = intensity;

    }

}
