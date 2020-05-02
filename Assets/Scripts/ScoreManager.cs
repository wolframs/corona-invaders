﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    public float templateHeight = 60f;

    private void Awake()
    {
        //entryContainer = transform.Find("hsEntryContainer");
        //entryTemplate = transform.Find("hsEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
}
