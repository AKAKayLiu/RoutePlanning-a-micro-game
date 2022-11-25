using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GamePlay_SO", menuName = "Game Data/GamePlay_SO")]
public class GamePlay_SO : ScriptableObject
{
    //[SceneName] 
    public string gameName;
    //[Header("球的名字和对应的图片")]
    //public List<FillerDetails> ballDataList;

    [Header("游戏逻辑数据")]
    public List<Conections> lineConections;
    //public List<FillerName> startFillerOrder;

    //public FillerDetails GetBallDetails(FillerName ballName)
    //{
    //    return ballDataList.Find(b => b.ballName == ballName);
    //}
    // Start is called before the first frame update
}


//[System.Serializable]
//public class FillerDetails
//{
//    public FillerName ballName;
//    public Sprite originalSprite;
//    public Sprite rightSprite;
//}

[System.Serializable]
public class Conections
{
    public int from;
    public int to;
}
