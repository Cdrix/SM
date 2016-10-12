﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class BuildingWindow : GUIElement {

    private Text _title;
    private Text _info;
    private Text _inv;
    private Text _displayProdInfo;

    private Building _building;

    private Vector3 iniPos;

    private Rect _genBtnRect;//the rect area of my Gen_Btn. Must have attached a BoxCollider2D
    private Rect _invBtnRect;//the rect area of my Gen_Btn. Must have attached a BoxCollider2D
    private Rect _ordBtnRect;//the rect area of my Gen_Btn. Must have attached a BoxCollider2D
    private Rect _prdBtnRect;//the rect area of my Gen_Btn. Must have attached a BoxCollider2D
    private Rect _upgBtnRect;

    private GameObject _ordBtn;//the btn for orders
    private GameObject _prdBtn;//the btn for 

    //tabs
    private GameObject _general;
    private GameObject _gaveta;
    private GameObject _upgrades;
    private GameObject _products;
    private GameObject _orders;

    private GameObject _invIniPos;

    private Vector3 _importIniPos;
    private Vector3 _exportIniPos;    
    
    private Vector3 _importIniPosOnProcess;
    private Vector3 _exportIniPosOnProcess;

    private GameObject _salary;


    //upg btns
    private GameObject _upg_Mat_Btn;
    private GameObject _upg_Cap_Btn; //Upg_Mat_Btn

    private GameObject _demolish_Btn; //Upg_Mat_Btn
    private GameObject _cancelDemolish_Btn; //Upg_Mat_Btn


    //Salary
    private Text _currSalaryTxt;




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
            yield return new WaitForSeconds(0.1f); // wait

            var samePos = UMath.nearEqualByDistance(transform.position, iniPos, 1);
            var buildNull = _building == null;
            
            //means is showing 
            if (samePos && !buildNull && BuildingPot.Control.Registro.SelectBuilding != null)
            {
                LoadMenu();

                //then orders need to be reloaded from dispatch and shown on Tab
                if (_orders.gameObject.activeSelf == _orders)
                {
                    ShowOrders();
                } 
            }
        }
    }

    void InitObj()
    {
        iniPos = transform.position;

        _general = GetChildThatContains(H.General);
        _gaveta = GetChildThatContains(H.Gaveta);
        _orders = GetChildThatContains(H.Orders);
        _products = GetChildThatContains(H.Products);
        _upgrades = GetChildCalled(H.Upgrades);


        _salary = General.FindGameObjectInHierarchy("Salary", _general);
        
        var currSalary = FindGameObjectInHierarchy("Current_Salary", _salary);
        _currSalaryTxt = currSalary.GetComponent<Text>();

        
        _title = GetChildCalled(H.Title).GetComponent<Text>();


        _info = GetGrandChildCalled(H.Info).GetComponent<Text>();
        _inv = GetGrandChildCalled(H.Bolsa).GetComponent<Text>();//bolsa bz tht algorith has a bugg tht names cannot be the same or start with the same
        
        _displayProdInfo = GetGrandChildCalled(H.Display_Lbl).GetComponent<Text>();//bolsa bz tht algorith has a bugg tht names cannot be the same or start with the same

        _invIniPos = GetGrandChildCalled(H.Inv_Ini_Pos);



        var genBtn = GetChildThatContains(H.Gen_Btn).transform;
        var invBtn = GetChildThatContains(H.Inv_Btn).transform;
        _ordBtn = GetChildThatContains(H.Ord_Btn);

        var upgBtn = GetChildCalled(H.Upg_Btn).transform;
        var prdBtn = GetChildCalled(H.Prd_Btn).transform;
        _prdBtn = GetChildThatContains(H.Prd_Btn);


        _genBtnRect = GetRectFromBoxCollider2D(genBtn);
        _invBtnRect = GetRectFromBoxCollider2D(invBtn);
        _ordBtnRect = GetRectFromBoxCollider2D(_ordBtn.transform);
        _upgBtnRect = GetRectFromBoxCollider2D(upgBtn.transform);
        _prdBtnRect = GetRectFromBoxCollider2D(prdBtn.transform);


        _importIniPos = GetGrandChildCalled(H.IniPos_Import).transform.position;
        _exportIniPos = GetGrandChildCalled(H.IniPos_Export).transform.position;

        _importIniPosOnProcess = GetGrandChildCalled(H.IniPos_Import_OnProcess).transform.position;
        _exportIniPosOnProcess = GetGrandChildCalled(H.IniPos_Export_OnProcess).transform.position;


        _upg_Mat_Btn = GetGrandChildCalled(H.Upg_Mat_Btn);
        _upg_Cap_Btn = GetGrandChildCalled(H.Upg_Cap_Btn);


        _demolish_Btn = GetGrandChildCalled(H.Demolish_Btn);//Cancel_Demolish_Btn
        _cancelDemolish_Btn = GetGrandChildCalled(H.Cancel_Demolish_Btn);//Cancel_Demolish_Btn

    }

    /// <summary>
    /// The show of the menu in a building 
    /// </summary>
    /// <param name="val"></param>
    public void Show(Building val)
    {
        _building = val;

        if (_building.HType == H.Road)
        {
            return;
        }

        LoadMenu();

        //so if last Window had the Inventory selected can be seen in this new builidng one too
        MakeThisTabActive(oldTabActive);

        transform.position = iniPos;
        HandleOrdBtn();
        HandlePrdBtn();

        //in case were inactive 
        
        
        //_upg_Mat_Btn.SetActive(true);
        _upg_Cap_Btn.SetActive(true);

        CheckIfMatMaxOut();
        CheckIfCapMaxOut();

        HideSalaryIfHouseOrStorage();

    }

    private void DemolishBtn()
    {
        _cancelDemolish_Btn.SetActive(false);
        bool fullyBuilt = IsFullyBuilt();
       
        if (_building.Instruction == H.WillBeDestroy || !fullyBuilt)
        {
            _demolish_Btn.SetActive(false);
            //_cancelDemolish_Btn.SetActive(true);
        }
        else
        {
            //todo uncomment so it active
            //_demolish_Btn.SetActive(true);
        }
    }

    bool IsFullyBuilt()
    {
        if (_building.MyId.Contains("Road"))
        {
            //so user will never be able to be removed 
            return false;
        }

        if (!_building.MyId.Contains("Bridge")  )
        {
            var st = (Structure)_building;
            if (st.CurrentStage == 4)
            {
                return true;
            }
        }
        //addres bridge 
        else
        {
            var bridge = (Bridge) _building;
            if (bridge.StartingStageForPieces == H.Done)
            {
                return true;
            }
        }
        return false;
    }

    private void HideSalaryIfHouseOrStorage()
    {
        if (_building.IsHouse() || _building.MyId.Contains("Storage") || _building.Category == Ca.Way)
        {
           _salary.SetActive(false);
        }
        else
        {
            _salary.SetActive(true);
        }
    }

    /// <summary>
    /// Bz Houses, Gov, Trade Structures, Ways , etc dont have a prod the prod tab must be 
    /// hidden
    /// 
    /// 
    /// </summary>
    private void HandlePrdBtn()
    {
        //todo add all houses, trade, gov as Cointned in their Enum Cat
        if (isToHidePrdTab())
        {
            _prdBtn.SetActive(false);
        }
        else
        {
            _prdBtn.SetActive(true);
        }
    }

    bool isToHidePrdTab()
    {
        return _building.HType.ToString().Contains("House") || _building.Category == Ca.Way || _building.IsNaval();
    }

    /// <summary>
    /// Will hide it if not Dock or ...
    /// </summary>
    void HandleOrdBtn()
    {
        if (_building.HType != H.Dock || _building.HType != H.Shipyard || _building.HType != H.Supplier)
        {
            _ordBtn.SetActive(false);
        }
        if (_building.HType == H.Dock || _building.HType == H.Shipyard || _building.HType == H.Supplier)
        {
            _ordBtn.SetActive(true);
        }
    }

    private ShowAInventory _showAInventory;
    private int oldItemsCount;
    private string oldBuildID;
    private void LoadMenu()
    {
        _title.text = _building.HType + "";
        _info.text = BuildInfo() + BuildCover();

        if (_showAInventory == null)
        {
            _showAInventory = new ShowAInventory(_building.Inventory, _gaveta.gameObject, _invIniPos.transform.localPosition);
        }
        else if (_showAInventory != null && ( 
            oldItemsCount != _building.Inventory.InventItems.Count ||
            oldBuildID != _building.MyId ||
            _building.IsToReloadInv())
            )
        {
            oldItemsCount = _building.Inventory.InventItems.Count;

            oldBuildID = _building.MyId;
            _showAInventory.DestroyAll();
            _showAInventory = new ShowAInventory(_building.Inventory, _gaveta.gameObject, _invIniPos.transform.localPosition);
        }
        
        _showAInventory.ManualUpdate();
        _inv.text = BuildStringInv(_building);

       
        _currSalaryTxt.text = BuildingPot.Control.Registro.SelectBuilding.DollarsPay+"";
        DemolishBtn();
    }

    /// <summary>
    /// Schools, Church, and Tavern have coverage 
    /// </summary>
    /// <returns></returns>
    private string BuildCover()
    {
        if (_building.MyId.Contains("Bridge"))
        {
            return "";
        }

        var st = (Structure) _building;
        return st.CoverageInfo();
    }





    string BuildInfo()
    {
        string res = Languages.ReturnString(_building.HType+".Desc") + "\n\n";

        res += IfInConstructionAddPercentageOfCompletion();
        
        var isAHouse = _building.HType.ToString().Contains("House") || _building.HType == H.Bohio;

        //is not a house or bohio 
        if (!isAHouse || _building.HType == H.LightHouse)//must say lightHouse here bz actualkly contains House
        {
            //if is Storage
            if (_building.HType.ToString().Contains("Storage"))
            {
                res += "\nUsers:" + _building.PeopleDict.Count + "\n";
            }
            //others
            else
            {
                res += "\nWorkers:" + _building.PeopleDict.Count + "\n";
                for (int i = 0; i < _building.PeopleDict.Count; i++)
                {
                    res += "\n " + Family.RemovePersonIDNumberOff(_building.PeopleDict[i]);
                }
            }

            if (_building.HType == H.Masonry)
            {
                res += "\n\n Buildings ready to be built:";

                for (int i = 0; i < _building.BuildersManager1.GreenLight.Count; i++)
                {
                    res += "\n" + _building.BuildersManager1.GreenLight[i].Key;
                }
            }
        }
        //is a house or bohio 
        else
        {
            var amt = 0;
            for (int i = 0; i < _building.Families.Count(); i++)
            {
                amt += _building.Families[i].MembersOfAFamily();
            }

            res += " People living in this house:" + amt + "";

            for (int i = 0; i < _building.Families.Count(); i++)
            {
                res += _building.Families[i].InfoShow();
            }
        }

        return res
#if UNITY_EDITOR
               + DebugInfo()
#endif
            ;

    }

    /// <summary>
    /// If is in construction will add percentage of completion 
    /// </summary>
    /// <returns></returns>
    private string IfInConstructionAddPercentageOfCompletion()
    {
        var sP = (StructureParent) _building;

        if (sP.CurrentStage != 4)
        {
            var percentage = sP.PercentageBuiltCured();
            return "Construction progress at: " + percentage + "%\n\n";
        }
        return "";
    }

    private string DebugInfo()
    {
        string res = "\n___________________\n";

        //is not a house or bohio 
        if (!_building.HType.ToString().Contains("House") && _building.HType != H.Bohio)
        {
            res += "Type:" + _building.HType
             + "\n ID:" + _building.MyId
            + "\n MaxWorkers:" + Book.GiveMeStat(_building.HType).MaxPeople
            + "\n Workers:";
        }
        else
        {
           res += "Type:" + _building.HType + 
                " ID:" + _building.MyId
                ;

           if (_building.BookedHome1 != null)
           {
               res += " IsBooked:" + _building.BookedHome1.IsBooked();
           }
           else
           {
               res += " IsBooked: no";
           }
        }

        return res;
    }


    #region Salary




    /// <summary>
    /// When the use clicks to change the salary on a building 
    /// </summary>
    /// <param name="action"></param>
    public void ClickedOnChangeSalaryCheckBox(string action)
    {

        //change salary
        _currSalaryTxt.text = BuildingPot.Control.Registro.SelectBuilding.ChangeSalary(action);
    }





