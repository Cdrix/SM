﻿using UnityEngine;

public class TerrainRamdonSpawner : General {

    //the tree height 
    //used when a tree is replanted 
    /// <summary>
    /// the height of the elements they start always with 1. if a tree is replanted is 
    /// set to zero and has to reegrow
    /// </summary>
    public float Height = .25f;

    public MDate SeedDate;

    private float _maxHeight;

    //set in UnityEditor Mannually
    public float MaxHeight
    {
        get { return _maxHeight; }
        set { _maxHeight = value; }
    }


    public bool ReplantedTree { get; set; }


    static public TerrainRamdonSpawner CreateTerraSpawn(string root, Vector3 origen, Vector3 rotation,
        int indexAllVertex, H hType,
        string name = "", Transform container = null, bool replantedTree = false,
        float height = 0, MDate seedDate = null, float maxHeight = 0,
        Quaternion rot = new Quaternion())
    {
        WAKEUP = true;
        TerrainRamdonSpawner obj = null;
        obj = (TerrainRamdonSpawner)Resources.Load(root, typeof(TerrainRamdonSpawner));

        if (obj==null)
        {
            Debug.Log("null:"+root);
        }

        obj = (TerrainRamdonSpawner)Instantiate(obj, origen, Quaternion.identity);
        if (name != "") { obj.name = name; }
        if (container != null){obj.transform.parent = container;}
        obj.IndexAllVertex = indexAllVertex;
        obj.HType = hType;
        obj.MyId = obj.Rename(name, obj.Id, obj.HType);
        obj.transform.name = obj.MyId;

        //here to avoid rotating object after spwaned
        //for loading
        obj.transform.rotation = rot;
        //for new obj
        obj.transform.Rotate(rotation);

        obj.ReplantedTree = replantedTree;
        obj.Height = height;
        obj.SeedDate = seedDate;
        return obj;
    }

	// Use this for initialization
	protected void Start () 
    {
        //needs to be define so in Router.cs he can see it as a blocking 
        Category = DefineCategory(HType);
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    internal bool Grown()
    {
        var ele = Program.gameScene.controllerMain.TerraSpawnController.Find(MyId);
        return ele.ReadyToMine();
    }
}
