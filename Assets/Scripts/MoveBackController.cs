using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBackController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerScript.walkback = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerScript.walkback = false;
    }

}
