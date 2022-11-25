using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public int unlockLevel;
    public GamePlay_SO gameData;
    public GamePlay_SO[] gameDataArray = new GamePlay_SO[3];

    [Header("全局设置面板")]
    public GameObject levelSelectPanel;
    public GameObject mainMenu;
    public GameObject winPanel;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        unlockLevel = 1;
        if (PlayerPrefs.HasKey("UnclockLevel"))
        {
            Debug.Log(PlayerPrefs.GetInt("UnlockLevel"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public UnityAction GoToNextLevel(int level)
    {
        //SetGameLevelData(level);
        TransferLevel(level);
        return null;
    }


    public void Quit()
    {
        PlayerPrefs.SetInt("UnlockLevel", unlockLevel);
        Application.Quit();
        Debug.Log("Quited");
    }




    public void TransferLevel(int index)
    {
        SetGameLevelData(index);
        SceneManager.LoadScene(index, LoadSceneMode.Single);
        Debug.LogFormat("转场到第{0}个场景", index);
    }

    public void SetGameLevelData(int level)
    {
        gameData = gameDataArray[level - 1];
    }

   

}
