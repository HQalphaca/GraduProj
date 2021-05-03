using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    private Transform _WayPoint;
    private Transform _targetPoint;
    private float progress;
    private int waypointIndex = 0;
    private float moveSpeed = 1.6f;

    private void Awake()
    {
        _WayPoint = SpawnManager.Instance.wayPoints[waypointIndex];
        _targetPoint = SpawnManager.Instance.wayPoints[waypointIndex+1];
    }
    void Update()
    {
        this.transform.position = Vector3.Lerp(_WayPoint.position, _targetPoint.position, progress);
        progress += (Time.deltaTime * 0.12f) * moveSpeed;
        if (progress >= 1f)
        {
            ChangeWayPoints();
            progress = 0;
        }
    }

    private void ChangeWayPoints()
    {
        waypointIndex += 1;
        if (waypointIndex >= SpawnManager.Instance.wayPoints.Length)
        {
            waypointIndex = 0;
            _WayPoint = SpawnManager.Instance.wayPoints[waypointIndex];
            _targetPoint = SpawnManager.Instance.wayPoints[waypointIndex + 1];
        }
        else
        {
            _WayPoint = SpawnManager.Instance.wayPoints[waypointIndex];
            if (waypointIndex + 1 >= SpawnManager.Instance.wayPoints.Length)
            {
                _targetPoint = SpawnManager.Instance.wayPoints[0];
            }
            else
            {
                _targetPoint = SpawnManager.Instance.wayPoints[waypointIndex + 1];
            }
        }
    }
}
