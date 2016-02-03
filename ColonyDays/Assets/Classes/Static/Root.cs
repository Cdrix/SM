﻿/*
 * Legend
 * Sel: Select
 */

using System;
using UnityEngine;
using System.Collections.Generic;

//will keep all the roots of objects stored as strings in STATIC VARIABLES
//all VAR ARE STATIC HERE
public class Root : MonoBehaviour
{











    ///Main Objects///
        public static string classesContainer = "Prefab/Main/ClassesContainer";
        ///Game Scene
        public static string gameScene = "Prefab/Main/GameScene"; 

    ///Controllers
    public static string controllerMain = "Prefab/Controller/Controller_Main";
    public static string builderController = "Prefab/Controller/Builder_Controller";
    
    ///Terrain All*******
        //HelpersMeshMngr
        public static string meshController = "Prefab/Terrain/Mesh_Controller";
        public static string malla = "Prefab/Terrain/Malla";
        public static string extraTallBox = "Prefab/Terrain/Extra_Tall_Box";
        public static string tallBox = "Prefab/Terrain/Tall_Box";
        public static string tallBoxR = "Prefab/Terrain/Tall_Box_R";//for render

        public static string tallCilinder = "Prefab/Terrain/Tall_Cilinder";
        public static string tallCilinderR = "Prefab/Terrain/Tall_Cilinder_R";//for render

        //Terrain
        public static string terrainValleyAndRiver = "Prefab/Terrain/TerrainValleyAndRiver";
        public static string terrainIsland = "Prefab/Terrain/Terrain_Island";
        //public static string terrainIsland2x = "Prefab/Terrain/Terrain_Island2x";
        public static string terrainIsland2xRiverAccross = "Prefab/Terrain/Terrain_Island2x_River_Accross";
       




        //Big Terrains
        public static string bayAndMountain = "Prefab/Terrain/Bay_And_Mountain";
        public static string bayAndMountainSoft = "Prefab/Terrain/Bay_And_Mountain_Soft";
        public static string bayAndMountain1River = "Prefab/Terrain/Bay_And_Mountain_1_River";


        public static List<string> BigTerrains = new List<string>()
        {
            bayAndMountain, bayAndMountainSoft, bayAndMountain1River
        }; 



        //Water 
        public static string waterTiny = "Prefab/Terrain/Water_Tiny";
        public static string waterSmall = "Prefab/Terrain/Water_Small";

        //Spawner 
        public static string terrainSpawnerController = "Prefab/Terrain/Spawner/Terrain_Spawner_Controller";
        public static string tree1 = "Prefab/Terrain/Spawner/Tree1";
        public static string tree2 = "Prefab/Terrain/Spawner/Tree2";
        public static string tree3 = "Prefab/Terrain/Spawner/Tree3";

        public static string tree4 = "Prefab/Terrain/Spawner/Tree4";
        public static string tree5 = "Prefab/Terrain/Spawner/Tree5";
        public static string tree6 = "Prefab/Terrain/Spawner/Tree6";
        public static string tree7 = "Prefab/Terrain/Spawner/Tree7";
        public static string tree8 = "Prefab/Terrain/Spawner/Tree8";


        public static string palm1 = "Prefab/Terrain/Spawner/Palm/Palm01";
        public static string palm2 = "Prefab/Terrain/Spawner/Palm/Palm02";
        public static string palm3 = "Prefab/Terrain/Spawner/Palm/Palm03";

        public static string palm4 = "Prefab/Terrain/Spawner/Palm/Palm04";
        public static string palm5 = "Prefab/Terrain/Spawner/Palm/Palm05";
        public static string palm6 = "Prefab/Terrain/Spawner/Palm/Palm06";

        public static string palm10 = "Prefab/Terrain/Spawner/Palm/Palm10";





        public static string stone0 = "Prefab/Terrain/Spawner/Stone/Stone";
        public static string stone1 = "Prefab/Terrain/Spawner/Stone/Stone 1";
        public static string stone2 = "Prefab/Terrain/Spawner/Stone/Stone 2";
        public static string stone3 = "Prefab/Terrain/Spawner/Stone/Stone 3";
        public static string stone4 = "Prefab/Terrain/Spawner/Stone/Stone 4";
        public static string stone5 = "Prefab/Terrain/Spawner/Stone/Stone 5";
        public static string stone6 = "Prefab/Terrain/Spawner/Stone/Stone 6";
        public static string stone7 = "Prefab/Terrain/Spawner/Stone/Stone 7";
        
        public static string iron0 = "Prefab/Terrain/Spawner/Iron/Iron";
        public static string iron1 = "Prefab/Terrain/Spawner/Iron/Iron 1";
        public static string iron2 = "Prefab/Terrain/Spawner/Iron/Iron 2";
        public static string iron3 = "Prefab/Terrain/Spawner/Iron/Iron 3";
        public static string iron4 = "Prefab/Terrain/Spawner/Iron/Iron 4";


