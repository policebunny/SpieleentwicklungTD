using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] points;


public void AddPoint(Transform point) {
    List<Transform> newPoints = new List<Transform>(points) { point };
    points = newPoints.ToArray();
}
}