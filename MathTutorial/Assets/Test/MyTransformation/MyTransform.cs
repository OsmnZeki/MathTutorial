using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MyTransform
{
    public Vector3 localPosition;
    public Vector3 localRotation;
    public Vector3 localScale;

    public MyTransform parent;

    public List<Transform> meshVertices = new List<Transform>();
    //public Matrix localToWorldMatrix;

    public Matrix GetTRSMatrix()
    {
        var parentTransMatrix = Matrix.TranslateMatrix(new MyVector3D(localPosition, 0));
        var parentScaleMatrix = Matrix.ScaleMatrix(new MyVector3D(localScale, 0));
        var parentRotationMatrix = Matrix.EulerRotationMatrix(new MyVector3D((localRotation) * Mathf.Deg2Rad, 0),false,false,false);
        
        return parentTransMatrix * parentRotationMatrix * parentScaleMatrix;
    }

    public Matrix LocalToWorldMatrix()
    {
        if (parent == null)
        {
            return GetWorldTRSMatrix() * GetTRSMatrix();
        }
        else
        {
            return parent.LocalToWorldMatrix() * GetTRSMatrix();
        }
    }

    public static Matrix GetWorldTRSMatrix()
    {
        var parentTransMatrix = Matrix.TranslateMatrix(new MyVector3D(Vector3.zero, 0));
        var parentScaleMatrix = Matrix.ScaleMatrix(new MyVector3D(Vector3.one, 0));
        var parentRotationMatrix = Matrix.EulerRotationMatrix(new MyVector3D((Vector3.zero) * Mathf.Deg2Rad, 0),false,false,false);
        
        return parentTransMatrix * parentRotationMatrix * parentScaleMatrix;
    }
}
