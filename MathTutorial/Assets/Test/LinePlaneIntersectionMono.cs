using System.Collections;
using System.Collections.Generic;
using LineMath;
using UnityEngine;

public class LinePlaneIntersectionMono : MonoBehaviour
{
    public Transform planeA;
    public Transform planeB;
    public Transform planeC;
    
    public Transform lineA;
    public Transform lineB;
    
    void Start()
    {
        var plane = new Plane(planeA.position.GetMyVector3D(), planeB.position.GetMyVector3D(),
            planeC.position.GetMyVector3D());
        
        for (float s = 0; s < 1; s += .1f)
        {
            for (float t = 0; t < 1; t += .1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(t, s).ToVector();
            }
        }
        
        var L1 = new Line(lineA.transform.position.GetMyVector3D(), lineB.transform.position.GetMyVector3D());
        L1.Draw(1,Color.green);

        var intersectT = L1.IntersectAt(plane);
        
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = L1.Lerp(intersectT).ToVector();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
