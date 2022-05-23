using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PointStates 
{
     public List<PointState> States = new List<PointState>();
}

[System.Serializable]
public enum PointState
{
    Locked,
    Open,
    OneStar,
    TwoStar,
    ThreeStar
}