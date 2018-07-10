using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WalkForwardController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerScript.walkForward = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerScript.walkForward = false;
    }


}
