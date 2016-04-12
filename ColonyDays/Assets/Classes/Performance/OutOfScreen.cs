﻿using UnityEngine;
using System.Collections;
/// <summary>
/// Each Person , Still element will have one instance of this class
/// </summary>
public class OutOfScreen
{

    //there are 2 types now, Person and StillElement
    private H _type;

    private Person _person;
    private Animal _animal;
    private Animator _animator;

    private BoxCollider _boxCollider;
    private Renderer _renderer;

    private StillElement _stillElement;

    private bool _onScreenNow;
    private bool _oldState;

    private H _currentLOD = H.LOD0;

    public OutOfScreen(Person person)
    {
        _type = H.Person;
        _person = person;
        InitPerson();
    }

    private void InitPerson()
    {
        _animator = _person.gameObject.GetComponent<Animator>();
        _boxCollider = _person.gameObject.GetComponent<BoxCollider>();
        _renderer = _person.Geometry.gameObject.GetComponent<Renderer>();
    }

    public OutOfScreen(Animal animal)
    {
        _type = H.Animal;
        _animal = animal;
        InitAnimal();
    }

    private void InitAnimal()
    {
        _animator = _animal.gameObject.GetComponent<Animator>();
        _boxCollider = _animal.gameObject.GetComponent<BoxCollider>();
        _renderer = _animal.Geometry.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    public void A45msUpdate()
	{
        if (Program.gameScene.Fustrum1.OnFustrum(_boxCollider) && _renderer.isVisible && !_onScreenNow)
        {
            _onScreenNow = true;
            SwitchNow();
        }
        else if ((!Program.gameScene.Fustrum1.OnFustrum(_boxCollider) || !_renderer.isVisible) && _onScreenNow)
        {
            _onScreenNow = false;
            SwitchNow();
        }
	}

    public void SetNewLOD(H newLOD)
    {
        _currentLOD = newLOD;
        SwitchNow();
    }



    private void SwitchNow()
    {
        if (_onScreenNow && _currentLOD == H.LOD0)
        {
            OnBecameVisible();
        }
        else OnBecameInvisible();
    }

    void OnBecameVisible()
    {
        //Debug.Log("became visible " + _person.MyId);
        Activate();
    }

    void OnBecameInvisible()
    {
        //Debug.Log("became Invisible " + _person.MyId);
        DeActivate();
    }

    internal void Activate()
    {

            ActivatePerson();
        
    }

    private void ActivatePerson()
    {
        _animator.enabled = true;
    }

    internal void DeActivate()
    {

            DeActivatePerson();
      
    }

    private void DeActivatePerson()
    {
        _animator.enabled = false;

    }
}
