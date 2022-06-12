using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane
{
    public MyVector3D A;
    public MyVector3D B;
    public MyVector3D C;

    public MyVector3D v;
    public MyVector3D u;
    
    public Plane(MyVector3D A, MyVector3D B, MyVector3D C)
    {
        this.A = A;
        this.B = B;
        this.C = C;

        v = B - A;
        u = C - A;
    }


    public MyVector3D Lerp(float t, float s)
    {
      //  t = Mathf.Clamp(t,0,1);
      //  s = Mathf.Clamp(s, 0, 1);
        
        return A + v * t + u * s;
    }
   
}
