using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [Header("===== 火车 =====")]
    public Transform train;

    [Header("===== 火车相关参数 =====")]
    public float max_speed;
    public float min_speed;
    public float colliderThreshold;
    public float turnThreshold;
    public float accelerate;
    public float angleSpeed;
    public ParticleSystem particle;

    [Header("===== 轨道 =====")]
    public Transform[] lines;

    [Header("==== 当前车速 =====")]
    public float current_speed = 2;

    [Header("===== 燃油相关 =====")]
    public int gas_all = 100;
    public int gas_consume = 1;
    public int gas_add = 20;
    public bool _isadded;
    [Header("===== 其他参数 =====")]
    public Animation animation;
    private int index;
    private float timer;
    public bool isOutofTrack = false;
    public int ratio;
    private Rigidbody rigidbody;
    private IUserInput userInput;
    public GameManager gameManager;
    public GasManager gasManager;
    public GameObject trainLights;
    
    [Header("===== WWise ===== ")]
    public GameObject camera;
    public AK.Wwise.Event derailment;
    public AK.Wwise.RTPC trainSpeed;
    public AK.Wwise.Event addGas;
    public AK.Wwise.Event win;
    bool winflag;
    public AK.Wwise.Event lose;
    bool loseflag;
    public bool _isLost;
    public bool _isWin;
    public AK.Wwise.RTPC fuel;
    

    // Start is called before the first frame update
    void Start()
    {
        winflag = false;
        loseflag = false;
        index = 0;
        timer = 0;
        rigidbody = GetComponent<Rigidbody>();
        userInput = GetComponent<KeyBoardInput>();
        animation = GetComponent<Animation>();
        gameManager = new GameManager();
        gasManager = new GasManager(gas_all, gas_consume, gas_add);
        particle.Pause();
        ratio = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GasProcessing();
        //print(gasManager.gas_all);
        if (gasManager.gas_all <= 0) {
            gameManager._isDead = true;
            _isLost=true;
        }

        if (current_speed == 0)
        {   
            animation.Stop();
            
        }
        else {
            animation.Play();
        }

        if (Input.GetKeyDown("k")) {
            gameManager._isDead = true;
            gasManager.gas_all = 0;
            _isLost = true;
        }

        if (Input.GetKeyDown("j"))
        {
            gameManager._isWin = true;
            _isWin = true;
        }
        if (gameManager._isWin && !winflag)
        {
            win.Post(camera);
            winflag = true;
        }
        if (gameManager._isDead && !loseflag)
        {
            lose.Post(camera);
            loseflag = true;
        }

        fuel.SetGlobalValue((float)gasManager.gas_all / 100);
        print((float)gasManager.gas_all / 100);

    }

     void FixedUpdate()
    {
        LightControl();
        speedControl();
        MoveToway();
    }

    private void GasProcessing() {
        gasManager.gasConsuming(ratio);
        if (gasManager.gasCurrent()) {
            gameManager._isOutofGas = true;
        }
        //print(gasManager.gas_all);
    }


    //移向指定的物件
    private void MoveToway()
    {
        if (index > lines.Length - 1) { return; }
        lerpRotate(train, lines[index]);
        rigidbody.velocity = train.forward * current_speed;
        if (Vector3.Distance(train.position, lines[index].position) < 10.0f)
        {
            index++;
        }
        //当到达终点时结束
        if (index == lines.Length) {
            gameManager._isWin = true;
            _isWin = true;
            return;
        }
    }

    //缓慢转动方向
    private void lerpRotate(Transform train, Transform target) {
            Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation,rotation,angleSpeed*Time.deltaTime);
            //角度判断当角度超过90度的旋转时，若速度大于阈值那宣告失败(火车脱轨)
            if (Vector3.Angle(target.position - train.position, transform.forward) >= 20.0f) {
                if (current_speed >= turnThreshold) {

                // WWise
                if (!isOutofTrack)
                {
                    derailment.Post(camera);
                }


                isOutofTrack = true;
                
                
                }
            }
    }

    //速度控制
    private void speedControl() {
        if (!isOutofTrack)
        {
            if (userInput.faster)
            {
                current_speed += accelerate;
                current_speed = current_speed >= max_speed ? max_speed : current_speed;
            }
            else if (userInput.lower)
            {
                current_speed -= accelerate;
                current_speed = current_speed <= min_speed ? min_speed : current_speed;
            }
        }
        else {
            current_speed = Mathf.Lerp(current_speed,0,0.1f);
        }


        if (current_speed >= colliderThreshold)
        {
            particle.Play();
        }
        else {
            particle.Clear();
            //particle.Simulate(1.0f,true,false);
            particle.Pause();
            //particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        // WWise
        trainSpeed.SetGlobalValue(current_speed / max_speed);

    }
    // Light Control
    void LightControl()
    {
        if(isOutofTrack && trainLights.activeSelf)
        {
            trainLights.SetActive(false);
        }
        if(!isOutofTrack && !trainLights.activeSelf)
        {
            trainLights.SetActive(true);
        }
    }
    public void AddGas() {
        gasManager.gasAdding();
        _isadded = true;
        // Wwise
        addGas.Post(camera);
    }

    public float GetGas() {
        return (float)gasManager.gas_all;
    }
}
