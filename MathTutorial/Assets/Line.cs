using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    public MyVector3D A;
    public MyVector3D B;
    public MyVector3D v;

    public Line(MyVector3D A, MyVector3D B)
    {
        this.A = A;
        this.B = B;

        v = B - A;

    }

    public MyVector3D GetPointAt(float t)
    {
        float xt = A.x + v.x * t;
        float yt = A.y + v.y * t;
        float zt = A.z + v.z * t;

        return new MyVector3D(xt, yt, zt);
    }
    
}