        public static string gold0 = "Prefab/Terrain/Spawner/Gold/Gold";
        public static string gold1 = "Prefab/Terrain/Spawner/Gold/Gold 1";
        public static string gold2 = "Prefab/Terrain/Spawner/Gold/Gold 2";
        public static string gold3 = "Prefab/Terrain/Spawner/Gold/Gold 3";
        public static string gold4 = "Prefab/Terrain/Spawner/Gold/Gold 4";




        public static string orna1 = "Prefab/Terrain/Spawner/Orna1";
        public static string orna2 = "Prefab/Terrain/Spawner/Orna2";
        public static string orna3 = "Prefab/Terrain/Spawner/Orna3";
        public static string orna4 = "Prefab/Terrain/Spawner/Orna4";
        public static string orna5 = "Prefab/Terrain/Spawner/Orna5";
        public static string orna6 = "Prefab/Terrain/Spawner/Orna6";

        public static string grass1 = "Prefab/Terrain/Spawner/Grass1";
        public static string grass2 = "Prefab/Terrain/Spawner/Grass2";
        public static string grass3 = "Prefab/Terrain/Spawner/Grass3";  
        public static string grass4 = "Prefab/Terrain/Spawner/Grass4";
        public static string grass5 = "Prefab/Terrain/Spawner/Grass5";
        public static string grass6 = "Prefab/Terrain/Spawner/Grass6";

        //Visual Hep for spawner
        public static string selectMine1 = "Prefab/ScreenHelper/Selection_Mine1";

    /// Input
    public static string inputMain = "Prefab/Input/Input_Main";
    public static string inputMeshSpawn = "Prefab/Input/Input_Mesh_Spawn";
    public static string inputBuilder = "Prefab/Input/Input_Builder";

    ///Building
    public static Dictionary<H, string> buildsRoot = new Dictionary<H, string>(); //for key and root


    public static string builderPot = "Prefab/Building/Builder_Pot";
    public static string fakeHouse = "Prefab/Building/Fake_House";
    //public static string tavernDone = "Prefab/Building/Tavern/Tavern";




    public static string bigBoxPrev = "Prefab/Building/Big_Box_Prev";
    public static string createPlane = "Prefab/Building/Create_Plane";
    public static string createPlaneUnit = "Prefab/Building/Create_Plane_Unit";
    public static string createPlaneRoad = "Prefab/Building/Create_Road";
    public static string trail = "Prefab/Building/Trail";
    public static string previewTrail = "Prefab/Building/Preview_Trail";
    public static string previewRoad = "Prefab/Building/Preview_Road";
    public static string bridge = "Prefab/Building/Bridge";
    public static string farm = "Prefab/Building/Farm";
    public static string dock = "Prefab/Building/Trade/Dock";

    ///Bridges
    public static string bridgeTrailPart1 = "Prefab/Building/Infrastructure/Bridge_Trail_Piece_1";
    public static string bridgeTrailPart2 = "Prefab/Building/Infrastructure/Bridge_Trail_Piece_2";
    public static string bridgeTrailPart3 = "Prefab/Building/Infrastructure/Bridge_Trail_Piece_3";
    public static string bridgeTrailPart4 = "Prefab/Building/Infrastructure/Bridge_Trail_Piece_4";

    public static string bridgeTrailPart10 = "Prefab/Building/Infrastructure/Bridge_Trail_Piece_10";
    public static string bridgeTrailPart11 = "Prefab/Building/Infrastructure/Bridge_Trail_Piece_11";
    public static string bridgeTrailPart12 = "Prefab/Building/Infrastructure/Bridge_Trail_Piece_12";

    ///Dummy buidling ......use to be thrown a Raycast by Router.cs
    public static string dummyBuild = "Prefab/Building/DummyBuild";
    public static string dummyBuildCollider = "Prefab/Building/DummyBuild_With_Collider";
    public static string dummyBuildWithSpawnPoint = "Prefab/Building/DummyBuild_With_SpawnPoint";
    public static string dummyBuildWithSpawnPointUnTimed = "Prefab/Building/DummyBuild_With_SpawnPoint_UnTimed";
    



    ///GUI
    public static string arrow = "Prefab/GUI/Arrow";
    public static string projector = "Prefab/GUI/Projector";
    public static string projectorPerson = "Prefab/GUI/ProjectorPerson";

    public static string lightCil = "Prefab/GUI/Civ5/LightCil";
    public static string lightCilPerson = "Prefab/GUI/Civ5/LightCilPerson";

    public static string lockedBuilding = "Prefab/GUI/Locked_Building";


    //FORMS

    //this one is the form is on screen all time 
    public static string mainGUI = "Prefab/GUI/Forms/MainGUI";

    //shows the orders on the Dock 
    public static string orderShowClose = "Prefab/GUI/Forms/Order_Show_Close";
    public static string orderShow = "Prefab/GUI/Forms/Order_Show";

    //generic btn 
    //so far used for products selection
    public static string orderShowGenBtn = "Prefab/GUI/Forms/Order_Show_Generic_Btn";
    public static string showGenBtnLarge = "Prefab/GUI/Forms/Show_Generic_Btn_Large";

    //Menu
    public static string mainMenu = "Prefab/Menu/MainMenu";
    public static string loadingScreen = "Prefab/Menu/LoadingScreen";




