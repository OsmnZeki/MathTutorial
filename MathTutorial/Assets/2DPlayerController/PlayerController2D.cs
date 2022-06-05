using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public Transform targetTransform;
    public float speed;
    public float rotationSpeed;

    float stoppingDistance = 0.001f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float translation = 0;
        float rotation = 0;
        if (Input.GetKey(KeyCode.W))
        {
            translation = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            translation = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotation = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation = 1;
        }


        translation *= speed * Time.deltaTime;
        rotation *= rotationSpeed * Time.deltaTime;

        transform.transform.position =
            MyMath.Translate(transform.position.GetMyVector3D(),transform.up.GetMyVector3D(), new MyVector3D(0, translation, 0)).ToVector();
        
        transform.up = MyMath.Rotate(transform.up.GetMyVector3D(), rotation, true).ToVector();

    }
}