﻿using System.Collections.Generic;

/*This calss contains how much the structures cost */

public class Book : General
{
    private static List<BuildStat> _build = new List<BuildStat>();

    //structures categories with the set of its structures
    private Dictionary<H, List<H>> _structuresDict = new Dictionary<H, List<H>>();

    //the list of all menuGroups of buildings 
    private List<H> _menuGroupsList = new List<H>();

    //the list of all structures
    private List<H> _allStructures = new List<H>();

    public static List<BuildStat> Build
    {
        get { return _build; }
    }

    public Dictionary<H, List<H>> StructuresDict
    {
        get { return _structuresDict; }
        set { _structuresDict = value; }
    }

    public List<H> AllStructures
    {
        get { return _allStructures; }
        set { _allStructures = value; }
    }

    public List<H> MenuGroupsList
    {
        get { return _menuGroupsList; }
        set { _menuGroupsList = value; }
    }

    /// <summary>
    /// Will give u the stats of a Specific type of building 
    /// </summary>
    /// <param name="hTypeP"></param>
    /// <returns></returns>
    static public BuildStat GiveMeStat(H hTypeP)
    {
        BuildStat res = new BuildStat();
        for (int i = 0; i < _build.Count; i++)
        {
            if (_build[i].HType == hTypeP)
            {
                res = _build[i];
            }
        }
        return res;
    }


