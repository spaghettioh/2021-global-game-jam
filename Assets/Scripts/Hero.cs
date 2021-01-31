using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Hero : ByTheTale.StateMachine.MachineBehaviour
{
    public override void AddStates()
    {
        //AddState<HeroStateSettingAngle>();
        AddState<HeroStateSettingStrength>();
        AddState<HeroStateRepositioning>();
        AddState<HeroStateMoving>();

        SetInitialState<HeroStateMoving>();
    }

    public Canvas finishScreen;

    [HideInInspector]
    public bool finished;
    public UnityEvent finishEvent;

    // remove from public once max force is determined
    [Tooltip("The amount of force applied with no additional strength.")]
    public float pushAmount;
    [Tooltip("The max amount of force to be applied via the meter.")]
    public float pushMultiplier;

    public GameObject strokeAngleIndicator;
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

        if (reloadPressed)
        {
            AppHelper.Reload(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
        }

        // Change the length of the trail based on velocity
        trail.time = body.velocity.magnitude * 0.1f;

        if (finished)
        {
            finishEvent.Invoke();
            finished = false;
        }
    }

    public void TriggerMovementFromTutorial()
    {
        triggeredFromTutorial = true;
    }
}
