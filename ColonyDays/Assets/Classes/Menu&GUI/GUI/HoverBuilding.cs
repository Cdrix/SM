﻿using UnityEngine;
using System.Collections;

/// <summary>
/// This script will be attaced to all Slots so they can call the Windows Description
/// </summary>
public class HoverBuilding : MonoBehaviour {

    private Rect myRect;//the rect area of my element. Must have attached a BoxCollider2D
    private DescriptionWindow _descriptionWindow;//the window tht will pop up msg

    // Use this for initialization
    void Start()
    {
        //for this to work only one gameObj can have the HoverWindow attached
        if (_descriptionWindow == null)
        {
            _descriptionWindow = FindObjectOfType<DescriptionWindow>();
        }
    }

    public void InitObjects()
    {


        myRect = GetRectFromBoxCollider2D();
    }

    Rect GetRectFromBoxCollider2D()
    {
        var res = new Rect();
        var min = transform.GetComponent<BoxCollider2D>().bounds.min;
        var max = transform.GetComponent<BoxCollider2D>().bounds.max;

        res = new Rect();
        res.min = min;
        res.max = max;

        return res;
    }

    // Update is called once per frame
    void Update()
    {
        //if got in my area
        if (myRect.Contains(Input.mousePosition))
        {
            SpawnHelp();
        }
        //ig got out 
        else if (!myRect.Contains(Input.mousePosition) && ReturnMyType() == _descriptionWindow.CurrentType()
            && ReturnMyType() != H.None)//to avoid None killing tht window
        {
            var therType = _descriptionWindow.CurrentType();
            var myT = ReturnMyType();

            DestroyHelp();
        }
    }

    void SpawnHelp()
    {
        var myType = ReturnMyType();

        if (myType != H.None)
        {
            _descriptionWindow.Show(myType); 
        }
    }

    H ReturnMyType()
    {
        return Program.MouseListener.ReturnThisSlotVal(name);
    }

    void DestroyHelp()
    {
        _descriptionWindow.Hide();
    }
}
