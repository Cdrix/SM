﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MyText : MonoBehaviour
{
    private bool mappedOnce;
    private Text thisText;

	// Use this for initialization
	void Start ()
	{
	    thisText = GetComponent<Text>();
	    Map();

        StartCoroutine("FiveSecUpdate");
	}

    private IEnumerator FiveSecUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(5); // wait

            if (name == "Loaded")
            {
                thisText.text = Program.gameScene.controllerMain.TerraSpawnController.PercentageLoaded();
            }
        }
    }

    private void Map()
    {
        if (Program.InputMain == null)
        {
            return;
        }

        if (name == "Version")
        {
            thisText.text = GameScene.VersionLoaded();
            mappedOnce = true;
        }

        if (!Program.InputMain.IsGameFullyLoaded() || !Program.gameScene.GameFullyLoaded())
        {
            return;
        }

        mappedOnce = true;

        if (name == "Person")
        {
            thisText.text = PersonPot.Control.All.Count + "";
        } 
        if (name == "Emigrate")
        {
            thisText.text = PersonPot.Control.EmigrateController1.Emigrates.Count + "";
        }
        if (name == "Food")
        {
            var amt = GameController.ResumenInventory1.ReturnAmountOnCategory(PCat.Food);

            thisText.text =  Unit.WeightConverted(amt).ToString("N0") + " " +
                Unit.WeightUnit();
        }

        if (name == "Happy")
        {
            thisText.text = PersonPot.Control.OverAllHappiness();
        }

        if (name == "PortReputation")
        {
            thisText.text = BuildingPot.Control.DockManager1.PortReputation.ToString("F1");
        }
        if (name == "PirateThreat")
        {
            thisText.text = BuildingPot.Control.DockManager1.PirateThreat.ToString("F1");
        }

        if (name == "Dollars")
        {
            thisText.text = Program.gameScene.GameController1.Dollars.ToString("C0");
        }

      
    }


    private static int reMapCount;//since is static need to remap all the times exist MyText.cs scripts

	// Update is called once per frame
	void Update ()
    {
        reMapCount++;

        if (reMapCount > 60)
        {
            reMapCount = 0;
            Map();
        }

        if (!mappedOnce)
        {
            Map();
        }

        if (name == "Date")
        {
            thisText.text = Program.gameScene.GameTime1.Day + " "
                + Program.gameScene.GameTime1.MonthFormat() + " "
                + Program.gameScene.GameTime1.Year;
        }
	}



}
