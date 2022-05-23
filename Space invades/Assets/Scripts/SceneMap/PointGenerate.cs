using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PointGenerate : MonoBehaviour
{
    [SerializeField]
    private EventMap _pointplayble;
    [SerializeField]
    private GameObject _pointLocked;
    [SerializeField]
    private GameObject _path;
    [SerializeField]
    private List<Sprite> _sprites;
    [SerializeField]
    private UnityEvent OnGenerated;

    private void Start()
    {
        Generate();
    }
    private void Generate()
    {
        PointStates pointStates = new PointStates();
        pointStates.States.Add(PointState.OneStar);
        pointStates.States.Add(PointState.Open);
        pointStates.States.Add(PointState.TwoStar);
        pointStates.States.Add(PointState.ThreeStar);
        pointStates.States.Add(PointState.Locked);
        pointStates.States.Add(PointState.Locked);
        pointStates.States.Add(PointState.Locked);

        PointPosition pointPosition = new PointPosition();
        Vector2 curretPosition;
        List<Vector2> pointPositions = new List<Vector2>();

        for(int i = 0; i < pointStates.States.Count; i++)
        {
            curretPosition = pointPosition.GetNextPosition();
            pointPositions.Add(curretPosition);

            if(pointStates.States[i] == PointState.Locked)
                Instantiate(_pointLocked,transform).transform.position = curretPosition;
            else
            {
                EventMap point = Instantiate(_pointplayble,transform);
                point.transform.position = curretPosition;

                Sprite sprite = null;

                switch(pointStates.States[i])
                {
                    case PointState.Open:
                        sprite = _sprites[1];
                        break;
                    case PointState.OneStar:
                        sprite = _sprites[2];
                        break;
                    case PointState.TwoStar:
                        sprite = _sprites[3];
                        break;
                    case PointState.ThreeStar:
                        sprite = _sprites[4];
                        break;
                }

                point.SetParameters(sprite, i);

            }
        }
        for(int i = 0; i < pointPositions.Count - 1; i++)
        {
            curretPosition = (pointPositions[i] + pointPositions[i+1]) / 2;

            var path = Instantiate(_path, transform);
            path.transform.position = curretPosition;

            var vector = pointPositions[i+1] - pointPositions[i];
            var zRotate = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            path.transform.Rotate(0,0, zRotate);
        }
        OnGenerated.Invoke();
    } 
}
