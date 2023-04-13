using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] private float speed = 2f;

    private WaitForEndOfFrame _pathWaitTime;
    private Enemy _enemy;

    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    private void Start()
    {
        _pathWaitTime = new WaitForEndOfFrame();
        _enemy = GetComponent<Enemy>();
    }
    private void FinishPath()
    {
        _enemy.StealGold();
        gameObject.SetActive(false);
    }
    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    private void FindPath()
    {
        path.Clear();

        var parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            var waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
                path.Add(waypoint);
        }

    }
    IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            Vector3 starterPos = transform.position;
            Vector3 enderPos = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(enderPos);
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(starterPos, enderPos, travelPercent);
                yield return _pathWaitTime;
            }
        }
        FinishPath();
    }
}