    ///Planes Materials
    public static Dictionary<H, string> planesMaterialDict = new Dictionary<H, string>(); //for key and root

    ///Materials
    public static IDictionary<string, string> matDict = new Dictionary<string, string>(); //for key and root
    //for key and root used for groups of buildings
    public static IDictionary<string, string> matDictSec = new Dictionary<string, string>(); 

    public static string matGreenSel = "Prefab/Mats/Green_Selection";
    public static string matGreenSel2 = "Prefab/Mats/Green_Selection_2";
    public static string whiteSemi = "Prefab/Mats/White_Semi";
    public static string matStone = "Prefab/Mats/Stone";
    public static string matAdoquin = "Prefab/Mats/Adoquin";
    public static string matGravilla = "Prefab/Mats/Gravilla";
    public static string matGravillaRoad = "Prefab/Mats/GravillaRoad";
    public static string matBuildingBase1 = "Prefab/Mats/Building/Building_Base1";
    public static string matBuildingBase2 = "Prefab/Mats/Building/Building_Base2";

    public static string matFarmSoil = "Prefab/Mats/FarmSoil";

    public static string matTavernBase = "Prefab/Mats/Building/houseBase";
    public static string matTavernUp1 = "Prefab/Mats/Building/houseUp1";
    public static string matTavernUp2 = "Prefab/Mats/Building/houseUp2";

    public static string matStages = "Prefab/Mats/Building/Stages";
    
    public static string matWoodForRaw = "Prefab/Mats/Building/Wood_For_Raw_copy";
    public static string matWoodClassyDoor = "Prefab/Mats/Building/WoodA_Classy_Door_copy";
    public static string matGovServices = "Prefab/Mats/Building/Gov_Serv";
    public static string matWoodA = "Prefab/Mats/Building/WoodA";
    public static string matHouse2 = "Prefab/Mats/Building/house2";

    public static string personGuy1 = "Prefab/Mats/Person/Guy1UV";

    /// <summary>
    /// Personas
    /// </summary>
    public static string personPot = "Prefab/Personas/Person_Pot";
    public static string personController = "Prefab/Personas/Person_Controller";
    public static string personSaveLoad = "Prefab/Personas/Person_SaveLoad";
    public static string brain = "Prefab/Personas/Brain";
    public static string body = "Prefab/Personas/Body";

    //their starting scale is 0.26f in all axis
    public static string personaMale1  = "Prefab/Personas/PersonaMale1";
    public static string personaFeMale1 = "Prefab/Personas/PersonaFeMale1";

    //Personal Objects// objects person carry around or use
    public static string coal = "Prefab/Personas/PersonalObject/Coal";
    public static string crate = "Prefab/Personas/PersonalObject/Crate";
    public static string guataca = "Prefab/Personas/PersonalObject/Guataca";
    public static string hammer = "Prefab/Personas/PersonalObject/Hammer";
    public static string ore = "Prefab/Personas/PersonalObject/Ore";
    public static string tonel = "Prefab/Personas/PersonalObject/Tonel";
    public static string vara = "Prefab/Personas/PersonalObject/Vara";
    public static string wood = "Prefab/Personas/PersonalObject/Wood";


    /// <summary>
    /// Animals
    /// </summary>
    public static string beefMale1 = "Prefab/Animals/BeefMale1";


    public static string beefMat1 = "Prefab/Mats/Animals/Animals";

   

    /// <summary>
    /// Ships
    /// </summary>
    public static string shipSmall =  "Prefab/Ship/ShipSmall";


    static void LoadMatDict()
    {
        matDict.Add(H.Trail+"."+Ma.matBuildBase, matGravilla);
        matDict.Add(H.Trail+"."+Ma.matBuildUpg1, matStone);
        matDict.Add(H.Trail + "." +Ma.matBuildUpg2, matAdoquin);

        matDict.Add(H.Road + "." + Ma.matBuildBase, matGravillaRoad);

        matDict.Add(H.BridgeTrail + "." + Ma.matBuildBase, matGravilla);
        matDict.Add(H.BridgeRoad + "." + Ma.matBuildBase, matGravillaRoad);

        matDict.Add(H.BridgeTrailUnit + "." + Ma.matBuildBase, matWoodForRaw);
        matDict.Add(H.BridgeRoadUnit + "." + Ma.matBuildBase, matWoodForRaw);

        matDict.Add(H.Tavern + "." + Ma.matBuildBase, matTavernBase);
        matDict.Add(H.Tavern + "." + Ma.matBuildUpg1, matTavernUp1);
        matDict.Add(H.Tavern + "." + Ma.matBuildUpg2, matTavernUp2);

        matDict.Add(H.StockPile + "." + Ma.matBuildBase, matGravilla);

        matDict.Add(H.Stages.ToString(), matStages);
    }

