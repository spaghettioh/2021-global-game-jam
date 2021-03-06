﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Hero : ByTheTale.StateMachine.MachineBehaviour
{
    public override void AddStates()
    {
        AddState<HeroStateSettingStrength>();
        AddState<HeroStateRepositioning>();
        AddState<HeroStateMoving>();

        SetInitialState<HeroStateMoving>();
    }

    // remove from public once max force is determined
    [Tooltip("The amount of force applied with no additional strength.")]
    public float pushAmount;
    [Tooltip("The max amount of force to be applied via the meter.")]
    public float pushMultiplier;

    public Canvas shotGraphUI;
    public Slider pushStrengthMeter;
    //internal Slider englishLeftRightMeter;
    //internal Slider englishBottomUpMeter;
    
    internal Rigidbody2D body;
    internal float pushAngle;
    internal float pushPitch;

    // Effects
    TrailRenderer trail;

    // Inputs
    internal float inputH;
    internal float inputV;
    internal bool escapePressed;
    internal bool reloadPressed;
    internal bool setButtonPressed;
    public bool triggeredFromTutorial;

    [HideInInspector]
    public GameObject lastCollidedWith;
    [HideInInspector]
    public float targetShotAngle;



    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        shotGraphUI.gameObject.SetActive(false);

        trail = GetComponentInChildren<TrailRenderer>();

    }

    public override void Update()
    {
        base.Update();
        //inputH = Input.GetAxis("Horizontal");
        //inputV = Input.GetAxis("Vertical");
        escapePressed = Input.GetKeyDown(KeyCode.Escape);
        reloadPressed = Input.GetKeyDown(KeyCode.R);
        //setButtonPressed = Input.GetKeyDown(KeyCode.Space);


        // Change the length of the trail based on velocity
        trail.time = body.velocity.magnitude * 0.1f;

    }

    public void TriggerMovementFromTutorial()
    {
        triggeredFromTutorial = true;
    }
}
