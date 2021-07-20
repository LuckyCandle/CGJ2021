using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gas_Add_Text : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject collobj;
    [SerializeField] private BoxCollider coll;
    public GameObject gas_add;
     public GameObject gas_add_text;
    [SerializeField] Text text;
    public GameObject Train;
    [SerializeField] private TrainController TrainContorll;
    public bool _isIn;
    public bool _isadded;
    void Start()
    {
        coll = collobj.GetComponent<BoxCollider>();
        text = gas_add_text.GetComponent<Text>();
        TrainContorll = Train.GetComponent<TrainController>();
    }

    // Update is called once per frame
    void Update()
    {
        _isadded = TrainContorll._isadded;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gas_add.gameObject.layer = 5;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gas_add.gameObject.layer = 8;
            text.text = null;
            TrainContorll._isadded = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isadded)
        {
            text.text = "ÃÌº”»º”Õ:" + TrainContorll.gas_add.ToString();
        }
            
        
            
            
            
       
    }
}
