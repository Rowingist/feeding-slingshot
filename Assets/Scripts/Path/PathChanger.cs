using UnityEngine;

[RequireComponent(typeof(FlightPath))]
public class PathChanger : MonoBehaviour
{
    [SerializeField, Range(1, 20)] private float _pointingMultilier;

    private FlightPath _flightPath;

    private Vector3 _newHighestPointPosition, _newFinishPointPosition;
    private Vector3 _mouseStartPosition;
    private float _finishPointPozitionX;

    private void Awake()
    {
        _flightPath = GetComponent<FlightPath>();
    }

    private void Start()
    {
        _finishPointPozitionX = _flightPath.GetFinishPointPosition().x;
    }

    private void Update()
    {
        MoveHighestPoint();
        MoveFinishPoint();
    }

    private void MoveHighestPoint()
    {
        Vector3 deltaMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition - _mouseStartPosition);
        _newHighestPointPosition = -deltaMousePosition;
        _newHighestPointPosition.z = _flightPath.GetHighestPointPosition().z;
        _flightPath.MoveHighestPointTo(_newHighestPointPosition * _pointingMultilier);
    }

    private void MoveFinishPoint()
    {
        _newFinishPointPosition.x = _finishPointPozitionX - Camera.main.ScreenToViewportPoint(Input.mousePosition - _mouseStartPosition).x;
        _newFinishPointPosition.z = _flightPath.GetFinishPointPosition().z;
        _newFinishPointPosition.y = _flightPath.GetFinishPointPosition().y;
        _flightPath.MoveFinishPointTo(_newFinishPointPosition);
    }

    public void SetMouseStartPosition(Vector3 mouseStartPosotion)
    {
        _mouseStartPosition = mouseStartPosotion;
    }
}