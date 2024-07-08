using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{
   public static Level2Controller instance;
   [SerializeField] private List<PieceElement> listElement;

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
}