#endregion

    // Update is called once per frame
    void Update()
    {
        //if click gen
        if (_genBtnRect.Contains(Input.mousePosition) && Input.GetMouseButtonUp(0))
        {
            MakeThisTabActive(_general);
        }
        //ig click inv
        else if (_invBtnRect.Contains(Input.mousePosition) && Input.GetMouseButtonUp(0))
        {
            MakeThisTabActive(_gaveta);
        }
        //if click ord
        else if (_building!=null && _ordBtnRect.Contains(Input.mousePosition) && Input.GetMouseButtonUp(0) 
            && _building.IsNaval())
        {
            MakeThisTabActive(_orders);
        }
        else if (_upgBtnRect.Contains(Input.mousePosition) && Input.GetMouseButtonUp(0))
        {
            MakeThisTabActive(_upgrades);
        }
        else if (_prdBtnRect.Contains(Input.mousePosition) && Input.GetMouseButtonUp(0))
        {
            MakeThisTabActive(_products);
        }
    }


    private GameObject oldTabActive;
    /// <summary>
    /// Use to swith Tabs on Window. Will hide all and make the pass one as active
    /// </summary>
    /// <param name="g"></param>
    void MakeThisTabActive(GameObject g)
    {
        if (_building == null || _orders == null || _products == null)
        {
            return;
        }

        //first time loaded ever in game 
        if (g == null || (!_building.IsNaval() && g == _orders) || (g == _products && isToHidePrdTab()))
        {
            g = _general;
        }

        _general.SetActive(false);
        _gaveta.SetActive(false);
        _orders.SetActive(false);
        _upgrades.SetActive(false);
        _products.SetActive(false);

        g.SetActive(true);
        oldTabActive = g;

        //then orders need to be Pull from dispatch and shown on Tab
        if (g == _orders)
        {
            ShowOrders();
        }
        if (g == _products)
        {
            ShowProducts();
        }
    }


    //Show Prod on Tab
    private void ShowProductDetail()
    {
        _displayProdInfo.text = _building.CurrentProd.Details;
    }

    private void ShowProducts()
    {
        DestroyAndCleanShownOrders();

        var list = _building.ShowProductsOfBuild();
        DisplayProducts(list, Root.showGenBtnLarge);

        ShowProductDetail();
    }

    void DisplayProducts(List<ProductInfo> list, string root)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Display1String(i, list[i], root);
        }
    }

    void Display1String(int i, ProductInfo pInfo, string root)
    {
        var orderShow = OrderShow.Create(root, _products.transform);
        orderShow.ShowToSetCurrentProduct(pInfo);

        orderShow.Reset(i);

        _showOrders.Add(orderShow);
    }






    ///Show  Orders on tab

    /// <summary>
    /// Show orders routine
    /// </summary>
    public void ShowOrders()
    {
        DestroyAndCleanShownOrders();

        ShowImportOrders();
        ShowImportOrdersOnProcess();

        ShowExportOrders();
        ShowExportOrdersOnProcess();
    }



    private void ShowExportOrders()
    {
        var expOrd = _building.Dispatch1.ReturnRegularOrders();
        DisplayOrders(expOrd, _exportIniPos, Root.orderShowClose);
    }

    void ShowExportOrdersOnProcess()
    {
        var expOrd  =  _building.Dispatch1.ReturnRegularOrdersOnProcess();
        DisplayOrders(expOrd, _exportIniPosOnProcess, Root.orderShow);
    }

    /// <summary>
    /// Show import orders
    /// </summary>
    void ShowImportOrders()
    {
        //todo not show orders to cancel when on Dock Inventory
        //var impOrd = _building.Dispatch1.ReturnEvacuaOrders();
        var impOrd = _building.Dispatch1.ReturnEvacOrdersOnProcess();
        DisplayOrders(impOrd, _importIniPos, Root.orderShowClose);
    }

    private void ShowImportOrdersOnProcess()
    {
        //var impOrd = _building.Dispatch1.ReturnEvacOrdersOnProcess();
        var impOrd = _building.Dispatch1.ReturnEvacuaOrders();
        DisplayOrders(impOrd, _importIniPosOnProcess, Root.orderShow);
    }

    /// <summary>
    /// Display the orders are passed on 'list'
    /// </summary>
    /// <param name="list"></param>
    /// <param name="iniPosP"></param>
    void DisplayOrders(List<Order> list, Vector3 iniPosP, string root)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Display1Order(i, list[i], iniPosP, root);
        }
    }


    List<OrderShow> _showOrders = new List<OrderShow>(); 
    /// <summary>
    /// Will display the order is pass as param. Bz 'i' will keep looping and puttin the towards the botton of the 
    /// _orders tab. Will make the orders Childs of _order tab
    /// </summary>
    /// <param name="i"></param>
    /// <param name="order"></param>
    /// <param name="iniPosP"></param>
    void Display1Order(int i, Order order, Vector3 iniPosP, string root)
    {
        var orderShow = OrderShow.Create(root, _orders.transform);
        orderShow.Show(order);

        orderShow.Reset(i, order.TypeOrder, _importIniPos, _importIniPosOnProcess);

        _showOrders.Add(orderShow);
    }

    /// <summary>
    /// Will destoy all orders Shown
    /// </summary>
    void DestroyAndCleanShownOrders()
    {
        for (int i = 0; i < _showOrders.Count; i++)
        {
            _showOrders[i].Destroy();
        }
        _showOrders.Clear();
    }




    /// <summary>
    /// bz when a building is max out in material then the bttuon will hide 
    /// </summary>
    void HideUpgMatBtn()
    {
        _upg_Mat_Btn.SetActive(false);
    }

    /// <summary>
    /// bz when a building is max out in capacity then the bttuon needs to be  hide 
    /// </summary>
    void HideUpgCapBtn()
    {
        _upg_Cap_Btn.SetActive(false);
    }


    /// <summary>
    /// Once the Upgrate mat bottuon is clicked .
    /// </summary>
    public void ClickedUpdMatBtn()
    {
        _building.UpgradeMatToNext();
        CheckIfMatMaxOut();
    }


    /// <summary>
    /// Upgradint capacity
    /// </summary>
    internal void ClickedUpdCapBtn()
    {
        _building.UpgradeCapToNext();
        CheckIfCapMaxOut();

        _inv.text = BuildStringInv(_building);
    }

    /// <summary>
    /// if has the best material will hide tht button
    /// </summary>
    void CheckIfMatMaxOut()
    {
        if (_building.IsBuildingMaterialBest())
        {
            HideUpgMatBtn();
        }
    }

    /// <summary>
    /// if has the best material will hide tht button
    /// </summary>
    void CheckIfCapMaxOut()
    {
        if (_building.IsBuildingCapAtMax())
        {
            HideUpgCapBtn();
        }
    }

    /// <summary>
    /// Called if Mouse listener is called with this : 'BuildingForm.'
    /// </summary>
    /// <param name="action"></param>
    internal void FeedFromForm(string action)
    {
        //remove the 'BuildingForm.'
        var sub = action.Substring(13);

        if (sub.Contains("Set.Current.Prod"))
        {
            //remove the 'Set.Current.Prod.'
            var rem = sub.Substring(17);
            SetCurrentProduct(rem);
        }
    }

    /// <summary>
    /// Will set current prod on selected buildng
    /// </summary>
    /// <param name="product"></param>
    void SetCurrentProduct(string product)
    {
        _building.SetProductToProduce(product);

        ShowProductDetail();
    }

    internal void Reload()
    {
        Show(_building);
    }
}
