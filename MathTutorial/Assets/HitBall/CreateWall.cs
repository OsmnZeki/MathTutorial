using System.Collections;
using System.Collections.Generic;
using LineMath;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    Line wall;
    Line ballPath;
    public GameObject ball;

    float intersectT;

    float currenT=0;
    // Start is called before the first frame update
    void Start()
    {
        wall = new Line(new MyVector3D(5, -2, 0), new MyVector3D(0, 5, 0));
        wall.Draw(1, Color.blue);

        ballPath = new Line(new MyVector3D(-6, 0, 0), new MyVector3D(100, 0, 0));
        ballPath.Draw(0.1f, Color.yellow);

        ball.transform.position = ballPath.Lerp(0).ToVector();
        intersectT = ballPath.IntersectAt(wall);
    }

    // Update is called once per frame
    void Update()
    {
        currenT = Mathf.MoveTowards(currenT, intersectT, .1f * Time.deltaTime);

        ball.transform.position = ballPath.Lerp(currenT).ToVector();
    }
}
