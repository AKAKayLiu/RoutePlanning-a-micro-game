using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelGameManager : Singleton<LevelGameManager>
{
    [Header("Level Management")]
    public int currentLevel = 1;
    public bool notFirstVisit;
    public LineRenderer linePrefab;
    public LineRenderer newlinePrefab;
    public GameObject startFlag;
    //public GameObject[] levelManagers;

    [Header("BranchMenu")]
    public Button resetGame;
    public Button backToHome;

    //public GameObject passPanel;
    public GameObject noticePanel;
    public GameObject settingPanel;
    

    //public Button nextLevel;
   


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }


    public void Start()
    {
        if (!notFirstVisit)
        {
            //LevelGameManager.Instance.
            this.noticePanel.SetActive(true);
            notFirstVisit = true;
        }
    }

    public int UnlockNewLevel()
    {
        currentLevel++;
        return currentLevel;
    }

    public void LevelInit(int clickedCount, int newLineCount)
    {
        //先清除旧的物体
        clickedCount = 0;
        newLineCount = 0;
        Destroy(GameObject.FindGameObjectWithTag("NewFlag"));

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Grass"))
        {
            Destroy(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("NewLine"))
        {
            Destroy(go);
        };

        Tweener t = LevelGameManager.Instance.resetGame.gameObject.transform.DORotate(new Vector3(0, 0, 270), 2.0f);

        //再生成新的物体
       
        Debug.Log("重置完成");
    }

}
