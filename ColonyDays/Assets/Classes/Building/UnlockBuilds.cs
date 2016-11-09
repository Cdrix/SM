﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This class will in one event will define wich building are unlock
/// to be built. the others all will be locked by default 
/// </summary>
public class UnlockBuilds
{
    private List<BRequires> _list;
    private Dictionary<H, BRequires> _dict = new Dictionary<H, BRequires>();

    public UnlockBuilds()
    {
        Init();
        //maps the dict
        for (int i = 0; i < _list.Count; i++)
        {
            _dict.Add(_list[i].HType, _list[i]);
        }
        UpdateBuildsStatuses();
    }

    private void Init()
    {
        _list = new List<BRequires>()
        {
            //infr
            new BRequires(H.Road, H.OnlyForDev),
            new BRequires(H.BridgeTrail, H.OnlyForDev),
            new BRequires(H.BridgeRoad, H.OnlyForDev),
            new BRequires(H.LightHouse, 40),
            new BRequires(H.Masonry, true),
            new BRequires(H.Loader, H.OnlyForDev),
            new BRequires(H.HeavyLoad, H.OnlyForDev),

            //houses
            new BRequires(H.Bohio, true),
            new BRequires(H.HouseA, 17),
            new BRequires(H.HouseB, 25),
            new BRequires(H.HouseTwoFloor, 55),
            new BRequires(H.HouseMed, H.OnlyForDev),
            new BRequires(H.HouseLargeA, H.OnlyForDev),
            new BRequires(H.HouseLargeB, H.OnlyForDev),
            new BRequires(H.HouseLargeC, 150),

            //farm
            new BRequires(H.AnimalFarmSmall, true),
            new BRequires(H.AnimalFarmMed, 35),
            new BRequires(H.AnimalFarmLarge, 100),
            new BRequires(H.AnimalFarmXLarge, 150),  
            new BRequires(H.FieldFarmSmall, true),
            new BRequires(H.FieldFarmMed, 35),
            new BRequires(H.FieldFarmLarge, 100),
            new BRequires(H.FieldFarmXLarge, 150),


            //raw
            new BRequires(H.Clay, true),
            new BRequires(H.Ceramic, true),
            new BRequires(H.FishingHut, true),
            //new BRequires(H.Mine, true),
            new BRequires(H.MountainMine, true),
            //new BRequires(H.Resin, true),
            new BRequires(H.LumberMill, true),
            new BRequires(H.BlackSmith),
            new BRequires(H.SaltMine, true),

            //prod
            new BRequires(H.Brick, true),
            new BRequires(H.Carpintery, 50, 500, 900),
            new BRequires(H.Cigars, 50, 500, 900),
            new BRequires(H.Mill, 50, 500, 900),
            new BRequires(H.Tailor, H.Coming_Soon),
            //new BRequires(H.Tilery, 50, 500, 900),
            new BRequires(H.CannonParts, 50, 500, 900),
            new BRequires(H.Distillery, 50, 500, 900),
            new BRequires(H.Chocolate, 50, 500, 900),
            new BRequires(H.Ink, 50, 500, 900),

            //ind
            new BRequires(H.Cloth, 50, 500, 900),
            new BRequires(H.GunPowder, 50, 500, 900),
            new BRequires(H.Paper_Mill, 50, 500, 900),
            new BRequires(H.Printer, 50, 500, 900),
            new BRequires(H.CoinStamp, 150, 500, 900),
            new BRequires(H.Silk, 50, 500, 900),
            new BRequires(H.SugarMill, 50, 500, 900),
            new BRequires(H.Foundry, 50, 500, 900),
            new BRequires(H.SteelFoundry, 100, 500, 900, priorBuilds: new List<H>(){H.Foundry}),

            //trade
            new BRequires(H.Dock, 50, 500, 900, priorBuilds: new List<H>(){H.Shipyard}),
            new BRequires(H.Shipyard, 50, 500, 500, priorBuilds: new List<H>(){H.Supplier}),
            new BRequires(H.Supplier, 50, 500, 1000, priorBuilds: new List<H>(){H.LightHouse}),

            //new BRequires(H.Dock, true),
            //new BRequires(H.Shipyard, true),
            //new BRequires(H.Supplier, true),

            new BRequires(H.StorageSmall, true),
            new BRequires(H.StorageMed, 50, 500, 900, priorBuilds: new List<H>(){H.StorageSmall}),
            new BRequires(H.StorageBig, 150, 10000, 900, priorBuilds: new List<H>(){H.StorageMed}),
            new BRequires(H.StorageBigTwoDoors, 250, 1500, 900, priorBuilds: new List<H>(){H.StorageBig}),
            new BRequires(H.StorageExtraBig, 350, 2500, 900, priorBuilds: new List<H>(){H.StorageBigTwoDoors}),

            //gov
            new BRequires(H.Library, 50, 500, 900),
            new BRequires(H.School, 50, 500, 900),
            new BRequires(H.TradesSchool, 50, 500, 900, priorBuilds: new List<H>(){H.School}),
            new BRequires(H.TownHouse, H.Coming_Soon),


            //other
            new BRequires(H.Church, 50, 500, 900),
            new BRequires(H.Tavern, 50, 500, 900),

            //military
            new BRequires(H.PostGuard, 50, 500, 900),
            new BRequires(H.Fort, H.Coming_Soon),       
            new BRequires(H.Morro, H.Coming_Soon),
        };
    }

