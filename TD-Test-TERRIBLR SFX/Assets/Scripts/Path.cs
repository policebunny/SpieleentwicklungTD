using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();


public void AddPoint(Transform point) {
    points.Add(point);
}
}