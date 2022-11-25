using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseManager : Singleton<MouseManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    internal Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    private bool canClick;
    private bool isInitial = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canClick = ObjectAtMousePosition();

        if (canClick && Input.GetMouseButtonDown(0))
        {
            //检测鼠标互动情况
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }

    private void ClickAction(GameObject clickObject)
    {
        switch (clickObject.tag)
        {
            case "Holder":
                {
                    
                    var holder = clickObject.GetComponent<Holder>();
                    holder.OnClicked();
                    switch (LevelGameManager.Instance.currentLevel)
                    {
                        case 1:
                            {
                                GameManagerLevel1.Instance.RecordClick(holder);
                                break;
                            }
                        case 2:
                            {
                                GameManagerLevel2.Instance.RecordClick(holder);
                                break;
                            }
                        case 3:
                            {
                                GameManagerLevel3.Instance.RecordClick(holder);
                                break;
                            }
                        case 4:
                            {
                                GameManagerLevel4.Instance.RecordClick(holder);
                                break;
                            }
                         default:
                            break;
                    }
                    
                    
                        break;
                }
           
        }
    }

    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