    /// <summary>
    /// Will return the material if 'key' found otherwise return 'matWoodForRaw'
    /// </summary>
    public static string RetMaterialRoot(string key)
    {
        if (matDict.Count == 0)
        {
            LoadMatDict();
        }

        if (matDict.ContainsKey(key))
        {
            //print(key + ".key.MatDict");
            return matDict[key];
        }

        if (matDictSec.Count == 0)
        {
            LoadMatDictSec();
        }

        if (matDictSec.ContainsKey(key))
        {
            return matDictSec[key];
        }

        //returning this as default for all 
        return matWoodForRaw;
    }


    public static string RetBuildingRoot(H key)
    {
        if (buildsRoot.Count == 0)
        {
            LoadDictionaryRoots();
        }

        return buildsRoot[key];
    }

    /// <summary>
    /// Will return the root for the icon of a building 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string RetBuildingIconRoot(H key)
    {
        if (buildsRoot.Count == 0)
        {
            LoadDictionaryRoots();
        }

        return buildsRoot[key]+"_Icon";
    }

    /// <summary>
    /// Will return the root for the banner of a building 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string RetBuildingBannerRoot(H key)
    {
        if (buildsRoot.Count == 0)
        {
            LoadDictionaryRoots();
        }

        return buildsRoot[key] + "_Banner";
    }


    /// <summary>
    /// Will return the root of the Product
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string RetPrefabRoot(P key)
    {
        if (productsRoot.Count == 0)
        {
            LoadProductsRoots();
        }

        return productsRoot[key];
    }

    private static void LoadProductsRoots()
    {
        //plants
        productsRoot.Add(P.Corn, "Prefab/Building/Farming/Plants/Corn");
        productsRoot.Add(P.Bean, "Prefab/Building/Farming/Plants/Bean");
        productsRoot.Add(P.Banana, "Prefab/Building/Farming/Plants/Banana");
        productsRoot.Add(P.Coconut, "Prefab/Building/Farming/Plants/Coconut");
    }




    static void LoadMatDictSec()
    {
        var govServ = GovServices.GetValues(typeof(GovServices));
        var woodAClassyDoor = WoodAClassyDoor.GetValues(typeof(WoodAClassyDoor));
        var woodA = WoodA.GetValues(typeof(WoodA));
        var house2 = MatHouse2.GetValues(typeof(MatHouse2));

        AddToMatDictSec(matGovServices, govServ, Ma.matBuildBase);
        AddToMatDictSec(matWoodClassyDoor, woodAClassyDoor, Ma.matBuildBase);
        AddToMatDictSec(matWoodA, woodA, Ma.matBuildBase);
        AddToMatDictSec(matHouse2, house2, Ma.matBuildBase);
    }

    static void AddToMatDictSec(string materialRoot, Array array, Ma typeOfUpdgrade)
    {
        foreach (var item in array)
        {
            matDictSec.Add(item.ToString() + "." +typeOfUpdgrade.ToString(), materialRoot);
        }
    }


    #region Materials Enums

    //this enums are the buildings that use the enum name Material

    //everytihng is not below or in the first dictionry will get the defaul material
    enum GovServices
    {
        CommerceChamber, Customs, Library, School, TradesSchool, TownHouse, Church
    }

    enum WoodAClassyDoor
    {
        Cloth, Printer, CoinStamp, Carpintery, Cigars, Mill, Slat,
        Dock, DryDock, Supplier,
        StorageSmall, StorageMed, StorageBig, StorageBigTwoDoors, StorageExtraBig,

    }

    enum WoodA
    {
        GunPowder, Paper, Silk, SugarMill, LightHouse, Brick, Tilery
    }

    enum MatHouse2
    {
        HouseB, HouseMedA, HouseMedB, 
    }
    
    #endregion
    
