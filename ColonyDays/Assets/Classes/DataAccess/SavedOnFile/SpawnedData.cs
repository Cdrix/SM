﻿using UnityEngine;
using System.Collections.Generic;

public class SpawnedData {

    public Vector3 Pos;
    public Quaternion Rot;
    public H Type;
    public int RootStringIndex;//index of the list root string, defined on TerrainSpawnController
    public int AllVertexIndex;//correspondant current obj index in the Terreno.MeshController.AllVertex List

    public List<SpawnedData> AllSpawnedObj = new List<SpawnedData>();//containts all spawned date serie saved
    public int TerraMshCntrlAllVertexIndexCount;//Terreno.MeshController.AllVertex saved

    //the tree height 
    //used when a tree is replanted 
    public float TreeHeight = 1;

    public MDate SeedDate;
    public float MaxHeight;


    public SpawnedData(Vector3 posP, Quaternion rotP, H typeP,  int rootStringIndexP,
        int allVertexIndexP, float treeHeight=0, MDate seedDate=null, float maxHeight=0)
    {
        Pos = posP;
        Rot = rotP;
        Type = typeP;
        RootStringIndex = rootStringIndexP;
        AllVertexIndex = allVertexIndexP;

        TreeHeight = treeHeight;
        SeedDate = seedDate;
        MaxHeight = maxHeight;
    }

    public SpawnedData(){}
}
