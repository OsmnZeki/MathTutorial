using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTestMono : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;

    
    public Plane plane;
    
    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(A.position.GetMyVector3D(), B.position.GetMyVector3D(),
            C.position.GetMyVector3D());
        
        for (float s = -5; s < 5; s += .1f)
        {
            for (float t = -5; t < 5; t += .1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(t, s).ToVector();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
