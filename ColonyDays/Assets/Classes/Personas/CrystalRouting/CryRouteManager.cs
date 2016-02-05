﻿/*
 * IMPORTANT: IF LANDZONES ARE NOT SET THE ROUTING SYSTEM WONT WORK
 * 
 * 
 */

using System;
using UnityEngine;

public class CryRouteManager
{
    private HPers _routeType;
    private Person _person;
    private VectorLand _one;
    private VectorLand _two;

    private CryRoute _cryRoute = new CryRoute();
    CryBridgeRoute _cryBridgeRoute ;
    
    private bool _isRouteReady;
    private TheRoute _theRoute = new TheRoute();
    private Structure _ini;
    private Structure _fin;

    private bool _iniDoor;
    private bool _finDoor;

    private string _destinyKey;//to be added to TheRoute obj
    private string _originKey;//to be added to TheRoute obj

    void SetIsRouteReady(bool val)
    {
        _isRouteReady = val;
        _cryRoute.IsRouteReady = val;
    }

    void SetTheRoute(TheRoute val)
    {
        _cryRoute.TheRoute = val;
        _theRoute = val;
    }

    public bool IsRouteReady
    {
        get { return _isRouteReady; }
        set { SetIsRouteReady(value); }
    }

    public TheRoute TheRoute
    {
        get { return _theRoute; }
        set { SetTheRoute(value); }//so This class can be saved and loaded
    }

    public string DestinyKey
    {
        get { return _destinyKey; }
        set { _destinyKey = value; }
    }

    public string OriginKey
    {
        get { return _originKey; }
        set { _originKey = value; }
    }

    public CryRouteManager(){}

    public CryRouteManager(Structure ini, Structure fin, Person person,
        HPers routeType = HPers.None, bool iniDoor = true, bool finDoor = true)
    {
        _originKey = ini.MyId;
        _destinyKey = fin.MyId;
        
        _iniDoor = iniDoor;
        _finDoor = finDoor;

        _routeType = routeType;
        _person = person;

        DefineOneAndTwo(ini, fin);
        
        _ini = ini;
        _fin = fin;

        if (ini == fin)
        {
            Debug.Log("Same ini-fin:"+ini.MyId+" . "+person.MyId);
        }

        ClearOldVars();
        Init();
    }

    void DefineOneAndTwo(Structure ini, Structure fin)
    {
        if (ini != null && ini.LandZone1.Count > 0)
        {
            _one = ini.LandZone1[0];
        }
        else
        {
            _one = new VectorLand("", ini.transform.position);
        }        
        
        if (fin != null && fin.LandZone1.Count > 0)
        {
            _two = fin.LandZone1[0];
        }
        else
        {
            _two = new VectorLand("", fin.transform.position);
        }
    }

    private void ClearOldVars()
    {
        _isRouteReady = false;

        if (_theRoute != null)
        {
            _theRoute.CheckPoints.Clear();
        }
        _theRoute = null;

        _cryRoute = null;
        _cryBridgeRoute = null;
    }

    private void Init()
    {
        //will stop a lot of instances where the landzone is not being initiated
        if (_one.LandZone == "" || _two.LandZone == "")
        {
            throw new Exception("One Routing was stopped bz 1 or more Lanzones were empty"+" oneLandZ:"+_one.LandZone+
            " twoLandZ:"+_two.LandZone);
            Debug.Log("One Routing was stopped bz 1 or more Lanzones were empty");
            return;
        }

        if (_one.LandZone != _two.LandZone)
        {
 //           Debug.Log("Bridge Routing");
            _cryBridgeRoute = new CryBridgeRoute(_ini, _fin, _person, _destinyKey);
        }
        else
        {
//            Debug.Log("Smple Routing");
            _cryRoute = new CryRoute(_ini, _fin, _person, _destinyKey, _iniDoor, _finDoor);
        }
    }

    public void Update () 
    {
        if (_cryRoute != null && !_isRouteReady)
        {
            _cryRoute.Update();

            if (_cryRoute.IsRouteReady)
            {
                _isRouteReady = true;
                _theRoute = _cryRoute.TheRoute;
            }
        }

        if (_cryBridgeRoute != null && !_isRouteReady)
        {
            _cryBridgeRoute.Update();

            if (_cryBridgeRoute.IsRouteReady)
            {
                _isRouteReady = true;
                _theRoute = _cryBridgeRoute.TheRoute;
            }
        }
	}
}
