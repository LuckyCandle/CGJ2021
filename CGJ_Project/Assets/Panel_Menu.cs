using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Panel_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn_return;
    public Button btn_exit;
    void Start()
    {
        btn_return.onClick.AddListener(btn_return_onclick);
        btn_exit.onClick.AddListener(btn_exit_onclick);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btn_return_onclick()
    {
        this.GetComponentInParent<Panel_Base_Contorll>().ClosePanel(this.gameObject, true, true);
    }

    void btn_exit_onclick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
