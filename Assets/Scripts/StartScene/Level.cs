using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Level : MonoBehaviour
{

    public int levelIndex;
    private Button btn;


    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => SelectLevel(this.levelIndex));
    }

    private void SelectLevel(int index)
    {
        GameController.Instance.TransferLevel(index);
        GameController.Instance.levelSelectPanel.SetActive(false);
        if (LevelGameManager.Instance)
        {
            LevelGameManager.Instance.settingPanel.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
