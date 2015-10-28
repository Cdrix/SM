﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PersonWindow : GUIElement {

    private Text _title;
    private Text _info;
    private Text _inv;

    private Person _person;

    private Vector3 iniPos;

    private Rect _genBtnRect;//the rect area of my Gen_Btn. Must have attached a BoxCollider2D
    private Rect _invBtnRect;//the rect area of my Gen_Btn. Must have attached a BoxCollider2D

    // Use this for initialization
    void Start()
    {
        InitObj();

        Hide();

        StartCoroutine("ThreeSecUpdate");
    }

    private IEnumerator ThreeSecUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // wait

            //means is showing 
            if (transform.position == iniPos)
            {
                LoadMenu(); 
                //print("Reloaded");
            }
        }
    }

    void InitObj()
    {
        iniPos = transform.position;

        _title = GetChildThatContains(H.Title).GetComponent<Text>();
        _info = GetChildThatContains(H.Info).GetComponent<Text>();
        _inv = GetChildThatContains(H.Bolsa).GetComponent<Text>();

        var genBtn = GetChildThatContains(H.Gen_Btn).transform;
        var invBtn = GetChildThatContains(H.Inv_Btn).transform;

        _genBtnRect = GetRectFromBoxCollider2D(genBtn);
        _invBtnRect = GetRectFromBoxCollider2D(invBtn);
    }


    private Person oldPerson;
    void CheckIfIsDiffNewPerson()
    {
        if (_person != oldPerson)
        {
            Person.UnselectPerson();
        }
        oldPerson = _person;
    }

    public void Show(Person val)
    {
        _person = val;
        CheckIfIsDiffNewPerson();

        LoadMenu();
        MakeAlphaColorZero(_inv);

        transform.position = iniPos;

        _person.SelectPerson();
    }

    private void LoadMenu()
    {
        _title.text = _person.Name + "";
        _info.text = BuildPersonInfo();
        _inv.text = BuildStringInv(_person);
    }

    string BuildPersonInfo()
    {
        string res = "Age:" + _person.Age + " Gender:" + _person.Gender
                     + " Nutrition:" + _person.NutritionLevel + " Profession:" + _person.ProfessionProp.ProfDescription
                     + " ID:" + _person.MyId;

        return res;
    }

    // Update is called once per frame
    void Update()
    {
        //if click gen
        if (_genBtnRect.Contains(Input.mousePosition) && Input.GetMouseButtonUp(0))
        {
            MakeAlphaColorMax(_info);
            MakeAlphaColorZero(_inv);
        }
        //ig click inv
        else if (_invBtnRect.Contains(Input.mousePosition) && Input.GetMouseButtonUp(0))
        {
            MakeAlphaColorMax(_inv);
            MakeAlphaColorZero(_info);
        }
    }

    public override void Hide()
    {
        base.Hide();

        Person.UnselectPerson();
    }
}
