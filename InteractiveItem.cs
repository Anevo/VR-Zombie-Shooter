﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class InteractiveItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image progressImage; // add an image as child to your button object and set its image type to Filled. Assign it to this field in inspector.
    public bool isEntered = false;
    RectTransform rt;
    Button _button;
    float timeElapsed;
    Image cursor;
    float GazeActivationTime = 5;

    // Use this for initialization
    void Awake()
    {
        _button = GetComponent<Button>();
        rt = GetComponent<RectTransform>();

    }

    

    void Update()
    {
        if (isEntered)
        {
            timeElapsed += Time.deltaTime;
            progressImage.fillAmount = Mathf.Clamp(timeElapsed / GazeActivationTime, 0, 1);
            if (timeElapsed >= GazeActivationTime)
            {
                timeElapsed = 0;
                _button.onClick.Invoke();
                progressImage.fillAmount = 0;
                isEntered = false;
            }
        }
        else
        {
            timeElapsed = 0;
        }
    }

    #region IPointerEnterHandler implementation

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEntered = true;
    }

    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {
        isEntered = false;
        progressImage.fillAmount = 0;
    }
    #endregion
}