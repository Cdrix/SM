﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Structure : StructureParent
{
    private MDate _usedAt = new MDate();

    private bool isStageObjHidden;
    private Farm _farm;//will be use if Structure is a farm 

    /// <summary>
    /// For Dummy OBj
    /// </summary>
    public MDate UsedAt
    {
        get { return _usedAt; }
        set { _usedAt = value; }
    }

    /// <summary>
    /// This is the method that moves the building around in the terrain 
    /// when is newly built
    /// </summary>
    public override void UpdateClosestVertexAndOld()
    {
        if (!isStageObjHidden)
        {
            Geometry.SetActive(true);
            isStageObjHidden = true;
        }

        base.UpdateClosestVertexAndOld();
        gameObject.transform.position = ClosestSubMeshVert;

        if (_arrow != null)
        {
            ArrowColorUpdate();
        }

        if (Projector != null)
        {
            Projector.SwitchColorLight(IsBuildOk);
        }
    }

    void ArrowColorUpdate()
    {
        if (IsBuildOk)
        {
            _arrow.Geometry.GetComponent<Renderer>().material.color = InitialColor;
        }
        else if (!IsBuildOk) { _arrow.Geometry.GetComponent<Renderer>().material.color = Color.red; }
    }

    public override void DonePlace()
    {
        //updates the build 
        //calling update here to correct bugg that plane was not in the same position
        //as geometry 
        UpdateBuild();
        //then is Build is ok...
        if (IsBuildOk)
        {
            FinishPlacingMode(H.Done);
            if (!IsLoadingFromFile)
            {
                AddOnRegistro();
            }
            InitHouseProp();
        }
        else if (!IsEven) { GameScene.ScreenPrint("Can't place here: uneven terrain! Struc"); }
        else if (IsColliding) { GameScene.ScreenPrint("Can't place here: colli"); }
        else { GameScene.ScreenPrint("could be the sea Struct.cs"); }
    }

    public void AddOnRegistro()
    {
        RedoCategoryOnShack();

        //so the rect for collision is bigger
        //to address SpawnPoint not falling into another build
        var scale = UPoly.ScalePoly(Bounds, 0.2f);

        //startin satge is save on ReSaveStartinStage()
        BuildingPot.Control.Registro.AddBuildToAll(MyId, HType, scale, Category, transform.position,
            Inventory,
            PeopleDict, 
            LandZone1,
            rotationFacerIndex: RotationFacerIndex, materialKey: MaterialKey,
            instructionP: Instruction, BookedHome1: BookedHome1, 
            dispatch: Dispatch1, Families: Families,
            dollarsPay: DollarsPay,
            anchors: Anchors, dock: Dock1
            );
    }

    /// <summary>
    /// Canceling dempolishi
    /// </summary>
    public void CancelDemolish()
    {
       //Debug.Log("Cancel Demiolish");
        AddOnRegistro();
        BuildingPot.Control.DispatchManager1.RemoveEvacOrders(MyId);

        PositionFixed = true;
        _isOrderToDestroy = false;
        Instruction=H.None;

        BuildingPot.Control.Registro.RemoveFromDestroyBuildings(this);
    }

    /// <summary>
    /// Just bz Shack is loosing is a Strucute ... so i will re assign it here 
    /// </summary>
    void RedoCategoryOnShack()
    {
        Category = DefineCategory(HType);
    }

    private bool reverse;
    public void AssignNewMaterial(Material newMat)
    {
        //this is here for testing and shwoing purpose
        reverse = !reverse;
        SmokePlay(reverse);
        //
        Geometry.GetComponent<Renderer>().sharedMaterial = newMat;
    }

    /// <summary>
    /// The action when user finish placing a building 
    /// </summary>
    public override void FinishPlacingMode(H action)
    {

        if (_arrow != null)
        {
            _arrow.Destroy();
            _arrow = null;
        }

        DestroyProjector();

        base.FinishPlacingMode(action);
        
        //Mark the Spawns below this obj
        if (action != H.Cancel)
        {
            float howBigTheCollidingSphere = 5f;

            //was leaving Spawner inside the farm
            if (MyId.Contains("Farm"))
            {
                howBigTheCollidingSphere = 15;
            }

            MarkTerraSpawnRoutine(howBigTheCollidingSphere, from: transform.position);
        }

        //is here because when loading from file was hidden the wheel
        if (!IsLoadingFromFile)
        {
            ShowWheel(false);
        }
    }

    // Use this for initialization
	protected void Start () 
    {
	    if (MyId.Contains("Dummy"))
	    {
	        return;
	    }


        base.Start();

        //print("b4 gen Uni#:" + General.UnivRotationFacer);
        //print("facer#:" + RotationFacerIndex);

        //the dummys one dont need rotation other wise will screw the BuildingPot.Control.CurrentSpawnBuild
	    if (b.CurrentSpawnBuild != null && HType != H.Dummy)
	    {
	        b.CurrentSpawnBuild.transform.Rotate(0, RotationFacerIndex*90, 0);
	    }

	    //so bounds get updateds
        CheckIfIsEvenRoutine();

        if (!IsLoadingFromFile )
        {
            CreateArrow();
        }
    }



    void CreateArrow()
    {
        if (b.CurrentSpawnBuild == null || _arrow != null || MyId.Contains(H.Dummy.ToString()) || HType == H.Shack)
        { return;}

        _arrow = Create(Root.arrow, new Vector3());
        _arrow.transform.Rotate(0, RotationFacerIndex*90, 0);
        _arrow.transform.parent = b.CurrentSpawnBuild.transform;
        
        if (Bounds.Count > 0)
        {
            _arrow.transform.position = ReturnArrowIniPos(1.75f);
        }
    }

    /// <summary>
    /// Returns the initial position of an arrow
    /// </summary>
    Vector3 ReturnArrowIniPos(float howApartFromBuild)
    {
        Vector3 res = new Vector3();
        if (RotationFacerIndex == 0)
        {
            res = new Vector3(((Bounds[0].x + Bounds[1].x) / 2), Bounds[0].y, Bounds[0].z + howApartFromBuild);
        }
        else if (RotationFacerIndex == 1)
        {
            res = new Vector3(Bounds[1].x + howApartFromBuild, Bounds[1].y, (Bounds[1].z + Bounds[2].z) / 2);
        }
        else if (RotationFacerIndex == 2)
        {
            res = new Vector3(((Bounds[3].x + Bounds[2].x) / 2), Bounds[2].y, Bounds[2].z - howApartFromBuild);
        }
        else if (RotationFacerIndex == 3)
        {
            res = new Vector3(Bounds[0].x - howApartFromBuild, Bounds[0].y, (Bounds[1].z + Bounds[2].z) / 2);
        }
        return res;
    }
	
	// Update is called once per frame
	protected void Update () 
    {
        //if is dummy doesnt need to be raycasting th blue rays all the time etc
	    if (MyId.Contains("Dummy"))
	    {
	        return;
	    }

	    if (_arrow != null)
	    {
            if (_arrow.transform.position != ReturnArrowIniPos(1.75f) && Bounds.Count > 0)
	        {
	            _arrow.transform.position = Vector3.Lerp(_arrow.transform.position, ReturnArrowIniPos(1.75f), 0.5f);
	        }
	    }

	    base.Update();
	    if (!PositionFixed)
	    {
            //Will destroy the current obj if in Building._isOrderToDestroy is set to true
            //and PersonController is -1
            DestroyOrdered();
	    }
        else if (PositionFixed && CurrentStage == 0)
        {
            if (_startingStage == H.None)
            {
                ShowNextStage();
            }
            else if (_startingStage != H.None && CurrentStage == 0)
            {
                RecreateStage();
            }
        }
        
        if (PositionFixed && _startingStage == H.Done && MyId.Contains("Farm"))
        {
            CreateFarm();
        }

	    UpdateFarm();
    }

    #region FieldFarm 

    void UpdateFarm()
    {
        if (_farm != null)
        {
            if (MyId.Contains("FieldFarm"))
            {
                var ff = (FieldFarm)_farm;
                ff.Update();
            }
        }
    }

    void CreateFarm()
    {
        if (_farm != null)
        {
            return;
        }

        if (MyId.Contains("FieldFarm"))
        {
            _farm=new FieldFarm(this);
           //Debug.Log("new farm");
        }
    }

    //so a new farm can be created 
    internal void DestroyFarm()
    {
        _farm = null;
    }

    /// <summary>
    /// When a worker works in a farm 
    /// </summary>
    public void AddWorkToFarm()
    {
        //in case is redoing farm 
        if (_farm==null)
        {
            return;
        }

        if (MyId.Contains("FieldFarm"))
        {
            _farm.AddWorkToFarm();
        }
    }

    public void ChangeProduct(P newProd)
    {
        if (_farm != null)
        {
            var fieldd = (FieldFarm) _farm;
            fieldd.ChangeProduct(newProd);
        }
    }

#endregion

    /// <summary>
    /// Demolishing a building 
    /// </summary>
    public void Demolish()
    {
        //if is a house need to know 
        if (MyId.Contains("House") || MyId.Contains("Shack"))
        {
            if (BuildingPot.Control.HowManyEmptyFamilies() >= Families.Length)
            {
                StartDemolishProcess();
            }
            else
            {
                //todo notify
               //Debug.Log("People in this house have no where to go. Please build something at least a shack and try" +
                         //  " again deleting this building");
                _isOrderToDestroy = false;
            }
        }
        else StartDemolishProcess();
    }

    void StartDemolishProcess()
    {
        //BuildingPot.Control.Registro.MarkBuildingAs(MyId, H.WillBeDestroy);
        BuildingPot.Control.Registro.RemoveItem(Category, MyId);
        //HideAll();   
    }


    private void HideAll()
    {
        //Hide(basePlane.gameObject);
        Hide(Stage2);
        Hide(Stage3);
        Hide(Geometry);
    }


    void Hide(GameObject gP)
    {
        gP.SetActive(false);
        //Renderer r = gP.GetComponent<Renderer>();
        //r.enabled = false;
    }

    //implement
    internal bool HasEnoughToCoverOrder(Order _order)
    {
        return true;
    }



    /// <summary>
    /// the Farm zone of a farm
    /// </summary>
    /// <returns></returns>
    public GameObject FarmZone()
    {
        return GetChildCalled("FarmZone");
    }




}
