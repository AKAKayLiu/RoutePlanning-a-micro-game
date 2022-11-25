using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//用来设置关卡选择的
public class LevelSelect : MonoBehaviour
{

    public int index;
    public Button[] levels;
    //private int unlocklevel = 1;


    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i<levels.Length; i++)
        {
            levels[i].interactable = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GameController.Instance.unlockLevel; i++)
        {
            levels[i].interactable = true;
        }
    }

    
}
