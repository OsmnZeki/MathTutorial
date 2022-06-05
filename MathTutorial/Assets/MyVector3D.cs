using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3D
{
    public float x;
    public float y;
    public float z;

    public MyVector3D(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public MyVector3D(Vector3 vect)
    {
        x = vect.x;
        y = vect.y;
        z = vect.z;
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }

    public static MyVector3D operator -(MyVector3D vect1, MyVector3D vect2)
    {
        return new MyVector3D(vect1.x - vect2.x, vect1.y - vect2.y, vect1.z - vect2.z);
    }
    
    public static MyVector3D operator +(MyVector3D vect1, MyVector3D vect2)
    {
        return new MyVector3D(vect1.x + vect2.x, vect1.y + vect2.y, vect1.z + vect2.z);
    }
}

public static class Vector3Extension
{

    public static MyVector3D GetMyVector3D(this Vector3 vector3)
    {
        return new MyVector3D(vector3.x, vector3.y, vector3.z);
    }
    
}
