using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Button generateButton;
    public Button editTrapButton;
    public Button startButton;
    public AStar astar;
    public Text resultText;

    private void Awake()
    {
        
    }

    void Start()
    {
        generateButton.onClick.AddListener(() => { Generate(); });
        editTrapButton.onClick.AddListener(EditTrap);
        startButton.onClick.AddListener(StartPath);
        
    }

    private void Generate()
    {
        if (Global.isGenerated)
        {
            return;
        }
        astar.Generate();
    }

    private void EditTrap()
    {
        Global.isInEditMode = !Global.isInEditMode;
        Debug.LogError("edit mode is on: " + Global.isInEditMode);
    }

    private void StartPath()
    {
        Global.isInEditMode = false;
        astar.LetTheGameBegin();
    }

    public void SetText(string s)
    {
        resultText.text = s;
    }

    void Update()
    {
        
    }
}
