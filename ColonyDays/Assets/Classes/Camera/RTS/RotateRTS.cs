﻿using UnityEngine;

public class RotateRTS : GenericCameraComponent {

    float MIN_Y = 17.7f;//17.7f 18  10.8   20     
    float MAX_Y = 110f;//120 60 50
    Vector3 oldPos;

    float tutorialStepStartedAt = -1;

    //move down and up thru Y
    public Vector3 MoveThruY(Transform current, float min, float max, float change)
    {
        Vector3 temp = current.position;
        temp.y += change;
        var fovChange = -5*change;
        if (temp.y > max)
        {
            Program.gameScene.TutoStepCompleted("CamHeaven.Tuto");
            temp.y = max;
            ResetLeftChangeVal();
            fovChange = 0;
        }
        else if (temp.y < min)
        {
            temp.y = min;
            ResetLeftChangeVal();
            fovChange = 0;
        }
        //CamControl.CAMRTS.CameraFOV(fovChange);

        return temp;
    }

    //Rotates camera hor and vert
    public void RotateCam(General helpCam360GrabPosY, General helpCam360MainY,
        Transform target, float camSensivity, float smoothTime, ref Vector3 velocity)
    {

        if (Input.GetAxis("Mouse ScrollWheel") == 0)
        {
            RotateCamHor(helpCam360GrabPosY.transform,
                helpCam360MainY.transform, target, camSensivity);
        }

        RotateCamVert(camSensivity, target, -Input.GetAxis("Mouse ScrollWheel") * 50);//100

        CamControl.CAMRTS.centerTarget.transform.rotation = TransformCam.rotation;
        TransformCam.parent = CamControl.CAMRTS.centerTarget.transform;
    }

    Transform _target;
    public void RotateCamVert(float camSensivity, Transform target, float changeValue)
    {
        var qOrE = (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E)) && !MouseListener.MouseOnWindowNow;
        TransformCam.parent = null;
 
        _target = target;
        if (changeValue != 0 && !qOrE)
        {
            //reset leftChange if val change direction 
            if (leftChangeVal < 0 && changeValue > 0)
            {
                leftChangeVal = 0;
            }
            else if (leftChangeVal > 0 && changeValue < 0)
            {
                leftChangeVal = 0;
            }
            leftChangeVal += changeValue;

        }
    }





    public void RotateCamHor(Transform helpCam360GrabPosY, Transform helpCam360MainY,
        Transform target, float camSensivity)
    {
        TransformCam.parent = helpCam360GrabPosY.transform;
        float changeValue = 0;

        bool qOrE = false;
        if (Input.GetKey(KeyCode.Q))
        {
            qOrE = true;
            changeValue = .4f * camSensivity;
        }
        if (Input.GetKey(KeyCode.E))
        {
            qOrE = true;
            changeValue = -.4f * camSensivity;
        }
        
        //when Q or E this wont work
        if (Input.GetAxis("Mouse X") != 0 && !qOrE)
        {
            changeValue = Input.GetAxis("Mouse X") * camSensivity;
        }
        if (Input.GetAxis("Horizontal") != 0 && !qOrE)
        {
            changeValue = Input.GetAxis("Horizontal") * camSensivity;
        }

        if (changeValue != 0)
        {
            helpCam360MainY.transform.Rotate(new Vector3(0, changeValue, 0));
            TransformCam.LookAt(target);

            //leftChangeVal = changeValue;

            if (TutoWindow.IsStepReady("CamRot.Tuto"))
            {
                Program.gameScene.TutoStepCompleted("CamRot.Tuto");
            }

        }
    }

    float leftChangeVal;

    
    public void Update()
    {
        if (leftChangeVal != 0)
        {
            var changeVal = ChangeValHand();

            TransformCam.position = MoveThruY(TransformCam, MIN_Y, MAX_Y, changeVal);
            TransformCam.LookAt(_target);
        }
    }

    void ResetLeftChangeVal()
    {
        leftChangeVal = 0;
    }

    void ResetValorMove()
    {
        valorMove = .1f + (TransformCam.position.y/100);
    }

    float ChangeValHand()
    {
        if (leftChangeVal < 1.5 && leftChangeVal > -1.5)
        {
            ResetLeftChangeVal();
            return 0;
        }
        var locChange = ValorMove() * GetSign();

        ChangeLeftChangeVal(locChange, -1);

        return locChange;
    }

    /// <summary>
    /// Will change LeftToCHangeVal however if the new 
    /// </summary>
    /// <param name="locChange"></param>
    /// <param name="sign"></param>
    void ChangeLeftChangeVal(float locChange, int sign)
    {
        var oldSign = GetSign();
        leftChangeVal += (locChange * sign);

        //means it went over to the other sign
        if (oldSign != GetSign())
        {
            leftChangeVal = 0;
        }
    }


    float valorMove = -1;
    /// <summary>
    /// lineal increase
    /// </summary>
    /// <returns></returns>
    float ValorMove()
    {
        ResetValorMove();

        //valorMove += .03f;
        return valorMove;
    }

    /// <summary>
    /// bz needs to find the zero
    /// </summary>
    /// <returns></returns>
    float GetSign()
    {
        if (leftChangeVal < 0)
        {
            return -1;
        }
        return 1;
    }
}