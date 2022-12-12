using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static bool isInEditMode=false;
    public static bool isGenerated = false;
    public UIControl uicontrol;
    public static Global globalInstance;

    private void Awake()
    {
        globalInstance = this;
    }


    void Start()
    {
        
    }

    


    void Update()
    {
        
    }
}
