using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private float _defaultDistance = 6f;
    [SerializeField] [Range(0, 10)] private float _maxDist = 6;
    [SerializeField] [Range(0, 10)] private float _minDist = 1;

    [SerializeField] [Range(0, 10)] private float _smoothing = 4;
    [SerializeField] [Range(0, 10)] private float _zoomSens = 1;

    private CinemachineFramingTransposer _framingTransposer;
    private CinemachineInputProvider _inputProvider;

    private float _currentTargetDist;

    private void Awake()
    {
        _framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
        _inputProvider = GetComponent<CinemachineInputProvider>();

        _currentTargetDist = _defaultDistance;
    }

    private void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        float zoomVal = _inputProvider.GetAxisValue(2) * _zoomSens;

        _currentTargetDist = Mathf.Clamp(_currentTargetDist + zoomVal, _minDist, _maxDist);

        float currentDist = _framingTransposer.m_CameraDistance;

        if (currentDist == _currentTargetDist)
            return;

        float lerpedZoomVal = Mathf.Lerp(currentDist, _currentTargetDist, _smoothing * Time.deltaTime);

        _framingTransposer.m_CameraDistance = lerpedZoomVal;
    }

}