    static void LoadDictionaryRoots()
    {
        //infr Trail, Road, BridgeTrail, BridgeRoad, CoachMan, LightHouse, WheelBarrow, StockPile,
        buildsRoot.Add(H.BridgeTrail, "Prefab/Building/Bridge");
        buildsRoot.Add(H.BridgeRoad, "Prefab/Building/Bridge");
        
        buildsRoot.Add(H.CoachMan, "Prefab/Building/Infrastructure/CoachMan");
        buildsRoot.Add(H.BuildersOffice, "Prefab/Building/Infrastructure/BuildersOffice");
        buildsRoot.Add(H.LightHouse, "Prefab/Building/Infrastructure/LightHouse");
        //wheel barrrow not needed anymoe. bz will be join with BuildersOffice
        buildsRoot.Add(H.WheelBarrow, "Prefab/Building/Infrastructure/WheelBarrow");

        //house
        buildsRoot.Add(H.HouseA, "Prefab/Building/House/HouseA");
        buildsRoot.Add(H.HouseB, "Prefab/Building/House/HouseB");
        buildsRoot.Add(H.HouseAWithTwoFloor, "Prefab/Building/House/HouseAWithTwoFloor");
        buildsRoot.Add(H.HouseMedA, "Prefab/Building/House/HouseMedA");
        buildsRoot.Add(H.HouseMedB, "Prefab/Building/House/HouseMedB");
        buildsRoot.Add(H.HouseC, "Prefab/Building/House/HouseC");
        buildsRoot.Add(H.HouseD, "Prefab/Building/House/HouseD");
        
        buildsRoot.Add(H.Shack, "Prefab/Building/Other/Shack");

        //farming 
        //animal farming
        buildsRoot.Add(H.AnimalFarmSmall, "Prefab/Building/Farming/AnimalFarmSmall");
        buildsRoot.Add(H.AnimalFarmMed, "Prefab/Building/Farming/AnimalFarmMed");
        buildsRoot.Add(H.AnimalFarmLarge, "Prefab/Building/Farming/AnimalFarmLarge");
        buildsRoot.Add(H.AnimalFarmXLarge, "Prefab/Building/Farming/AnimalFarmXLarge");

        //field farmin
        buildsRoot.Add(H.FieldFarmSmall, "Prefab/Building/Farming/FieldFarmSmall");
        buildsRoot.Add(H.FieldFarmMed, "Prefab/Building/Farming/FieldFarmMed");
        buildsRoot.Add(H.FieldFarmLarge, "Prefab/Building/Farming/FieldFarmLarge");
        buildsRoot.Add(H.FieldFarmXLarge, "Prefab/Building/Farming/FieldFarmXLarge");





        //Raw
        buildsRoot.Add(H.Ceramic, "Prefab/Building/Raw/Ceramic");
        buildsRoot.Add(H.FishSmall, "Prefab/Building/Raw/FishSmall");
        buildsRoot.Add(H.FishRegular, "Prefab/Building/Raw/FishRegular");
        buildsRoot.Add(H.Mine, "Prefab/Building/Raw/Mine");
        buildsRoot.Add(H.MountainMine, "Prefab/Building/Raw/MountainMine");
        buildsRoot.Add(H.Resin, "Prefab/Building/Raw/Resin");
        buildsRoot.Add(H.Wood, "Prefab/Building/Raw/Wood");
        buildsRoot.Add(H.BlackSmith, "Prefab/Building/Raw/BlackSmith");
        buildsRoot.Add(H.SaltMine, "Prefab/Building/Raw/SaltMine");


        //Prod
        buildsRoot.Add(H.Brick, "Prefab/Building/Prod/Brick");
        buildsRoot.Add(H.Carpintery, "Prefab/Building/Prod/Carpintery");
        buildsRoot.Add(H.Cigars, "Prefab/Building/Prod/Cigars");
        buildsRoot.Add(H.Mill, "Prefab/Building/Prod/Mill");
        buildsRoot.Add(H.Slat, "Prefab/Building/Prod/Slat");
        buildsRoot.Add(H.Tilery, "Prefab/Building/Prod/Tilery");

        buildsRoot.Add(H.CannonParts, "Prefab/Building/Prod/CannonParts");
        buildsRoot.Add(H.Rum, "Prefab/Building/Prod/Rum");
        buildsRoot.Add(H.Chocolate, "Prefab/Building/Prod/Chocolate");
        buildsRoot.Add(H.Ink, "Prefab/Building/Prod/Ink");

        //Industry
        buildsRoot.Add(H.Cloth, "Prefab/Building/Industry/Cloth");
        buildsRoot.Add(H.GunPowder, "Prefab/Building/Industry/GunPowder");
        buildsRoot.Add(H.Paper, "Prefab/Building/Industry/Paper");
        buildsRoot.Add(H.Printer, "Prefab/Building/Industry/Printer");
        buildsRoot.Add(H.CoinStamp, "Prefab/Building/Industry/CoinStamp");
        buildsRoot.Add(H.Silk, "Prefab/Building/Industry/Silk");
        buildsRoot.Add(H.SugarMill, "Prefab/Building/Industry/SugarMill");

        buildsRoot.Add(H.Foundry, "Prefab/Building/Industry/CoinStamp");
        buildsRoot.Add(H.SteelFoundry, "Prefab/Building/Industry/CoinStamp");

        //Trade
        buildsRoot.Add(H.Dock, "Prefab/Building/Trade/Dock");
        buildsRoot.Add(H.DryDock, "Prefab/Building/Trade/DryDock");
        buildsRoot.Add(H.Supplier, "Prefab/Building/Trade/Supplier");
        buildsRoot.Add(H.StorageSmall, "Prefab/Building/Trade/StorageSmall");
        buildsRoot.Add(H.StorageMed, "Prefab/Building/Trade/StorageMed");
        buildsRoot.Add(H.StorageBig, "Prefab/Building/Trade/StorageBig");
        buildsRoot.Add(H.StorageBigTwoDoors, "Prefab/Building/Trade/StorageBigTwoDoors");
        buildsRoot.Add(H.StorageExtraBig, "Prefab/Building/Trade/StorageExtraBig");

        //gov
        buildsRoot.Add(H.Clinic, "Prefab/Building/GovServices/Clinic");
        buildsRoot.Add(H.CommerceChamber, "Prefab/Building/GovServices/CommerceChamber");
        buildsRoot.Add(H.Customs, "Prefab/Building/GovServices/Customs");
        buildsRoot.Add(H.Library, "Prefab/Building/GovServices/Library");
        buildsRoot.Add(H.School, "Prefab/Building/GovServices/School");
        buildsRoot.Add(H.TradesSchool, "Prefab/Building/GovServices/TradesSchool");
        buildsRoot.Add(H.TownHouse, "Prefab/Building/GovServices/TownHouse");

        //other
        buildsRoot.Add(H.Church, "Prefab/Building/Other/Church");
        buildsRoot.Add(H.Tavern, "Prefab/Building/Other/Tavern");

    }

