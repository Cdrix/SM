﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Will decorate the surroundings of a building 
/// </summary>
public class Decoration  {

    List<string> _roots = new List<string>()
    {
        //"Prefab/Terrain/Spawner/Decora/Crate 1",
        //"Prefab/Terrain/Spawner/Decora/Crate 2",
        //"Prefab/Terrain/Spawner/Decora/Crate 3",
        //"Prefab/Terrain/Spawner/Decora/Crate 4",
        //"Prefab/Terrain/Spawner/Decora/Crate 5",
        //"Prefab/Terrain/Spawner/Decora/Barrel 1",
        //"Prefab/Terrain/Spawner/Decora/Barrel 2",
        //"Prefab/Terrain/Spawner/Decora/RusticChair",
    };

    

    

    private Building _building;
    List<Line> _lines = new List<Line>(); 

    List<Vector3> _positionsToSpawnDecor=new List<Vector3>();
    private General _spwnedObj;

    public Decoration(Building build)
    {
        //return;

        _building = build;
        _roots.AddRange(TerrainSpawnerController.allOrna);

        //removing the last 2 orna. The small palms 
        _roots.RemoveAt(_roots.Count-1);
        _roots.RemoveAt(_roots.Count-1);

        //_roots.AddRange(TerrainSpawnerController.allGrass);
        Init();
    }

    private void Init()
    {
        _lines = U2D.FromPolyToLines(_building.Anchors);
        RemoveSpwnPointLine();
        FindPositionToSpwnDecor();
        
        SpawnDecorObj();
        AddToBatchMesh();

        IfHouseMedAssignRandomMat();
    }




    #region Romeo Bravo Pirate

    private int _romeo;
    private int _bravo;
    private int _pirate;
    private GameObject _main;
    private void IfHouseMedAssignRandomMat()
    {
        if (_building.HType != H.HouseMed)
        {
            return;
        }
        DefineRamdonSelection();

        _main = General.GetChildThatContains("Main", _building.gameObject);
        FindAllSubObjsAndAssignMat();
    }

    private void FindAllSubObjsAndAssignMat()
    {
        var one = General.GetChildsNameEqual(_main, "1");
        var two = General.GetChildsNameEqual(_main, "2");
        var three = General.GetChildsNameEqual(_main, "3");

        var ones = General.FindAllChildsGameObjectInHierarchy(one[0]);
        var twos = General.FindAllChildsGameObjectInHierarchy(two[0]);
        var threes = General.FindAllChildsGameObjectInHierarchy(three[0]);

        GetRidOfUnselected(ones, twos, threes, _romeo, "Romeo");//romeo selection
        GetRidOfUnselected(ones, twos, threes, _bravo, "Bravo");//romeo selection
        GetRidOfUnselected(ones, twos, threes, _pirate, "Pirate");//romeo selection
    }

    private void GetRidOfUnselected(GameObject[] ones,GameObject[] twos, GameObject[] threes, int selection,
        string name)
    {
        if (selection == 1)
        {
            DestroyAllThatMatch(twos, threes, name);
        }
        else if (selection == 2)
        {
            DestroyAllThatMatch(ones, threes, name);
        }
        else if (selection == 3)
        {
            DestroyAllThatMatch(ones, twos, name);
        }
    }

    /// <summary>
    /// Will destroy all components in those 2 list that match 'name'
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="name"></param>
    private void DestroyAllThatMatch(GameObject[] a, GameObject[] b, string name)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].name == name)
            {
                MonoBehaviour.Destroy(a[i]);
            }
        }
        for (int i = 0; i < b.Length; i++)
        {
            if (a[i].name == name)
            {
                MonoBehaviour.Destroy(b[i]);
            }
        }
    }

    private void DefineRamdonSelection()
    {
        _romeo = UMath.GiveRandom(1,4);
        _bravo = UMath.GiveRandom(1,4);
        _pirate = UMath.GiveRandom(1,4);
    }




#endregion

    /// <summary>
    /// The line facing spawnPoint wil be removed
    /// </summary>
    void RemoveSpwnPointLine()
    {
        var st = (Structure)_building;
        //moveing the spwn point away from building . assuimng is fallin inside building 
        var spwPoint = Vector3.MoveTowards(st.SpawnPoint.transform.position, _building.transform.position, -.75f);

        var spwnLine = new Line(U2D.FromV3ToV2(spwPoint), U2D.FromV3ToV2(_building.transform.position));
        for (int i = 0; i < _lines.Count; i++)
        {
            if (_lines[i].IsIntersecting(spwnLine))
            {
                _lines.RemoveAt(i);
                break;
            }
        }
    }

    private void FindPositionToSpwnDecor()
    {
        for (int i = 0; i < _lines.Count; i++)
        {
            _positionsToSpawnDecor.AddRange(_lines[i].ReturnRandomPointsInLine());
        }
    }

    private void SpawnDecorObj()
    {
        _spwnedObj = General.Create(Root.classesContainer,_building.transform.position,"",_building.transform,
            H.Decoration);
        
        _spwnedObj.Category = _spwnedObj.DefineCategory(H.Decoration);

        for (int i = 0; i < _positionsToSpawnDecor.Count; i++)
        {
            var root = _roots[UMath.GiveRandom(0, _roots.Count)];
            
            //moving a bit twrds buildings
            var iniPos = Vector3.MoveTowards(_positionsToSpawnDecor[i], _building.transform.position, .2f);

            var spwnObj = General.Create(root, iniPos, container: _building.transform, name:"Decora");
            RandomizeRotAndScale(spwnObj.gameObject, root);

            var subs = General.FindAllChildsGameObjectInHierarchy(spwnObj.gameObject);

            //will make all subs child of '_spwnedObj'
            for (int j = 0; j < subs.Length; j++)
            {
                subs[j].transform.parent = _spwnedObj.transform;
            }
            //bz they are useless. I got the subObjects already
            spwnObj.Destroy();
        }
    }

    void AddToBatchMesh()
    {
        Program.gameScene.BatchAdd(_spwnedObj);
    }

    public void RemoveFromBatchMesh()
    {
        Program.gameScene.BatchRemove(_spwnedObj);
    }

    void RandomizeRotAndScale(GameObject spwnObj, string root)
    {
        //return;
        spwnObj.transform.Rotate(new Vector3(0, UMath.GiveRandom(0, 360), 0));

        //they are well scaled 
        if (root.Contains("Prefab/Terrain/Spawner/Decora"))
        {
            return;
        }
        
        //ScaleDownTerrainSpawners
        var actScale = spwnObj.transform.localScale;
        spwnObj.transform.localScale = actScale/2f;//2.5
    }


}