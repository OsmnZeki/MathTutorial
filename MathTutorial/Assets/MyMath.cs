using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMath
{
    public static MyVector3D GetNormal(MyVector3D vect)
    {
        float length = Distance(vect, new MyVector3D(0, 0, 0));

        return new MyVector3D(vect.x / length, vect.y / length, vect.z / length);
    }

    public static float Distance(MyVector3D vect1, MyVector3D vect2)
    {
        float squaredDistance = Square(vect1.x - vect2.x) +
                                Square(vect1.y - vect2.y) +
                                Square(vect1.z - vect2.z);

        float squaredRootDist = Mathf.Sqrt(squaredDistance);

        return squaredRootDist;
    }

    public static float Square(float value)
    {
        return value * value;
    }

    public static float Dot(MyVector3D vect1, MyVector3D vect2)
    {
        return vect1.x * vect2.x + vect1.y * vect2.y + vect1.z * vect2.z;
    }

    public static MyVector3D Cross(MyVector3D vect1, MyVector3D vect2)
    {
        float xMul = vect1.y * vect2.z - vect1.z * vect2.y;
        float yMul = vect1.z * vect2.x - vect1.x * vect2.z;
        float zMul = vect1.x * vect2.y - vect1.y * vect2.x;
        return new MyVector3D(xMul, yMul, zMul);
    }

    public static float Angle(MyVector3D vect1, MyVector3D vect2)
    {
        var cosA = Dot(vect1, vect2) / 
                        Distance(vect1, new MyVector3D(0,0,0)) *Distance(vect2, new MyVector3D(0,0,0));
        return Mathf.Acos(cosA);
    }

    public static MyVector3D Rotate(MyVector3D vect, float radiansDegree, bool clockwise)
    {
        if (clockwise)
        {
            radiansDegree = 2 * Mathf.PI - radiansDegree;
        }
        
        float newX = vect.x * Mathf.Cos(radiansDegree) - vect.y * Mathf.Sin(radiansDegree);
        float newY = vect.x * Mathf.Sin(radiansDegree) + vect.y * Mathf.Cos(radiansDegree);

        return new MyVector3D(newX, newY, vect.z);
    }

    public static MyVector3D Translate(MyVector3D position, MyVector3D forward,MyVector3D translateVector)
    {
        if (Distance(new MyVector3D(0, 0, 0), translateVector) <= 0) return position;
        float angle = Angle(translateVector, forward);
        float worldAngle = Angle(translateVector, new MyVector3D(0, 1, 0));
        bool clockwise = MyMath.Cross(translateVector, forward).z < 0;
        translateVector = Rotate(translateVector, angle+worldAngle, clockwise);
        
        return position + translateVector;
    }

    public static MyVector3D LookAt2D(MyVector3D position, MyVector3D forward, MyVector3D target)
    {
        var distanceVector = target - position;
        var radians = Angle(distanceVector, forward);
        
        bool clockwise = MyMath.Cross(forward, distanceVector).z < 0;

        var rotatedVect = MyMath.Rotate(forward, radians, clockwise);
        return rotatedVect;
    }
}