    private static Dictionary<P, string> _productsRoot = new Dictionary<P, string>();

//for key and root

    public static Dictionary<P, string> productsRoot
    {
        get { return _productsRoot; }
        set { _productsRoot = value; }
    }





    #region Return Base Plane Method and Dictionary

    public static string RetPlaneMaterialRoot(H key)
    {
        if (planesMaterialDict.Count == 0)
        {
            LoadPlaneMaterialRoots();
        }

        return planesMaterialDict[key];
    }

    static void LoadPlaneMaterialRoots()
    {
        planesMaterialDict.Add(H.CoachMan, "material root");
        planesMaterialDict.Add(H.BuildersOffice, "material root");
    }


    #endregion









































































    //OLD stuff



    //list tht will hold all path stirngs
    public static List<string> path = new List<string>();
    public static bool started = false;//is use to flag if the list was filled or not

    //list that are use to hold sets of Menus////////////////////////////////////////////////////////// 
    public static List<string> selNewModels = new List<string>();
    public static List<string> selRaws = new List<string>();
    public static List<string> selElement = new List<string>();
    public static List<string> selHelper = new List<string>();
    public static List<string> campaignMenu = new List<string>();
    public static List<string> profileMenu = new List<string>();
    public static List<string> multiPlayerMenu = new List<string>();
    public static List<string> settingsMenu = new List<string>();
    public static List<string> settingsPauseMenu = new List<string>();
    public static List<string> createUserMenu = new List<string>();
    public static List<string> pauseMenu = new List<string>();
    public static List<string> confirmMenu = new List<string>();

    //hold all the menu list set of menus///////////////////////////////////////////////////////////////
    public static List<List<string>> myMenuSets = new List<List<string>>();
    ////////////////////////////////////////////////////////////////////////////////////////////////////




    
    //--------------------------------------------------------------------------------------------------------------
    //Misc
    public static string threeDBtnMenuHandler = "Prefab/Misc/ThreeDBtnMenuHandler";
    public static string twoDBtnMenuHandler = "Prefab/Misc/TwoDBtnMenuHandler";

    //were in General.cs
    public static string peopleMan1 = "Prefab/People/Man1/Man1Prefab";
    public static string helperNewBuild = "Prefab/Misc/NewBuild";

    //were in Menus.cs
    public static string menusTextLeft = "Prefab/GUI/Help_Text_Left";
    public static string menusTextMiddle = "Prefab/GUI/Help_Text_Middle";
    public static string GUIState = "Prefab/GUI/State";
    public static string basic3dMenu = "Prefab/Menu/RightClick/Basic/Basic3dMenu";

    //Select New Model Menu
    public static string selRaw3dMenu = "Prefab/Menu/RightClick/SelectModel/Select_Raw_Btn_NewMenu_3dMenu";
    public static string selElement3dMenu = "Prefab/Menu/RightClick/SelectModel/Select_Element_Btn_NewMenu_3dMenu";
    public static string selHelper3dMenu = "Prefab/Menu/RightClick/SelectModel/Select_Helper_Btn_NewMenu_3dMenu";
    public static string newModelSpawner = "RightClicked_Menu_Spawner";

    //Select New Raw Menu
    public static string selCube = "Prefab/Menu/RightClick/SelectRaw/Select_Cube_Btn_Raw_3dMenu";
    public static string selCylinder = "Prefab/Menu/RightClick/SelectRaw/Select_Cylinder_Btn_Raw_3dMenu";
    public static string selSphere = "Prefab/Menu/RightClick/SelectRaw/Select_Sphere_Btn_Raw_3dMenu";
    public static string selPyramid = "Prefab/Menu/RightClick/SelectRaw/Select_Pyramid_Btn_Raw_3dMenu";
    public static string selCone = "Prefab/Menu/RightClick/SelectRaw/Select_Cone_Btn_Raw_3dMenu";
    public static string rawSpawner = "Raw_Menu_Spawner";

    //Select New Element Menu
    public static string selBomb = "Prefab/Menu/RightClick/SelectElement/Select_Bomb_Btn_Element_3dMenu";
    public static string selElevator = "Prefab/Menu/RightClick/SelectElement/Select_Elevator_Btn_Element_3dMenu";
    public static string selMine = "Prefab/Menu/RightClick/SelectElement/Select_Mine_Btn_Element_3dMenu";
    public static string selSpike = "Prefab/Menu/RightClick/SelectElement/Select_Spike_Btn_Element_3dMenu";
    public static string selSpring = "Prefab/Menu/RightClick/SelectElement/Select_Spring_Btn_Element_3dMenu";
    public static string elementSpawner = "Element_Menu_Spawner";

