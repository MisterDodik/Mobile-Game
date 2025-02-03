using UnityEngine;
using UnityEngine.InputSystem;
public class ControlsManager : MonoBehaviour
{

    private InputSystem_Actions playerInput;
    private InputSystem_Actions.PlayerActions playerActions;

    magnetSpawner magnetSpawner;
    FlashlightController flashlightController;
    BallController ballController;
    private void Awake()
    {
        playerInput = new InputSystem_Actions();
        playerActions = playerInput.Player;

        magnetSpawner = GetComponent<magnetSpawner>();
        flashlightController = GetComponent<FlashlightController>();
        ballController = GetComponent<BallController>();


        // playerActions.PlaceMagnet.performed += ctx => magnetSpawner.onClick(ctx.ReadValue<Vector2>());

        playerActions.MoveFlashlight.performed += ctx => flashlightController.onMove(ctx.ReadValue<Vector2>());
        playerActions.MoveFlashlight.canceled += ctx => flashlightController.onCancel();


        //---Movement---
        //playerActions.BallMove.performed += ctx => ballController.onTilt(ctx.ReadValue<Vector3>());       //for phone tilt
        //playerActions.BallMove1.performed += ctx => ballController.onKeyBoard(ctx.ReadValue<Vector2>());         //arrows

    }

    private void Update()
    {
        ballController.onKeyBoard(playerActions.BallMove1.ReadValue<Vector2>());

        if(UnityEngine.InputSystem.Gyroscope.current!=null)
        {
            InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
            return;
        }
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
        InputSystem.DisableDevice(UnityEngine.InputSystem.Gyroscope.current);
    }
}
