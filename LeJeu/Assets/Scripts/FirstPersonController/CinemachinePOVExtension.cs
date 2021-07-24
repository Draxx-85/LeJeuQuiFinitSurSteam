using Cinemachine;
using UnityEngine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField]
    private float horizontalSpeed = 10;
    [SerializeField]
    private float verticalSpeed = 10;
    [SerializeField]
    private float clampAngle = 80f;

    private InputManager inputManager;
    private Vector3 startingRotation;
    private Transform Player;


    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        Player = this.transform.parent.transform;
        startingRotation.x = 0;
        startingRotation.y = 0;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(startingRotation == null)
                {
                    startingRotation = transform.localRotation.eulerAngles;
                }
                Vector2 deltaInput = inputManager.GetMouseDelta();
                startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                Player.localRotation = Quaternion.Euler(0f, startingRotation.x, 0f);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y , startingRotation.x , 0f);
            }
        }
    }
}
