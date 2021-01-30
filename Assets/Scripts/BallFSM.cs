using UnityEngine;
using UnityEngine.UI;

public class BallFSM : ByTheTale.StateMachine.MachineBehaviour
{
    public override void AddStates()
    {
        AddState<BallStateSettingAngle>();
        AddState<BallStateSettingStrength>();
        AddState<BallStateRolling>();

        SetInitialState<BallStateSettingAngle>();
    }

    // remove from public once max force is determined
    [Tooltip("The amount of force applied with no additional strength.")]
    public float pushAmount;
    [Tooltip("The max amount of force to be applied via the meter.")]
    public float pushModifier;

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
    public float inputH;
    public float inputV;
    public bool escapePressed;
    public bool reloadPressed;
    public bool setPressed;

    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        shotGraphUI.gameObject.SetActive(false);

        trail = GetComponentInChildren<TrailRenderer>();

    }

    public override void Update()
    {
        base.Update();
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        escapePressed = Input.GetKeyDown(KeyCode.Escape);
        reloadPressed = Input.GetKeyDown(KeyCode.R);
        setPressed = Input.GetKeyDown(KeyCode.Space);

        // Change the length of the trail based on velocity
        trail.time = body.velocity.magnitude * 0.1f;

        // TODO: Slow the ball over time
    }
}
