﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class PersonBuildingDetailTile : GUIElement
{
    private string _key;
    private string _val;
    private Text _descText;
    private Text _valText;

    private UnityEngine.UI.Button _showPath;
    private UnityEngine.UI.Button _showLoc;

    private Person _person;

    public string Key
    {
        get { return _key; }
        set { _key = value; }
    }

    public string Val
    {
        get { return _val; }
        set { _val = value; }
    }

    public Person Person1
    {
        get { return _person; }
        set { _person = value; }
    }


    internal static PersonBuildingDetailTile Create(Transform container,
        KeyValuePair<string, string> keyValuePair, Vector3 iniPos,
        ShowAPersonBuildingDetails showAPersonBuildingDetails, Person person)
    {
        PersonBuildingDetailTile obj = null;

        var root = "";

        obj = (PersonBuildingDetailTile)Resources.Load(Root.show_Person_Place_Location, typeof(PersonBuildingDetailTile));
        obj = (PersonBuildingDetailTile)Instantiate(obj, new Vector3(), Quaternion.identity);

        var iniScale = obj.transform.localScale;
        obj.transform.SetParent(container);
        obj.transform.localPosition = iniPos;
        obj.transform.localScale = iniScale;

        obj.Key = keyValuePair.Key;
        obj.Val = keyValuePair.Value;
        obj.Person1 = person;

        return obj;
    }

    void Start()
    {
        _showPath = FindGameObjectInHierarchy("ShowPath", gameObject).GetComponent<UnityEngine.UI.Button>();
        _showLoc = FindGameObjectInHierarchy("ShowLocation", gameObject).GetComponent<UnityEngine.UI.Button>();

        //set events based on key and button type
        _showPath.onClick.AddListener(() => _person.ToggleShowPath(_key));
        _showLoc.onClick.AddListener(() => _person.ShowLocationOf(_key));

        //set values on the Tile
        _descText = FindGameObjectInHierarchy("Item_Desc", gameObject).GetComponent<Text>();
        _valText = FindGameObjectInHierarchy("Item_Value", gameObject).GetComponent<Text>();


        var goBtnPath = FindGameObjectInHierarchy("ShowPath", gameObject);
        var goBtnLoc = FindGameObjectInHierarchy("ShowLocation", gameObject);
        //if doesnt use the button then the button is hidden
        if (!DoesKeyShowPath() || _val == "None")
        {
            goBtnPath.gameObject.SetActive(false);
        } 
        if (!DoesKeyShowLoc() || _val == "None")
        {
            goBtnLoc.gameObject.SetActive(false);
        }

        SetVal();
    }

    bool DoesKeyShowPath()
    {
        return _key == "Home" || _key == "Work" || _key == "Food source" || _key == "Religion" ||
            _key == "Relax";
    }  
    
    bool DoesKeyShowLoc()
    {
        return _key == "Home" || _key == "Work" || _key == "Food source" || _key == "Religion" ||
            _key == "Relax";
    }

    void SetVal()
    {
        _descText.text = _key;
        _valText.text = _val;
    }


    void Update()
    {

    }


    internal void ManualUpdate(Person person, KeyValuePair<string, string> keyValuePair)
    {
        _person = person;
        _key = keyValuePair.Key;
        _val = keyValuePair.Value;

        SetVal();
    }

}

