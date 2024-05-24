using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Transform _waypointMain;
    [SerializeField, Range(0f, float.MaxValue)] private float _speed;
    [Tooltip("Start waypoint index"), SerializeField] private int _waypointIndex;

    private Transform[] _waypoints;

    private void Start()
    {
        _waypoints = new Transform[_waypointMain.childCount];

        for (int i = 0; i < _waypointMain.childCount; i++)
            _waypoints[i] = _waypointMain.GetChild(i).GetComponent<Transform>();

        if (_waypointIndex < 0 || _waypointIndex >= _waypoints.Length)
            _waypointIndex = 0;
    }

    private void Update()
    {
        Transform currentWaypoint = _waypoints[_waypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == currentWaypoint.position)
            CalculateNextWaypointIndex();
    }

    private void CalculateNextWaypointIndex()
    {
        _waypointIndex++;

        if (_waypointIndex == _waypoints.Length)
            _waypointIndex = 0;
    }
}