    void LoadBuildDict()
    {
        //infr
        Build.Add(new BuildStat(H.Road, 100, 8, 2, 0, 5, maxPeople: 0));

        Build.Add(new BuildStat(H.BridgeTrail, 400, 8, 2, 0, 5, maxPeople: 0));
        Build.Add(new BuildStat(H.BridgeRoad, 1000, 8, 10, 0, 8, maxPeople: 0));

        Build.Add(new BuildStat(H.CoachMan, 800, 80, 20, 0, 5, maxPeople: 8));
        Build.Add(new BuildStat(H.Masonry, 800, 80, 20, 0, 5, maxPeople: 12));
        Build.Add(new BuildStat(H.HeavyLoad, 800, 80, 20, 0, 5, maxPeople: 3));
        Build.Add(new BuildStat(H.LightHouse, 800, 80, 20, 0, 5, maxPeople: 3));


        //houses 
        Build.Add(new BuildStat(H.Bohio, 400, 3, 0, 0, 0, maxPeople: 5, capacity: .3f));
        Build.Add(new BuildStat(H.HouseA, 400, 5, 5, 25, 5, maxPeople: 5, capacity: .3f));
        Build.Add(new BuildStat(H.HouseB, 400, 5, 5, 25, 5, maxPeople: 5, capacity: .3f));
        Build.Add(new BuildStat(H.HouseTwoFloor, 800, 30, 5, 5, 5, maxPeople: 10, capacity: .6f));
        Build.Add(new BuildStat(H.HouseMed, 800, 10, 5, 50, 5, maxPeople: 7, capacity: .6f));
        //Build.Add(new BuildStat(H.HouseMedB, 800, 30, 5, 50, 5, maxPeople: 7, capacity: 2));
        Build.Add(new BuildStat(H.HouseLargeA, 1, 0.01f, 0, 0, 0, maxPeople: 7, capacity: 1));
        Build.Add(new BuildStat(H.HouseLargeB, 800, 10, 5, 50, 5, maxPeople: 7, capacity: 1));
        Build.Add(new BuildStat(H.HouseLargeC, 800, 10, 5, 50, 5, maxPeople: 7, capacity: 1));


        //farming
        Build.Add(new BuildStat(H.AnimalFarmSmall, 400, 5, 5, 5, 5, maxPeople: 5,  capacity: 1));
        Build.Add(new BuildStat(H.AnimalFarmMed, 500, 7, 5, 7, 5, maxPeople: 7, capacity: 1));
        Build.Add(new BuildStat(H.AnimalFarmLarge, 600, 9, 5, 9, 5, maxPeople: 9, capacity: 2));
        Build.Add(new BuildStat(H.AnimalFarmXLarge, 800, 11, 5, 11, 5, maxPeople: 12, capacity: 3));

        Build.Add(new BuildStat(H.FieldFarmSmall, 100, .5f, 0, 0,  maxPeople: 2, capacity: 1));
        Build.Add(new BuildStat(H.FieldFarmMed, 200, .75f, 0, 0,  maxPeople: 4, capacity: 1));
        Build.Add(new BuildStat(H.FieldFarmLarge, 300, .9f, 0, 0,  maxPeople: 6, capacity: 2));
        Build.Add(new BuildStat(H.FieldFarmXLarge, 400, 1, 0, 0,  maxPeople: 9, capacity: 3));

        //Raw
        Build.Add(new BuildStat(H.Clay, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Ceramic, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Fishing_Hut, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.FishRegular, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Mine, 400, 15, 5, 25, 5, maxPeople: 5));

        Build.Add(new BuildStat(H.MountainMine, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Resin, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.LumberMill, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.BlackSmith, 400, 15, 5, 25, 5, maxPeople: 5));

        Build.Add(new BuildStat(H.SaltMine, 400, 15, 5, 25, 5, maxPeople: 5));


        //Prod
        Build.Add(new BuildStat(H.Brick, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Carpintery, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Cigars, 400, 15, 5, 25, 5, maxPeople: 5));

        Build.Add(new BuildStat(H.Mill, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Tailor, 400, 15, 5, 25, 5, maxPeople: 5));
        //Build.Add(new BuildStat(H.Tilery, 400, 15, 5, 25, 5, maxPeople: 5));

        Build.Add(new BuildStat(H.CannonParts, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Distillery, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Chocolate, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Ink, 400, 15, 5, 25, 5, maxPeople: 5));

        //Industry
        Build.Add(new BuildStat(H.Cloth, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.GunPowder, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Paper_Mill, 400, 15, 5, 25, 5, maxPeople: 5));

        Build.Add(new BuildStat(H.Printer, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.CoinStamp, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.Silk, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.SugarMill, 400, 15, 5, 25, 5, maxPeople: 5));

        Build.Add(new BuildStat(H.Foundry, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.SteelFoundry, 400, 15, 5, 25, 5, maxPeople: 5));


        //Trade
        Build.Add(new BuildStat(H.Dock, 900, 30, 20, 0, 5, maxPeople: 10));
        Build.Add(new BuildStat(H.Shipyard, 900, 30, 20, 0, 5, maxPeople: 10));
        Build.Add(new BuildStat(H.Supplier, 900, 30, 20, 0, 5, maxPeople: 10));

        Build.Add(new BuildStat(H.StorageSmall, 400, 10, 20, 10, 5, maxPeople: 0, capacity: 150));
        Build.Add(new BuildStat(H.StorageMed, 600, 15, 20, 20, 5, maxPeople: 0, capacity: 200));
        Build.Add(new BuildStat(H.StorageBig, 600, 20, 20, 35, 5, maxPeople: 0, capacity: 300));
        Build.Add(new BuildStat(H.StorageBigTwoDoors, 600, 25, 20, 50, 5, maxPeople: 0, capacity: 300));
        Build.Add(new BuildStat(H.StorageExtraBig, 600, 30, 20, 60, 5, maxPeople: 0, capacity: 4200));

        //Gov
        //Build.Add(new BuildStat(H.Clinic, 400, 15, 5, 25, 5, maxPeople: 5));
        //Build.Add(new BuildStat(H.CommerceChamber, 400, 15, 5, 25, 5, maxPeople: 5));
        //Build.Add(new BuildStat(H.Customs, 400, 15, 5, 25, 5, maxPeople: 5));

        Build.Add(new BuildStat(H.Library, 400, 15, 5, 25, 5, maxPeople: 1));
        Build.Add(new BuildStat(H.School, 400, 15, 5, 25, 5, maxPeople: 2));
        Build.Add(new BuildStat(H.TradesSchool, 400, 15, 5, 25, 5, maxPeople: 5));
        Build.Add(new BuildStat(H.TownHouse, 400, 15, 5, 25, 5, maxPeople: 5));

        //Other
        Build.Add(new BuildStat(H.Church, 1600, 80, 20, 0, 5, maxPeople: 3));
        Build.Add(new BuildStat(H.Tavern, 400, 30, 5, 50, 5, maxPeople: 2));

        //Militar
        Build.Add(new BuildStat(H.PostGuard, 600, 80, 20, 0, 5, maxPeople: 10));

       // Build.Add(new BuildStat(H.Tower, 600, 80, 20, 0, 5, maxPeople: 10));
        Build.Add(new BuildStat(H.Fort, 600, 80, 20, 0, 5, maxPeople: 10));
        Build.Add(new BuildStat(H.Morro, 600, 80, 20, 0, 5, maxPeople: 10));
    }

    // Use this for initialization
    public void Start()
    {
        LoadBuildDict();
        MapStructuresCatego();
    }