    //3d Helper 
    public static string redSphereHelp = "Prefab/Misc/RedSphereHelp";
    public static string yellowSphereHelp = "Prefab/Misc/YellowSphereHelp";
    public static string yellowSphereHelp_ZeroAlpha = "Prefab/Misc/YellowSphereHelp_ZeroAlpha";

    public static string blueSphereHelp = "Prefab/Misc/BlueSphereHelp";
    public static string texto3d = "Prefab/Misc/3dText";
    public static string blueCube = "Prefab/Misc/Blue_Cube";
    public static string redCube = "Prefab/Misc/Red_Cube";
    public static string yellowCube = "Prefab/Misc/Yellow_Cube";
    public static string largeBlueCube = "Prefab/Misc/Large_Blue_Cube_Semi_T";
    public static string blueCubeBig = "Prefab/Misc/Blue_Cube_Big";

    //Raw Models
    public static string cone = "Prefab/Model/Raw/Cone";
    public static string cube = "Prefab/Model/Raw/Cube";
    public static string cylinder = "Prefab/Model/Raw/Cylinder";
    public static string pyramid = "Prefab/Model/Raw/Pyramid";
    public static string sphere = "Prefab/Model/Raw/Sphere";

    //Elements Models
    public static string bomb = "Prefab/Model/Element/Bomb";
    public static string elevator = "Prefab/Model/Element/Elevator";
    public static string mine = "Prefab/Model/Element/Mine";
    public static string spike = "Prefab/Model/Element/Spike";
    public static string spring = "Prefab/Model/Element/Spring";
    //could add Jackies spikes

    //Helper Models //Drone, Goblins, Soldiers, Doctor, Builders
    public static string builder = "Prefab/Model/Helper/Builder";
    public static string goblin = "Prefab/Model/Helper/Goblin";
    public static string drone = "Prefab/Model/Helper/Drone";
    public static string doctor = "Prefab/Model/Helper/Doctor";
    public static string soldier = "Prefab/Model/Helper/Soldier";

    //////////////////////////////////////////////////////MAIN MENU         MAIN MENU       MAIN MENU
    //Main Menu
    public static string campaign = "Prefab/Menu/MainMenu/Select_Campaign_Btn_Main_3dMenu";
    public static string profile = "Prefab/Menu/MainMenu/Select_Profile_Btn_Main_3dMenu";
    public static string multiPlayer = "Prefab/Menu/MainMenu/Select_MultiPlayer_Btn_Main_3dMenu";
    public static string settings = "Prefab/Menu/MainMenu/Select_Settings_Btn_Main_3dMenu";
    public static string createUser = "Prefab/Menu/MainMenu/Select_CreateUser_Btn_Main_3dMenu";
    public static string exit = "Prefab/Menu/MainMenu/Select_Exit_Btn_Main_3dMenu";
    public static string moreGames = "Prefab/Menu/MainMenu/Select_More_Games_Btn_Main_3dMenu";
    public static string mainSpawner = "Main_Menu_Spawner";



    //Campaign / Select Character Menu//
    public static string singleBoard = "Prefab/Menu/Campaign/Select_SingleBoard_Btn_Main_3dMenu";
    public static string selMaleOne = "Prefab/Menu/Campaign/Actionable_Male1_Btn_Main_3dMenu";//Actionable_Male1_Btn_Main_3dMenu"  Actionable_Male1_Btn3d
    public static string selMaleTwo = "Prefab/Menu/Campaign/Actionable_Male2_Btn_Main_3dMenu";
    public static string play = "Prefab/Menu/Campaign/Actionable_Play_Btn_Main_3dMenu";
    public static string campaignSpawner = "Campaign_Menu_Spawner";
    //chartacters to choose
    public static string boardMale1 = "Prefab/Menu/Campaign/Board_Male1_Btn_Main_3dMenu";
    public static string boardMale2 = "Prefab/Menu/Campaign/Board_Male2_Btn_Main_3dMenu";

    //Profile Menu
    public static string profileBoard = "Prefab/Menu/Profile/Select_Profile_Btn_Main_3dMenu";
    public static string profileSpawner = "Profile_Menu_Spawner";

    //Multiplayer menu//
    public static string multiBoard = "Prefab/Menu/MultiPlayer/Select_MultiPlayerBoard_Btn_Main_3dMenu";
    public static string playMulti = "Prefab/Menu/MultiPlayer/Select_PlayMulti_Btn_Main_3dMenu";
    public static string multiPlayerSpawner = "MultiPlayer_Menu_Spawner";

    //Settings Menu
    public static string soundOnMain = "Prefab/Menu/Settings/Select_Sound_Btn_Main_3dMenu";
    public static string musicOnMain = "Prefab/Menu/Settings/Select_Music_Btn_Main_3dMenu";
    public static string creditsOnMain = "Prefab/Menu/Settings/Select_Credits_Btn_Main_3dMenu";
    public static string settingsSpawner = "Settings_Menu_Spawner";

    //Create online user 
    public static string userBoard = "Prefab/Menu/CreateUser/Select_UserBoard_Btn_Main_3dMenu";
    public static string okCreateProfile = "Prefab/Menu/CreateUser/Select_OkCreateProfile_Btn_Main_3dMenu";
    public static string createUserSpawner = "CreateUser_Menu_Spawner";

