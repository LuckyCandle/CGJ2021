using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button_Enter;
    public Button button_Exit;


    void Start()
    {
        button_Enter.onClick.AddListener(EnterGame);
        button_Exit.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnterGame() {
        print("Enter");
    }
    void ExitGame() {
        print("Exit");

    }
}
