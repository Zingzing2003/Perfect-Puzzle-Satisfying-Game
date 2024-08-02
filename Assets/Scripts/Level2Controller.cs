using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{
   public static Level2Controller instance;
   [SerializeField] private List<PieceElement> listElement;
   public SkeletonGraphic skeletonAnimation;

   public int max;

   private void Awake()
   {
      instance = this;
      max = listElement.Count;
      // foreach (PieceElement piece in listElement)
      // {
      //    if (piece.isDone .Equals(true) )
      //    {
      //       max--;
      //       if (max == 0)
      //       {
      //          GameManager.instance.WinGame();
      //       }
      //    }
      // }



   }

   public void WinGame()
   {
      skeletonAnimation.AnimationState.SetAnimation(0, "change", false);

      skeletonAnimation.AnimationState.AddAnimation(0, "end", true, 0);


      //skeletonAnimation.startingAnimation()
      GameManager.instance.WinGame();
   }

}