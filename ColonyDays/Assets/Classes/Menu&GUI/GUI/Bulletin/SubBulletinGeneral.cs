﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Classes.Menu_GUI.GUI.Bulletin
{
    class SubBulletinGeneral
    {
        private BulletinWindow _bulletinWindow;

        //how many people work in places
        Dictionary<string, int> _report = new Dictionary<string, int>(); 

        List<Item> _finReport = new List<Item>(); 

        public SubBulletinGeneral(BulletinWindow win)
        {
            _bulletinWindow = win;
        }


        #region Control Workers
        bool reDoneSalaries;//for users  that changed salaries already
        public void ShowWorkers()
        {
            if (!reDoneSalaries)
            {
                reDoneSalaries = true;
                BuildingPot.Control.Registro.DoEquealPaymentForAllWorks();
            }

            _report.Clear();

            var list = BuildingPot.Control.Registro.StringOfAllBuildingsThatAreAWork().Distinct().ToList();

            list.Insert(0, "Unemployed");
            ShowWorkers(list);

            _bulletinWindow.AdjustContentHeight(list.Count * 5.2f);
        }

        List<WorkerTile> _reports = new List<WorkerTile>();
        private void ShowWorkers(List<string> list)
        {
            Hide();
            _bulletinWindow.ShowScrool();

            for (int i = 0; i < list.Count; i++)
            {
                var iniPosHere = _bulletinWindow.ScrollIniPosGo.transform.localPosition +
                                 new Vector3(0, -(ReturnRelativeYSpace(4.75f, ReturnTileYScale())) * i, 0);

                var a = WorkerTile.CreateTile(_bulletinWindow.Content.gameObject.transform, list[i],
                    iniPosHere);

                _reports.Add(a);
            }
        }



        float ReturnTileYScale()
        {
            if (_reports.Count > 0)
            {
                return _reports[0].transform.localScale.y;
            }
            return 0;
        }

        public static float ReturnRelativeYSpace(float relative, float ySpaceOfTile)
        {
            return relative * ySpaceOfTile;
        }


        internal void Hide()
        {
            for (int i = 0; i < _reports.Count; i++)
            {
                _reports[i].Destroy();
            }
            _reports.Clear();
        }


        #endregion






        string Pad(string pad, int current, int max, int padCount)
        {
            string res = "";

            var needPads = (max - current) + padCount;

            for (int i = 0; i < needPads; i++)
            {
                res += pad;
            }
            return res;
        }



        void CreateDict(List<Person> workers)
        {
            for (int i = 0; i < workers.Count; i++)
            {
                AddKeyToReport(workers[i].Work.HType+"");
            }

            for (int i = 0; i < _report.Count; i++)
            {
                _finReport.Add(new Item(_report.ElementAt(i).Key, _report.ElementAt(i).Value));
            }
            _finReport = _finReport.OrderByDescending(a => a.Value).ToList();
        }   
        
        void CreateDict(List<string> builds)
        {
            for (int i = 0; i < builds.Count; i++)
            {
                AddKeyToReport(builds[i]);
            }

            for (int i = 0; i < _report.Count; i++)
            {
                _finReport.Add(new Item(_report.ElementAt(i).Key, _report.ElementAt(i).Value));
            }
            _finReport = _finReport.OrderByDescending(a => a.Value).ToList();
        }

        void AddKeyToReport(string key)
        {
            //if (key.Contains("AnimalFarm"))
            //{
            //    key = "AnimalFarm";
            //}
            //else if (key.Contains("FieldFarm"))
            //{
            //    key = "FieldFarm";
            //}

            //addig
            if (_report.ContainsKey(key))
            {
                _report[key] += 1;
            }
            else
            {
                _report.Add(key, 1);
            }
        }





#region Buildings

        public void ShowBuildings()
        {
            _report.Clear();
            _finReport.Clear();

            _bulletinWindow.ShowInBody(Buildings());
        }

        private string Buildings()
        {
            var hTypes = BuildingPot.Control.Registro.StringOfAllBuildingsHType();

            CreateDict(hTypes);

            string res = Languages.ReturnString("Buildings") + ":\n ";


            for (int i = 0; i < _finReport.Count; i++)
            {
                var pad = Pad(" ", (_finReport[i].Key + ": ").Length, 15, 0);
                res += _finReport[i].Key + ": " + pad + _finReport[i].Value + "\n ";
            }

            return res;
        }



#endregion


    





    }

    class Item
    {
        private string _key;
        private int _value;

        public Item(string key, int val)
        {
            _key = key;
            _value = val;
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
    }
}
