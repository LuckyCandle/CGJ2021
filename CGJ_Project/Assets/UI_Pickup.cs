using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class UI_Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider col;
    public bool _isIn;
    private bool canGetGas;
    void Start()
    {
    }

    // Update is called once per frame
    public void ShowBIllborad(Vector3 position, Vector3 rulerAngles)
    {
        Debug.Log("Position:" + position);
        transform.gameObject.SetActive(true);
        transform.position = position;
        transform.eulerAngles = new Vector3(0, rulerAngles.y, 0);
    }
    void Update()
    {
        
        transform.LookAt(Camera.main.transform.position);
        transform.rotation= Quaternion.Slerp(Quaternion.LookRotation(Camera.main.transform.position - transform.position),transform.rotation, 10 * Time.deltaTime);

    }
    public void HideBillboard()
    {
        transform.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            {
            transform.gameObject.layer = 5;
            }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canGetGas = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.gameObject.layer = 8;
        }
    }
}
