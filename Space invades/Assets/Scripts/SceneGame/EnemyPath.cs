using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _pathPoints = new List<Transform> ();

    private void Awake()
    {
        Destroy (gameObject);
    }
    public void AddPoints(Transform point)
    {
        _pathPoints.Add(point);
    }
    
    public List<Vector2> GetPathPoints()
    {
        List<Vector2> points = new List<Vector2>();
        foreach(var item in _pathPoints)
        {
            points.Add(item.position);
        }
        return points;
    }
}

