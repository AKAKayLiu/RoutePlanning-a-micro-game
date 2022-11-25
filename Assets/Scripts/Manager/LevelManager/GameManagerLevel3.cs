using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManagerLevel3 : MonoBehaviour
{
    [Header("�ؿ�����")]

    public static GameManagerLevel3 Instance;


    public GameObject lineParent;


    //public Filler filler;

    public Transform[] holderTransforms;
    //public Transform[] clickedHolderTransforms;

    public Dictionary<int, Holder> clickedHolders = new Dictionary<int, Holder>();
    public int clickedCount;


    [Header("UI������")]
    public Button nextLevel3;
    public Button resetOnPanel;
    public Button closeBtn;
    public GameObject passPanel;

    [Header("��������")]
    public int newLineCount;
    public GameObject startFlagParent;
    public GameObject[] grasses;


    //System.Random random = new System.Random(100);
    //public int RandomRange(int min, int max)
    //{
    //    return random.Next(min, max);
    //}

    protected void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelGameManager.Instance.currentLevel = 3;
        StartDrawLine();
        StartDrawGrass();

        LevelGameManager.Instance.resetGame.gameObject.GetComponent<Button>().onClick.AddListener(() => LevelInit());

        resetOnPanel.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            passPanel.SetActive(false);
            LevelInit();

        }
        );
        nextLevel3.gameObject.GetComponent<Button>().onClick.AddListener(() => {
            passPanel.SetActive(false);
            Debug.Log("������һ��");
            //LevelGameManager.Instance.currentLevel++;
            GameController.Instance.GoToNextLevel(4);
        });
        LevelGameManager.Instance.backToHome.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            GameController.Instance.levelSelectPanel.SetActive(true);
            LevelGameManager.Instance.settingPanel.SetActive(false);

        });
        closeBtn.onClick.AddListener(() => passPanel.SetActive(false));
    }

    private void StartDrawGrass()
    {
        foreach (var item in holderTransforms)
        {
            //item.GetComponent<Image>().overrideSprite = grasses[Random.Range(0, 4)];
            var overSprite = Instantiate(grasses[Random.Range(0, 8)], item.transform);
            overSprite.transform.position = item.position;
            Debug.LogFormat("���ɲ�");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPassed())
        {
            passPanel.SetActive(true);

            GameController.Instance.unlockLevel = 4;
        }
    }

    public void LevelInit()
    {
        //������ɵ�����
        clickedCount = 0;
        //LevelGameManager.Instance.LevelInit(clickedCount, newLineCount);
        clickedHolders.Clear();
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

        //�������µ�����
        Start();
        Debug.Log("֧���������");
    }



    public void StartDrawLine()
    {
        foreach (var conections in GameController.Instance.gameData.lineConections)
        {
            var line = Instantiate(LevelGameManager.Instance.linePrefab, lineParent.transform);
            line.SetPosition(0, holderTransforms[conections.from].position);
            line.SetPosition(1, holderTransforms[conections.to].position);

            //����ÿ��Holder�����ӹ�ϵ
            holderTransforms[conections.from].GetComponent<Holder>().linkHolders.Add(holderTransforms[conections.to].GetComponent<Holder>());
            holderTransforms[conections.to].GetComponent<Holder>().linkHolders.Add(holderTransforms[conections.from].GetComponent<Holder>());
        }
    }

    public void RecordClick(Holder holder)
    {
        if (clickedCount == 0)
        {

            Debug.LogFormat("��{0}�ε��", clickedCount);
            AudioSource.PlayClipAtPoint(AudioManager.Instance.click, holder.transform.position);
            clickedHolders.Add(clickedCount, holder);
            //Ϊ��һ���������־
            Destroy(holder.transform.GetChild(0).gameObject);
            GameObject start = Instantiate(LevelGameManager.Instance.startFlag, startFlagParent.transform);
            start.transform.position = holder.transform.position;
            //DrawLine();
            clickedCount++;
        }
        else
        {
            foreach (var v in clickedHolders[clickedCount - 1].linkHolders)
            {
                if (holder == v)
                {

                    Debug.LogFormat("��{0}�ε��", clickedCount);
                    AudioSource.PlayClipAtPoint(AudioManager.Instance.click, holder.transform.position);
                    clickedHolders.Add(clickedCount, holder);
                    //holder.grass.SetActive(false);
                    //if (holder.transform.FindChild().childCount>0)
                    //{
                    //    Destroy(holder.transform.GetChild(0).gameObject);
                    //}
                    foreach (Transform child in holder.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    DrawLine();
                    clickedHolders[clickedCount].linkHolders.Remove(clickedHolders[clickedCount - 1]);



                    clickedCount++;

                }
                else
                {
                    //Debug.Log("û�е�·ͨ��������");
                    continue;
                }

            }
        }

    }

    public void DrawLine()
    {


        var newline = Instantiate(LevelGameManager.Instance.newlinePrefab, lineParent.transform);
        newline.SetPosition(0, clickedHolders[clickedCount - 1].gameObject.transform.position);
        newline.SetPosition(1, clickedHolders[clickedCount].gameObject.transform.position);

        newLineCount++;


    }


    public bool IsPassed()
    {   //���ÿ����ظ���������

        if (clickedCount >= holderTransforms.Length && newLineCount == GameController.Instance.gameData.lineConections.Count)
            return true;
        else
            return false;
    }



    public void OnDestroy()
    {
        //clickedHolders.Clear();
        //clickedCount = 0;

        ////clickConnections.Clear();
        Debug.Log("���ٳ���1");
    }


}
