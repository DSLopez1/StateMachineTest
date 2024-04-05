using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private float defaultDistance = 6f;
    [SerializeField] [Range(0, 10)] private float maxDist = 6;
    [SerializeField] [Range(0, 10)] private float minDist = 1;

    [SerializeField] [Range(0, 10)] private float smoothing = 4;
    [SerializeField] [Range(0, 10)] private float zoomSens = 1;

    private CinemachineFramingTransposer framingTransposer;
    private CinemachineInputProvider inputProvider;

    private float currentTargetDist;

    private void Awake()
    {
        framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
        inputProvider = GetComponent<CinemachineInputProvider>();

        currentTargetDist = defaultDistance;
    }

    private void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        float zoomVal = inputProvider.GetAxisValue(2) * zoomSens;

        currentTargetDist = Mathf.Clamp(currentTargetDist + zoomVal, minDist, maxDist);

        float currentDist = framingTransposer.m_CameraDistance;

        if (currentDist == currentTargetDist)
            return;

        float lerpedZoomVal = Mathf.Lerp(currentDist, currentTargetDist, smoothing * Time.deltaTime);

        framingTransposer.m_CameraDistance = lerpedZoomVal;
    }

}
