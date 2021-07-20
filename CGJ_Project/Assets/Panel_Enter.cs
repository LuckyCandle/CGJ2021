using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
public class Panel_Enter : MonoBehaviour
{
    // Start is called before the first frame update
    #region 组件
    public Button btn_enter;
    public Button btn_textline;
    public Button btn_exit;
    public Sprite enter_pressed;
    public Sprite textline_pressed;
    public Sprite exit_pressed;
    public Sprite enter_def;
    public Sprite textline_def;
    public Sprite exit_def;
    public Button masks;
    public GameObject Panel_Textline;
    [SerializeField] private bool _ischange = false;
    #endregion
    void Start()
    {
        btn_enter.onClick.AddListener(btn_enter_onclick);
        btn_textline.onClick.AddListener(btn_textline_onclick);
        btn_exit.onClick.AddListener(btn_exit_onclick);
        masks.onClick.AddListener(masks_onclick);
        Panel_Textline.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {


    }
    void btn_enter_onclick()
    {
        _ischange = !_ischange;
        if (_ischange)
        {
            btn_enter.GetComponent<Image>().sprite = enter_pressed;
            _ischange = !_ischange;
        }
        startGame();
        btn_enter.GetComponent<Image>().sprite = enter_def;
    }

    void btn_textline_onclick()
    {
        _ischange = !_ischange;
        if (_ischange)
        {
            btn_textline.GetComponent<Image>().sprite = textline_pressed;
            _ischange = !_ischange;
        }
        Panel_Textline.SetActive(true);
        btn_textline.GetComponent<Image>().sprite = textline_def;
    }

    void btn_exit_onclick()
    {
        _ischange = !_ischange;
        if (_ischange)
        {
            btn_exit.GetComponent<Image>().sprite = exit_pressed;
            _ischange = !_ischange;
        }
        btn_exit.GetComponent<Image>().sprite = exit_def;
        Debug.Log("Eixt!");
#if UNITY_EDITOR    //在编辑器模式下
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    void masks_onclick()
    {
        Panel_Textline.SetActive(false);
    }
    void startGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
}
