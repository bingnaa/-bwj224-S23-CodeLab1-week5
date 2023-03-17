using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public void ChangeBack(int index)
    {
        //Debug.Log(gameObject + "" + "" + index);
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("back/back_" + index.ToString()) as Sprite;
        //Debug.Log(GetComponent<SpriteRenderer>().sprite);
    }

}