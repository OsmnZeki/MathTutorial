using System;
using System.Collections;
using System.Collections.Generic;
using LineMath;
using UnityEngine;

public class LineCreaterMono : MonoBehaviour
{
    public Line L1;
    public Line L2;


    GameObject sphere;
    void Start()
    {
        L1 = new Line(new MyVector3D(-2, 0, 0), new MyVector3D(4, 3, 0),Line.LINETYPE.SEGMENT);
        L1.Draw(1,Color.green);
        L2 = new Line(new MyVector3D(0, 10, 0), new MyVector3D(0, 5, 0),Line.LINETYPE.SEGMENT);
        L2.Draw(1,Color.red);
        
        if (Line.IsLineSegIntersecting(L1, L2, out var intersect))
        {
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = intersect.ToVector();
        }
    }

    void Update()
    {
        
    }
}
