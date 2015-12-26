﻿/*
 * This class helps with the routing will tell if reaching the Final 
 * a building was found or not and if was found will find closest building
 * will pick closest 3 points to Final and will add the 4 point as the intersection
 * 
 * Those 4 points will be the only ones the CryRoute will look into 
 * 
 * Explorer is used once a new _curr is set on CryRoute. A explorations needs to be done
 * to see what is on front 
 */
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Explorer 
{
    List<ExplorerUnit> _units = new List<ExplorerUnit>();
    public ExplorerUnit Result;//the one will contain the Unit for work for the CryRoute
    //is building routing if is true we can use 
    private bool _isBuildingRouting = true;

    //says if from curr to Final are only bulidings or still elemtents intersectin 
    private bool _isIntersectingOnlyObstacles = true;

    /// <summary>
    /// is building routing if is true we can use 
    /// </summary>
    public bool IsBuildingRouting
    {
        //ios calling WasABuildingHit() mainly to set the object Result
        //at the same time must have being intersecting only obstacles
        get
        {
            if (_isBuildingRouting && _isIntersectingOnlyObstacles)
            {
                WasAObstacleHit();
                return true;
            }

            return false;
        }
    }

    public Explorer() { }

    /// <summary>
    /// Adds a key to the explorer 
    /// </summary>
    /// <param name="crystal">Key of the Parent ID with intersect with</param>
    /// <param name="intersection">The point where we intersect</param>
    /// <param name="currPosition">the curr Position of the Crystal reaching Final</param>
    public void AddKey(Crystal crystal, Vector3 intersection, Vector3 currPosition, Vector3 final)
    {
        ExplorerUnit doesExistKey = null;

        if (_units.Count > 0)
        {
            doesExistKey = _units.Find(a => a.Key == crystal.ParentId);
        }
            
        //so it doesnt add duplicates keys
        if (doesExistKey == null)
        {
            _units.Add(new ExplorerUnit(crystal, intersection, currPosition, final));
        }
        //bz a line can have diff intersections in a building. usually 2 
        //if exist will add Intersection 
        else
        {
            doesExistKey.AddIntersection(intersection, crystal);
        }

        SetIfIsIntersectingOnlyObstacles(crystal);
    }

    /// <summary>
    /// Will say if a building was hit and will return a ExplorerUnit object
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    bool WasAObstacleHit()
    {
        bool res = false;
        _units = _units.OrderBy(a => a.Distance).ToList();

        for (int i = 0; i < _units.Count; i++)
        {
            if (_units[i].IsHasAValidObstacle)
            {
                _units[i].Create4Crystals();//so the crystals are ready
                Result = _units[i];
                return true;
            }
        }
        return res;
    }

    /// <summary>
    /// sets for saying if from curr to Final are only bulidings or still elemtents intersectin 
    /// </summary>
    /// <param name="c"></param>
    void SetIfIsIntersectingOnlyObstacles(Crystal c)
    {
        if (_isIntersectingOnlyObstacles && c.Type1 != H.Obstacle)
        {        
            //intersected something was not a obstacle 
            _isIntersectingOnlyObstacles = false;
        }
    }

    /// <summary>
    /// So its restarted so can be used again 
    /// </summary>
    public void Restart()
    {
        _units.Clear();
        _isBuildingRouting = true;
        _isIntersectingOnlyObstacles = true;
    }

    /// <summary>
    /// Adding the Crystals contain in RectC so if one Crystal is not obstacle then we cannnot use the 
    /// Building Routing system
    /// </summary>
    /// <param name="c"></param>
    public void AddCrystalOfRectC(Crystal c)
    {
        //as soon one is found that is not type obstacle then we cant use Building Routing 
        if (_isBuildingRouting && c.Type1 != H.Obstacle)
        {
            _isBuildingRouting = false;
        }
    }
}