    public H ReturnBuildingState(H hType)
    {
        return _dict[hType].CurrentState;
    }

    /// <summary>
    /// Will loop trhu the list and will see building status
    /// problably call this every 1 min
    /// </summary>
    public void UpdateBuildsStatuses()
    {
        var currFood = GameController.ResumenInventory1.ReturnAmountOnCategory(PCat.Food);
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i].DefineCurrentState(currFood);
        }
    }



    internal string RequirementsNeeded(H type)
    {
        return _dict[type].InfoMsg;
    }
}

/// <summary>
/// What a build requires to be built
/// </summary>
class BRequires
{
    public H HType;
    public int Persons;
    public float Food;
    public float Dollars;

    public float PortReputation;
    public float PirateThreat;

    //priors build that need to exist 
    public List<H> PriorBuilds = new List<H>();

    //The sugarMill for example needs 20,000KG of SugarCane on stock before can be built
    public List<Order> ProductRequired = new List<Order>();

    //the states of the requirements of a building: Lock, Unlock, Coming Soon
    public H CurrentState = H.None;

    public string InfoMsg;//wht is needed in case needs to be shown in the BuildignDescription bz this is Lock
    private H h;
    private bool p1;
    private string p2;

    public BRequires() { }

    public BRequires(H hType, int persons = 50, float food = 1000, float dollars = 0,
        float portReputation = 5, float pirateTreath = 50, List<H> priorBuilds = null,
        List<Order> prodRequired = null)
    {
        HType = hType;
        Persons = persons;
        Food = food;
        Dollars = dollars;
        PortReputation = portReputation;
        PirateThreat = pirateTreath;
        PriorBuilds = priorBuilds;
        ProductRequired = prodRequired;

        CheckIfIsABuildThatHasInputProds();
        SetFoodNeededAsHouse();
    }



    private void SetFoodNeededAsHouse()
    {
        if (HType.ToString().Contains("House"))
        {
            Food = 100 * PersonPot.Control.All.Count;
            InfoMsg = "";
        }
    }

    /// <summary>
    /// For building with no requirements
    /// </summary>
    /// <param name="hType"></param>
    /// <param name="notRequirements"></param>
    public BRequires(H hType, bool notRequirements)
    {
        HType = hType;
        PirateThreat = 90;
    }

    /// <summary>
    /// Used to define the ones are 'comming soon'
    /// </summary>
    /// <param name="hType"></param>
    /// <param name="currState"></param>
    public BRequires(H hType, H currState)
    {
        if (currState == H.OnlyForDev && !Developer.IsDev)
        {
            currState = H.Coming_Soon;
        }

        HType = hType;
        PirateThreat = 90;

        CurrentState = currState;
    }



    /// <summary>
    /// If so add at least some prod requirements 
    /// </summary>
    private void CheckIfIsABuildThatHasInputProds()
    {
        var inputs = BuildingPot.Control.ProductionProp.ReturnAllInputsThisBuildingTakeListOfProd(HType);

        if (inputs != null && inputs.Count > 0 && ProductRequired == null)
        {
            ProductRequired = new List<Order>();
            //so Woods is not twice in PaperFactory
            inputs = inputs.Distinct().ToList();
        }

        for (int i = 0; i < inputs.Count; i++)
        {
            ProductRequired.Add(new Order(inputs[i], 500));
        }
    }

