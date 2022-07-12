using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTestMono : MonoBehaviour
{
    public List<MyTransform> myTransforms;
    public List<GameObject> meshes;

    public GameObject testObj;
    
    [NonSerialized]public Vector3[] cubeVertexLocals =
    {
        new Vector3(-.5f, -.5f, -.5f),
        new Vector3(-.5f,-.5f,.5f),
        new Vector3(.5f,-.5f,.5f),
        new Vector3(.5f,-.5f,-.5f),
        new Vector3(-.5f, .5f, -.5f),
        new Vector3(-.5f,.5f,.5f),
        new Vector3(.5f,.5f,.5f),
        new Vector3(.5f,.5f,-.5f),
    };
    
    void Start()
    {
        var unityLocalToWorld = testObj.transform.localToWorldMatrix;
        Debug.Log(unityLocalToWorld);
        
        for (int i = 0; i < myTransforms.Count; i++)
        {
            var pivot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pivot.transform.localScale = Vector3.one * .1f;
            meshes.Add(pivot);

            if (i != 0)
            {
                myTransforms[i].parent = myTransforms[i - 1];
            }

            foreach (var v in cubeVertexLocals)
            {
                var vertex = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                vertex.transform.localScale = Vector3.one * .2f;
                
                
                var localToWorldMatrix = myTransforms[i].LocalToWorldMatrix();
                vertex.transform.position = (localToWorldMatrix * new MyVector3D(v,1)).AsVector().ToVector();
                
                myTransforms[i].meshVertices.Add(vertex.transform);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < myTransforms.Count; i++)
        {
            var localToWorldMatrix = myTransforms[i].LocalToWorldMatrix();
            meshes[i].transform.position = localToWorldMatrix.GetColsByVector(3).ToVector();

            for (int v = 0; v < myTransforms[i].meshVertices.Count; v++)
            {
                var vertex = myTransforms[i].meshVertices[v];
                vertex.position = (localToWorldMatrix * new MyVector3D(cubeVertexLocals[v],1)).AsVector().ToVector();
            }

        }
    }
}
