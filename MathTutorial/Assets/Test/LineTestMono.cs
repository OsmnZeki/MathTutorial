using System;
using System.Collections;
using System.Collections.Generic;
using LineMath;
using UnityEngine;

public class LineTestMono : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public Transform sphere;
    
    public Line line;

    void Awake()
    {
        line = new Line(startPoint.position.GetMyVector3D(), endPoint.position.GetMyVector3D(), Line.LINETYPE.SEGMENT);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sphere.position = MyMath.Lerp(startPoint.position.GetMyVector3D(), endPoint.position.GetMyVector3D(),
            Time.time * .1f).ToVector();
    }
}