    void MapStructuresCatego()
    {
        var infrastructure = StInfr.GetValues(typeof(StInfr));
        var housing = StHous.GetValues(typeof(StHous));
        var farming = StFarm.GetValues(typeof (StFarm));
        var raw = StRaw.GetValues(typeof(StRaw));
        var production = StProd.GetValues(typeof(StProd));
        var industry = StInd.GetValues(typeof (StInd));
        var trade = StTrade.GetValues(typeof(StTrade));
        var govServ = StGov.GetValues(typeof(StGov));
        var other = StOther.GetValues(typeof(StOther));
        var mil = StMil.GetValues(typeof(StMil));
        var structCateg = StCat.GetValues(typeof(StCat));

        MenuGroupsList = UList.ConvertToList(structCateg);

        List<List<H>> listedArrays = new List<List<H>>();

        listedArrays.Add(UList. ConvertToList(infrastructure));
        listedArrays.Add(UList.ConvertToList(housing));
        listedArrays.Add(UList.ConvertToList(farming));
        listedArrays.Add(UList.ConvertToList(raw));
        listedArrays.Add(UList.ConvertToList(production));
        listedArrays.Add(UList.ConvertToList(industry));
        listedArrays.Add(UList.ConvertToList(trade));
        listedArrays.Add(UList.ConvertToList(govServ));
        listedArrays.Add(UList.ConvertToList(other));
        listedArrays.Add(UList.ConvertToList(mil));

        for (int i = 0; i < MenuGroupsList.Count; i++)
        {
            _structuresDict.Add(MenuGroupsList[i], listedArrays[i]);
        }

        foreach (KeyValuePair<H, List<H>> entry in StructuresDict)
        {
            for (int i = 0; i < entry.Value.Count; i++)
            {
                AllStructures.Add(entry.Value[i]);
            }
        }
    }


}

/// <summary>
/// The costs and specifics of each building unit
/// </summary>
public class BuildStat
{
    private float _amountOfLabour;//needed to finish the building
    //All Costs
    private float _wood;
    private float _stone;
    private float _brick;
    private float _iron;
    private float _gold;
    private float _dollar;//Money 

    //Cubic Meters of storage for a build
    private float _capacity;

    //In game prop
    private int _maxPeople;//max amt of peope can leave in a house or can work in a place

    //Technical
    private H _hType;
    private string _root;

    public BuildStat(H hType, float amountOfLabour = 0, float wood = 0, float stone = 0, float brick = 0, float iron = 0,
        float gold = 0, float colonyDollar = 0, int maxPeople = 0, float capacity = 10)
    {
        float multiplier = 100;

        AmountOfLabour = amountOfLabour;
        HType = hType;
        Root = global::Root.RetBuildingRoot(hType);
        Wood = wood * multiplier;
        Stone = stone * multiplier;
        Brick = brick * multiplier;
        Iron = iron * multiplier;
        Gold = gold * multiplier;

        Dollar = colonyDollar;
        _maxPeople = maxPeople;
        _capacity = capacity;
    }   
    


    public BuildStat()
    {
        // TODO: Complete member initialization
    }

    public H HType
    {
        get { return _hType; }
        set { _hType = value; }
    }

    /// <summary>
    /// So far not used. but if will use in future . Double check bridge for posible bugg 
    /// </summary>
    public string Root
    {
        get { return _root; }
        set { _root = value; }
    }

    public float Wood
    {
        get { return _wood; }
        set { _wood = value; }
    }

    public float Stone
    {
        get { return _stone; }
        set { _stone = value; }
    }

    public float Brick
    {
        get { return _brick; }
        set { _brick = value; }
    }

    public float Iron
    {
        get { return _iron; }
        set { _iron = value; }
    }

    public float Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public float Dollar
    {
        get { return _dollar; }
        set { _dollar = value; }
    }

    public float AmountOfLabour
    {
        get { return _amountOfLabour; }
        set { _amountOfLabour = value; }
    }

    public float Capacity
    {
        get { return _capacity; }
        set { _capacity = value; }
    }

    public int MaxPeople
    {
        get { return _maxPeople; }
        set { _maxPeople = value; }
    }

  



    private int _factor;
    private int _minAge;
    private int _maxAge;
    public BuildStat(H hType, int factor, int minAge, int maxAge)
    {
        HType = hType;
        _factor = factor;
        _minAge = minAge;
        _maxAge = maxAge;
    }


    public int Factor
    {
        get { return _factor; }
        set { _factor = value; }
    }

    public int MinAge
    {
        get { return _minAge; }
        set { _minAge = value; }
    }

    public int MaxAge
    {
        get { return _maxAge; }
        set { _maxAge = value; }
    }

}
