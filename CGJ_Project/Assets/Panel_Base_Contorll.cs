using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Panel_Base_Contorll : MonoBehaviour
{
    // Start is called before the first frame update
    #region Panel获取
    public int index ;
    public GameObject panel_Menu;
    public GameObject panel_Enter;
    public GameObject panel_Dead;
    public GameObject panel_Victory;
    public GameObject Train;
    public GameManager GameManager;
    public TrainController TrainController;

    public bool _lock;
    [SerializeField] private  List<GameObject> opening_panel ;
    #endregion
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;//获取当前关卡Index；
       
        Initialize();
     
    }

    // Update is called once per frame
    void Update()
    {

        
        

        if (Input.GetKeyDown(KeyCode.Escape) && opening_panel.Count > 0 && _lock)
        {
            if (opening_panel.Count == 1)
            {
                ClosePanel(opening_panel[0], true, true);
                return;
            }
            ClosePanel(opening_panel[opening_panel.Count - 1]);

        }

        if (Input.GetKeyDown(KeyCode.Escape) && index == 1&&!_lock)
        {
            OpenPanel(panel_Menu,true,true);

        }

     
            if (TrainController._isLost)
            {
                OpenPanel(panel_Dead, true, true);
                TrainController._isLost = false;
              
            }


        if (TrainController._isWin)
        {
            OpenPanel(panel_Victory, true, true);
            TrainController._isWin = false;

        }


    }

   public  void OpenPanel(GameObject obj)
    {
        obj.SetActive (true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        opening_panel.Add(obj);
        return;
    }

    public void OpenPanel(GameObject obj,bool Lock)
    {
        obj.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        _lock = Lock;
        opening_panel.Add(obj);
        return;
    }

   public  void OpenPanel(GameObject obj, bool Lock,bool PauseTime)
    {
        obj.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        _lock = Lock;
        Train.GetComponent<TrainController>().gasManager.gas_all = 50;
        opening_panel.Add(obj);
        if (PauseTime)
        {
            Time.timeScale = 0;
        }
        return;
    }

   public  void ClosePanel(GameObject obj)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        obj.SetActive(false);
        opening_panel.RemoveAt(opening_panel.Count - 1);
        return;
    }

public     void ClosePanel(GameObject obj,bool resLock)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        obj.SetActive(false);
        if (_lock&&resLock)
        {
            _lock = !resLock;
        }
        opening_panel.RemoveAt(opening_panel.Count - 1);
        return;
    }

  public   void ClosePanel(GameObject obj, bool resLock,bool resTime)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        obj.SetActive(false);
        if (_lock && resLock)
        {
            _lock = !resLock;
        }
        if (resTime && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        opening_panel.RemoveAt(opening_panel.Count - 1);
        return;
    }

    private void Initialize()
    {
        if (index == 0)
        {
            OpenPanel(panel_Enter);
        }
        _lock = false;
        opening_panel = new List<GameObject>();
        if (Train == null)
        {
            return;
        }
  

        TrainController = Train.GetComponent<TrainController>();




    }


}