public class ExplorerUnit
{
    public string Key;
    public List<Vector3> Intersections = new List<Vector3>();
    public Building Building;
    private TerrainRamdonSpawner _ramdonSpawner;

    //the 4 crystals to be eval in CryRoute
    public List<Crystal> Crystals = new List<Crystal>();

    //distance to currPosition of Crystal Reaching final and intersect 
    public float Distance; 
    public Vector3 Final;//the final point of the Route 
    public bool IsHasAValidObstacle;

    public ExplorerUnit(Crystal crystal, Vector3 intersect, Vector3 currPosition, Vector3 final)//the curr Position of the Crystal reaching Final
    {
        Final = final;
        Key = crystal.ParentId;
        Intersections.Add(intersect);

        Distance = Mathf.Abs(Vector3.Distance(intersect, currPosition));
        Building = Brain.GetBuildingFromKey(Key);

        _ramdonSpawner =
            Program.gameScene.controllerMain.TerraSpawnController.FindThis(crystal.ParentId);

        if (Building != null)
        {
            IsHasAValidObstacle = true;
        }
        else if (_ramdonSpawner != null)
        {
            Debug.Log("Hey hit random: " + _ramdonSpawner.MyId);
            IsHasAValidObstacle = true;
        }
        else
        {
            //is set to that so if never was calculated its really far 
            //since distance will be used for ordering 
            Distance = 10000;
        }
    }

    /// <summary>
    /// Will be call only if was the select building to be route trhu
    /// 
    /// Will set the Crystals
    /// will pick closest 3 points of the buildig to Final and will add the 4th point as the intersection
    /// </summary>
    public void Create4Crystals()
    {
        var anchorOrder = ReturnOrderedAnchors();
        Crystals = ReturnPriorityToFin(anchorOrder);
    }

    List<Crystal> ReturnOrderedAnchors()
    {
        List<Crystal> anchorOrdered = new List<Crystal>();
        anchorOrdered = MeshController.CrystalManager1.ReturnCrystalsThatBelongTo(Building, false);

        for (int i = 0; i < 4; i++)
        {
            anchorOrdered[i].Distance = Mathf.Abs(Vector3.Distance(U2D.FromV2ToV3(anchorOrdered[i].Position), Final));
        }
        anchorOrdered = anchorOrdered.OrderBy(a => a.Distance).ToList();

        return anchorOrdered;
    }

    /// <summary>
    /// Ordering to be closer to _fin
    /// 
    /// Pls interseection
    /// </summary>
    List<Crystal> ReturnPriorityToFin(List<Crystal> res)
    {
        //-1 bz only need the first 3 
        res.RemoveAt(res.Count-1);

        for (int i = 0; i < Intersections.Count; i++)
        {
            var last = new Crystal(Intersections[i], H.None, "", setIdAndName: false);
            res.Add(ReturnCrystalAwayFromBuild(last));
            //res.Add(last);
        }

        UVisHelp.CreateHelpers(Intersections, Root.yellowCube);
        return res;
    }

    /// <summary>
    /// Bz they needs to be moved a bit away from Buildign
    /// </summary>
    /// <returns></returns>
    Crystal ReturnCrystalAwayFromBuild(Crystal crystal)
    {
        var person = PersonPot.Control.All.FirstOrDefault();
        float moveBy = person.PersonDim * 1.5f;

        var moved = Vector3.MoveTowards(U2D.FromV2ToV3(crystal.Position), Building.transform.position, -moveBy);
        crystal.Position = U2D.FromV3ToV2(moved);

        return crystal;
    }

    /// <summary>
    /// ADds the intersection we hit and the crystal that belongs to
    /// </summary>
    /// <param name="intersection"></param>
    /// <param name="crystal"></param>
    internal void AddIntersection(Vector3 intersection, Crystal crystal)
    {
        Intersections.Add(intersection);
        Intersections = Intersections.Distinct().ToList();
    }
}