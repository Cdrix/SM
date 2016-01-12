﻿using System.Collections.Generic;
using UnityEngine;

/*
 * This class is contained in Structure.cs and is the one that handles all with a Field Farm
 */
public class FieldFarm : Farm
{
    SMe m = new SMe();

    private Structure _building;//the building structure contains the Field Farm 
    List<Plant> _plants = new List<Plant>();
    List<Vector3> _seedLoc=new List<Vector3>();//the location of the seeds in this Field Farm  
    private P _plantType;

    private float _spaceBtwPlants;//this is the space btw plants will be different for each 

    //of the FarmZone
    private Vector3 _NW;
    private Vector3 _SE;

    private Vector3 _min;
    private Vector3 _max;

    //the total produuced 
    private int _kgProduced;

    public FieldFarm() { }

    public FieldFarm(Structure building)
    {
        _building = building;
        _plantType = building.CurrentProd.Product;
        Init();
    }

    public float SpaceBtwPlants
    {
        get { return _spaceBtwPlants; }
    }

    void Init()
    {
        FindWherePlantSeeds();
        SeedPlants();

        
    }

    private void DefineSpaceBtnPlants()
    {
        _spaceBtwPlants =  Mathf.Abs(m.SubDivide.XSubStep);

        if (_plantType == P.Banana)
        {
            _spaceBtwPlants *= 2;
        }
        else if (_plantType == P.Coconut)
        {
            _spaceBtwPlants *= 3;
        }
    }

    /// <summary>
    /// After we got the Location of the seeds will procede to plant seeds 
    /// </summary>
    private void SeedPlants()
    {
        for (int i = 0; i < _seedLoc.Count; i++)
        {
            _plants.Add(Plant.Create(_plantType, _seedLoc[i], _building, this));
        }
    }

    void FindWherePlantSeeds()
    {
        PullFarmZoneVars();
        DefineFarmNWandSE();
        LoopToFindSeeds();
    }

    private void DefineFarmNWandSE()
    {
        var poly = UPoly.RetTerrainPoly(_min, _max, Dir.SWtoNE);
        _NW = poly[0];
        _SE = poly[2];
    }

    /// <summary>
    /// Will loop considering _min, _max and will define seeding Vectors Locations
    /// </summary>
    private void LoopToFindSeeds()
    {
        if (_spaceBtwPlants == 0)
        {
            DefineSpaceBtnPlants();
        }

        var a = m.SubDivide.XSubStep;
        var aa = m.SubDivide.ZSubStep;

        _seedLoc = RetuFillPoly(_NW, _SE, _spaceBtwPlants, _spaceBtwPlants);



        //UVisHelp.CreateHelpers(_seedLoc, Root.blueCube);
    }

    List<Vector3> RetuFillPoly(Vector3 NW, Vector3 SE, float xStep, float zStep)
    {
        List<Vector3> res = new List<Vector3>();

        for (float x = NW.x; x < SE.x; x += xStep)
        {
            for (float z = NW.z; z > SE.z; z -= zStep)
            {
                res.Add(new Vector3(x, NW.y, z)); 
            }
        }
        return res;
    }


    void PullFarmZoneVars()
    {
        var farmZone = _building.FarmZone();
        _min = farmZone.GetComponent<Collider>().bounds.min;
        _max = farmZone.GetComponent<Collider>().bounds.max;
    }


    /// <summary>
    /// This is call from the plant and will be given the amout of work
    /// they are entitled to. ex: in te small farm in Corn and Bean are 24 plants each will get a 1/24 of the
    /// total amount worked
    /// </summary>
    /// <returns></returns>
    public float GiveMeMyWorkedAmt()
    {
        //var amt = _workAdded/_plants.Count;
        //_workAdded -= amt;
        return _workAdded;
    }


    private int plantsCount;
    /// <summary>
    /// Use to keep track of plants grw once all of them grw will make _workAdded = 0
    /// </summary>
    internal void PlantGrew()
    {
        plantsCount++;

        if (plantsCount >= _plants.Count)
        {
            plantsCount = 0;
            _workAdded = 0;
        }
    }

    private int harvestCount;
    internal void HarvestCheck()
    {
        harvestCount++;

        if (harvestCount >= _plants.Count)
        {
            _isReadyToHarvest = true;
        }
    }

    public void Update()
    {
        if (_harvestNow)
        {
            HarvestNowTheField();
        }
    }

    private void HarvestNowTheField()
    {
        for (int i = 0; i < _plants.Count; i++)
        {
            _plants[i].Harvest();
        }

        _building.DestroyFarm();
    }
}
