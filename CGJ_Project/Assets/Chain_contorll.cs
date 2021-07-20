using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using StarterAssets;
public class Chain_contorll : MonoBehaviour
{
    public ObiActor Obichian;
    public bool _isOutofRange;
    [SerializeField] private ObiRope rope;
    [SerializeField] private Vector3 pull;
    [SerializeField] private Rigidbody body;
    public float timer = 0.5f;
    [SerializeField] private ThirdPersonController script;
    public GameObject Train;
    public float pullspeed;
    // Start is called before the first frame update
    void Start()
    {
        rope = Obichian.GetComponent<ObiRope>();
        body = gameObject.GetComponent<Rigidbody>();
        script = gameObject.GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        _isOutofRange = rope.CalculateLength() > 2*rope.restLength ? true : false;
        if (_isOutofRange)
        {
            timer -= Time.deltaTime;
            script.enabled = false;
            if (timer <= 0)
                {
                script.enabled = true;
                timer = 0.5f;
                }
        }
    }
    private void FixedUpdate()
    {
        if (_isOutofRange&&timer>=0.4f)
        {
            pull.x = gameObject.transform.position.x - Train.transform.position.x;
            pull.z = gameObject.transform.position.z - Train.transform.position.z;
            Vector3 thrustVec = new Vector3(pull.x, 0, pull.z) * pullspeed;
            body.velocity += thrustVec;
            thrustVec = Vector3.zero;
        }
    }
}