    //Common for some Menus
    public static string backToMainMenu = "Prefab/Menu/MainMenuCommons/Select_Main_Btn_Main_3dMenu";

    // KEEP ON MIND...
    // WAS A BUG OF 1H BZ a name of a button contain part of other 'CreateUser' and 'OkCreateUser'
    //THE BUG WAS THAT WHEN U HOVER IT WILL ACT WEIRD WILL NOT BE UNDER THE POINTER WANTED TO GO AWAY ALWAYSS
    /////////////////////////////////////////////////////
    //END MAIN MENU
    /////////////////////////////////////////////////////


    //Players
    public static string godPlayer = "Prefab/People/GodPlayer/GodPlayer";
    public static string maleOneModel = "Prefab/People/Male/Male";
    public static string maleTwoModel = "Prefab/People/MaleTwoModel/MaleTwoModel";

    //Cameras
    public static string cameraFollow = "Prefab/Cameras/CameraFollow";
    public static string cameraFollowLobby = "Prefab/Cameras/CameraFollowLobby";
    public static string cameraFPS = "Prefab/Cameras/CameraFPS";

    //RTS Camera
    public static string cameraRTS = "Prefab/Cameras/CameraRTS";
    public static string mouseInBorderRTS = "Prefab/Cameras/RTS/MouseInBorderRTS";
    public static string rotateRTS = "Prefab/Cameras/RTS/RotateRTS";
    public static string inputRTS = "Prefab/Cameras/RTS/InputRTS";
    public static string miniMapRTS = "Prefab/Cameras/RTS/MiniMapRTS";
    public static string centerTarget = "Prefab/Cameras/RTS/CenterTarget";
    //GUI**************************************************************************************
    //Still Buttons
    public static string pauseButton = "Prefab/GUI/Pause_Button/Select_Pause_Btn2D_NewMenu_PauseMenu";
    public static string heart = "Prefab/GUI/Heart/Heart_GUI";

    //Pause Menu 
    public static string mainMenu2DBtnInPauseMenu = "Prefab/Menu/Pause/Actionable_BackToMain_Btn2D_NewMenu_PauseMenu";
    public static string resume2DBtnInPauseMenu = "Prefab/Menu/Pause/Select_Resume_Btn2D_Click_PauseMenu";
    public static string settings2DBtnInPauseMenu = "Prefab/Menu/Pause/Actionable_Settings_Btn2D_NewMenu_PauseMenu";
    //not added to  pauseMenu list bz this label is spawned mannualy and this are intended to follow a
    //one row pattern on screen ... this obj is a whole screen label
    public static string backGroundLabelPauseMenu = "Prefab/Menu/Pause/Back_Ground_Label_Pasive_PauseMenu";
    public static string pauseMenuSpawner = "Pause_Menu_Spawner";

    //Confirm Menu
    public static string okPause = "Prefab/Menu/Confirm/Actionable_Ok_PauseMenu";
    public static string cancelPause = "Prefab/Menu/Confirm/Actionable_Cancel_PauseMenu";
    public static string confirmMenuSpawner = "Confirm_Menu_Spawner";

    //Settings on Pause
    public static string soundOnPaused = "Prefab/Menu/SettingsPause/Actionable_Sound_Btn_Main_Paused";
    public static string musicOnPaused = "Prefab/Menu/SettingsPause/Actionable_Music_Btn_Main_Paused";
    public static string backToPauseMenu = "Prefab/Menu/SettingsPause/Actionable_BackToPause_Btn2D_Click_Pause";
    public static string settingsPauseSpawner = "Settings_Pause_Menu_Spawner";


 

    //End of GUI*************************************************************************************

    public static void Start()
    {
      
    }

    public static string ReturnFullPath(string which)
    {
        if (!started)
        {
            Start();
            started = true;
        }

        for (int i = 0; i < path.Count; i++)
        {
            if (path[i].Contains(which))
            {
                which = path[i];
            }
        }
        return which;
    }

    //returns the list number that hold the set of objects given the spawner...
    //so the spawner name is really important... so the btn we are clicking has to be
    //named in a correct way so the spawner will pick it up ex:
    //Button we are clicking: "Select_MultiPlayer_Btn_Main_3dMenu"
    //Spawner var value: "MultiPlayer_Menu_Spawner";
    public static int ReturnListNumber(string spawner)
    {
        if (!started)
        {
            Start();
            started = true;
        }

        int temp = 0;
        for (int i = 0; i < myMenuSets.Count; i++)
        {
            //print("spawner:" + spawner);
            for (int k = 0; k < myMenuSets[i].Count; k++)
            {
                //IMPORTATNT what is being stored in the list cant be "" other wise will bug 
                if ((myMenuSets[i][k]) != "" && (myMenuSets[i][k]) != null)
                {
                    //spawner is longer than what is stored.. as may have (Clone) and .MiddleMenu in the name
                    if (spawner.Contains(myMenuSets[i][k]))
                    {
                        temp = i;
                    }
                }
            }
        }
        return temp;
    }
}





