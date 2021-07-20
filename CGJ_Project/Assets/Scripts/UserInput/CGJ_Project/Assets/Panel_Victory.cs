using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Panel_Victory : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn_Exit;
    void Start()
    {
        btn_Exit.onClick.AddListener(btn_exit_onclick);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void btn_exit_onclick()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        this.gameObject.SetActive(false);
    }
}
