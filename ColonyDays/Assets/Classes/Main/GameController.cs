﻿/*
 * This is a really omportatn class. This is the one the control the whole game in sense of inventory.
 * Holds the inventory of the game
 * 
 * 
 * Controls the game in the sense to which Scene with BUilding with Person Load.
 * Or create new game 
 */
public class GameController  {

    //Main inventory of the game .. wht u see on the GUI 
    //will have all tht is in all Storages combined 
    //is a total inventory. Representing all tht is in those inventories 
    static ResumenInventory _inventory = new ResumenInventory();

    private float _dollars;//the dollars the player has 
    private static StartingCondition _startingCondition;

    private int _lastYearWorkersSalaryWasPaid;

    static public ResumenInventory Inventory1
    {
        get { return _inventory; }
        set
        {
            
            _inventory = value;
        }
    }

    public float Dollars
    {
        get { return _dollars; }
        set
        {
            MyText.ManualUpdate();
            _dollars = value;
        }
    }

    /// <summary>
    /// Says the last year the salaray was paid 
    /// </summary>
    public int LastYearWorkersSalaryWasPaid
    {
        get { return _lastYearWorkersSalaryWasPaid; }
        set { _lastYearWorkersSalaryWasPaid = value; }
    }


    static public void LoadStartingConditions(StartingCondition startingCondition)
    {
        _startingCondition = startingCondition;

        //if (!Inventory1.IsEmpty())// the inventory here is not empty means was loaded already)
        //{
        //    return;
        //}
        

        //var inv = CreateInitialInv(startingCondition);

        //LoadIntoInv(inv);
    }

    Inventory CreateInitialInv(StartingCondition startingCondition)
    {
        Dollars += startingCondition.iniDollar;
        Inventory inv = new Inventory();

        inv.Add(P.Wood, startingCondition.iniWood);
        inv.Add(P.Food, startingCondition.iniFood);

        inv.Add(P.Stone, startingCondition.iniStone);
        inv.Add(P.Brick, startingCondition.iniBrick);
        inv.Add(P.Iron, startingCondition.iniIron);

        inv.Add(P.Gold, startingCondition.iniGold);

        //todo remove when release
        //inv.Add(P.Coal, 100000);
        //inv.Add(P.Sugar, 100000);

        return inv;
    }

    /// <summary>
    /// Will load the Starting conditions into the 1st Storage Type of building.
    /// This is done only at first when game is created
    /// </summary>
    static void LoadIntoInv(Inventory invt)
    {
        if (BuildingPot.Control.FoodSources.Count == 0 )
        {
            return;
        }

        var key = BuildingPot.Control.FoodSources[0];

        var storage = Brain.GetStructureFromKey(key);

        storage.Inventory.AddItems(invt.InventItems);
    }

    /// <summary>
    /// The first Storage will call this so the first Lote is get into there 
    /// </summary>
    public void SetInitialLote()
    {
        var inv = CreateInitialInv(_startingCondition);
        LoadIntoInv(inv);
    }

    public void Update()
    {
        CheckIfSalariesNeedToBePaid();
    }

    private void CheckIfSalariesNeedToBePaid()
    {
        if (LastYearWorkersSalaryWasPaid < Program.gameScene.GameTime1.Year
            && Program.gameScene.GameTime1.Month1 == 1)
        {
            LastYearWorkersSalaryWasPaid = Program.gameScene.GameTime1.Year;
            SalariesPay();
            PirateThreat();
        }
    }



    void SalariesPay()
    {
        Dollars -= BuildingPot.Control.Registro.ReturnYearSalary();
    }

    private void PirateThreat()
    {
        if (Dollars > 10000)
        {
            var pts = Dollars/10000;

            //add gold,silver,etc

            BuildingPot.Control.DockManager1.AddToPirateThreat(pts);
        }
    }
}