    /// <summary>
    /// Does define 'CurrentState' string.:Lock, Unlock, Coming Soon
    /// </summary>
    public void DefineCurrentState(float currentAmtOfFood)
    {
        //to buildings that has not 3d yet done. or will be added in the future 
        if (CurrentState == H.Coming_Soon || 
            (CurrentState == H.OnlyForDev && !Developer.IsDev))
        {
            return;
        }

        //needs to be called here again bz the amt of people changes all the time 
        SetFoodNeededAsHouse();

        var person = PersonPot.Control.All.Count > Persons || Persons == 0;
        var food = currentAmtOfFood > Food || Food == 0;
        var dollar = Program.gameScene.GameController1.Dollars > Dollars || Dollars == 0;
        var port = BuildingPot.Control.DockManager1.PortReputation > PortReputation || PortReputation == 0;
        //inverse need
        var pirate = BuildingPot.Control.DockManager1.PirateThreat < PirateThreat || PirateThreat == 100;

        if (person && food && dollar && port && pirate && DoesPriorBuildingsExist() && DoWeHaveEnoughOnStorages())
        {
            CurrentState = H.Unlock;
        }
        else
        {
            CurrentState = H.Lock;
            SetRequirementsNeededInfoMsg();
        }

        //for option playing all unlock buildings
        if (CurrentState == H.Lock && Program.IsAnUnLockGame())
        {
            CurrentState = H.Unlock;
            InfoMsg = "";
        }

        if (!IsAHouseBelowCapMax())
        {
            CurrentState = H.Max_Cap_Reach;
        }

        if (Developer.IsDev)
        {
            CurrentState = H.Unlock;
        }
    }

    /// <summary>
    /// If is a house will check if the Population is below the Cap.
    /// 
    /// </summary>
    /// <returns>if is not below and a house will return false</returns>
    private bool IsAHouseBelowCapMax()
    {
        var aHouse = HType.ToString().Contains("House") || HType == H.Bohio;
        if (!aHouse)
        {
            return true;
        }

        return PersonPot.Control.All.Count < GameController.CapMaxPerson;
    }

    private void SetRequirementsNeededInfoMsg()
    {
        if (!string.IsNullOrEmpty(InfoMsg))
        {
            return;
        }
        //string res = HType + " build is lock.\nTo Unlock: ";
        string res = "To unlock: ";
        int appends = 0;

        if (Persons != 0)
        {
            res += Persons + " persons. ";
            appends++;
        }
        if (Food != 0)
        {
            res += Unit.WeightConverted(Food) + " " + Unit.WeightUnit() + " of food. ";
            appends++;
        }
        if (Dollars != 0)
        {
            res += Dollars + " dollars. ";
            appends++;
        }
        if (PortReputation != 0)
        {
            res += "Port reputation at least at " + PortReputation + ". ";
            appends++;
        }
        if (PirateThreat != 0)
        {
            res += "Pirate threat less than " + PirateThreat + ". ";
            appends++;
        }

        if (ProductRequired != null)
        {
            for (int i = 0; i < ProductRequired.Count; i++)
            {
                res += ProductRequired[i].Product + " " + Unit.WeightConverted(ProductRequired[i].Amount)
                    + " " + Unit.WeightUnit() + ". ";
                appends++;
            }
        }

        if (PriorBuilds != null)
        {
            for (int i = 0; i < PriorBuilds.Count; i++)
            {
                res += ".At least 1: " + PriorBuilds[i] + ". ";
                appends++;
            }
        }

        res = DescriptionWindow.CheckIfAppend3(ref appends, res);

        InfoMsg = res;

    }

    bool DoWeHaveEnoughOnStorages()
    {
        if (ProductRequired == null)
        {
            return true;
        }

        for (int i = 0; i < ProductRequired.Count; i++)
        {
            var onGeneral = GameController.ResumenInventory1.ReturnAmtOfItemOnInv(ProductRequired[i].Product);
            return onGeneral > ProductRequired[i].Amount;
        }
        return true;
    }

    bool DoesPriorBuildingsExist()
    {
        if (PriorBuilds == null || PriorBuilds.Count == 0)
        {
            return true;
        }

        for (int i = 0; i < PriorBuilds.Count; i++)
        {
            //var result = BuildingPot.Control.Registro.AllBuilding.First(a => a.Value.HType == PriorBuilds[i]);
            var result = BuildingPot.Control.FindRandomBuildingOfThisType(PriorBuilds[i]);
            if (result != null && result.StartingStage == H.Done)
            {
                //if doesnt contain one of the required buildings then is false
                return true;
            }
        }
        return false;
    }

}



