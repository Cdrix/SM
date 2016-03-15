﻿using System;
using UnityEngine;
using UnityEngine.UI;


public class ShowInvetoryItem : GUIElement
{
    private GameObject _text;
    private GameObject _icon;

    private InvItem _invItem;

    private Text _textObj;
    private Image _iconImg;

    private string _invType;

    private ShowAInventory _parent;

    public InvItem InvItem1
    {
        get { return _invItem; }
        set { _invItem = value; }
    }

    public string InvType
    {
        get { return _invType; }
        set { _invType = value; }
    }

    public ShowAInventory Parent
    {
        get { return _parent; }
        set { _parent = value; }
    }

    // Use this for initialization
	void Start ()
	{
        _text = FindGameObjectInHierarchy("Text", gameObject);
	    _icon = FindGameObjectInHierarchy("Icon", gameObject);

        _textObj = _text.GetComponent<Text>();
        _iconImg = _icon.GetComponent<Image>();

        if (_text != null && InvItem1!=null)
	    {
            //so hover gets it
            _text.transform.name = InvItem1.Key + "";
            LoadIcon();

	    }
	}

    private void LoadIcon()
    {
        var root = Program.gameScene.ExportImport1.ReturnIconRoot(_invItem.Key);
        Sprite sp = Resources.Load<Sprite>(root);

        //debug only bz all should have a root
        if (sp == new Sprite())
        {
            root = "Prefab/GUI/Inventory_Icons/Brick";
            sp = Resources.Load<Sprite>(root);
        }

        _iconImg.sprite = sp;
    }

    static public ShowInvetoryItem Create(Transform container, InvItem invItem, Vector3 iniPos, ShowAInventory parent,
        string invType="")
    {
        ShowInvetoryItem obj = null;

        var root = "";
        if (string.IsNullOrEmpty(invType))
        {
            root = Root.show_Invent_Item_Small_Med_NoBack;
        }
        else
        {
            //for main
            root = Root.show_Invent_Item_Small_Med;
        }

        obj = (ShowInvetoryItem)Resources.Load(root, typeof(ShowInvetoryItem));
        obj = (ShowInvetoryItem)Instantiate(obj, new Vector3(), Quaternion.identity);


        obj.transform.parent = container;
        obj.transform.localPosition = iniPos;


        obj.Parent = parent;
        obj.InvItem1 = invItem;
        obj.InvType = invType;

        return obj;
    }


    private float oldAmt=-100;//the value so it gets started
	// Update is called once per frame
	void Update ()
	{
        if (InvItem1 == null || (InvItem1.Amount <= 0 && string.IsNullOrEmpty(InvType)))
        {
            Parent.Destroy(this);
	        return;
	    }

        if (oldAmt != InvItem1.Amount)
	    {
            oldAmt = InvItem1.Amount;
            _textObj.text = Formatter();
	    }
	}

    string Formatter()
    {
        if (InvItem1.Amount <= 0)
        {
            return "-";
        }

        //Main GUI
        if (InvType=="Main")
        {
            return StandardFormat();
            return ShortFormat();
        }

        //buildign invneotyr 
        //if (string.IsNullOrEmpty(InvType))
        return InvItem1.Key+ " "  + (int)InvItem1.Amount + "kg. v(m3):" + InvItem1.Volume.ToString("F1");
    }

    private string StandardFormat()
    {
        if (InvItem1.Amount < 10)
        {
            return (InvItem1.Amount.ToString("n1"));
        }

        return  ((int)InvItem1.Amount)+"";
    }

    private string ShortFormat()
    {
        if (InvItem1.Amount > 1000000)
        {
            return (int)(InvItem1.Amount / 1000000) + "M";
        }
        if (InvItem1.Amount > 1000)
        {
            return (int)(InvItem1.Amount / 1000) + "K";
        }

        return (int)InvItem1.Amount+"";
    }
}
