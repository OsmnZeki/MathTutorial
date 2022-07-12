using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3D
{
    public float x;
    public float y;
    public float z;
    public float w;
    
    public MyVector3D(float x, float y, float z,float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public MyVector3D(Vector3 vector3, float w)
    {
        x = vector3.x;
        y = vector3.y;
        z = vector3.z;
        this.w = w;
    }
    

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

    public float[] AsFloats()
    {
        return new float[]
        {
            x, y, z, w
        };
    }
    
    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }
    
    public MyVector3D GetNormal()
    {
        float magnitude = MyMath.Distance(new MyVector3D(0, 0, 0), this);

        return new MyVector3D(x / magnitude,y / magnitude,z / magnitude);
    }

    public MyVector3D Perp()
    {
        return new MyVector3D(-y, x,0);
    }

    public static void DrawLine(MyVector3D startPoint, MyVector3D endPoint, float width, Color color)
    {
        GameObject line = new GameObject("Line_" + startPoint.ToVector().ToString() + "_" + endPoint.ToVector().ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = color;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,startPoint.ToVector());
        lineRenderer.SetPosition(1,endPoint.ToVector());
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
    
    public static MyVector3D operator -(MyVector3D vect1, MyVector3D vect2)
    {
        return new MyVector3D(vect1.x - vect2.x, vect1.y - vect2.y, vect1.z - vect2.z);
    }
    
    public static MyVector3D operator +(MyVector3D vect1, MyVector3D vect2)
    {
        return new MyVector3D(vect1.x + vect2.x, vect1.y + vect2.y, vect1.z + vect2.z);
    }

    public static MyVector3D operator *(MyVector3D vect1, float value)
    {
        return new MyVector3D(vect1.x * value, vect1.y * value, vect1.z * value);
    }
    
    public static MyVector3D operator /(MyVector3D vect1, float value)
    {
        return new MyVector3D(vect1.x / value, vect1.y / value, vect1.z / value);
    }
    
}

public static class Vector3Extension
{

    public static MyVector3D GetMyVector3D(this Vector3 vector3)
    {
        return new MyVector3D(vector3.x, vector3.y, vector3.z);
    }
    
}
