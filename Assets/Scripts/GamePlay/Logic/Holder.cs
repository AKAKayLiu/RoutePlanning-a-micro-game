using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : Interactive
{
    public Sprite normalPicture;
    public Sprite lightenedPicture;
    public HolderName holderName;
    public HashSet<Holder> linkHolders = new HashSet<Holder>();
    public Conections[] currentConnections;
    public GameObject grass;

    //public bool clicked;  

    public void Start()
    {
        normalPicture = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    }


    public void OnClicked()
    {
      
        
            Debug.Log("You have clicked the holder");
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = this.lightenedPicture;
       
        
    }



    //public void CheckBall(Filler ball)
    //{
    //    currentBall = ball;
    //    if (ball.ballDetails.ballName == matchBall)
    //    {
    //        currentBall.isMatch = true;
    //        currentBall.SetRight();
    //    }
    //    else
    //    {
    //        currentBall.isMatch = false;
    //        currentBall.SetWrong();
    //    }
    //}



    //public override void EmptyClicked()
    //{
    //    foreach (var holder in linkHolders)
    //    {
    //        if (holder.isEmpty)
    //        {
    //            //�ƶ���
    //            currentBall.transform.position = holder.transform.position;
    //            currentBall.transform.SetParent(holder.transform);

    //            //������
    //            //holder.CheckBall(currentBall);
    //            this.currentBall = null;

    //            //�ı�״̬
    //            this.isEmpty = true;
    //            holder.isEmpty = false;

    //            //EventHandler.CallCheckGameStateEvent();
    //        }
    //    }
    //}
}
