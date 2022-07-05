using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LineMath
{
    public class Line
    {
        public MyVector3D A;
        public MyVector3D B;
        public MyVector3D v;
        
        public enum LINETYPE{ LINE, SEGMENT, RAY}

        public LINETYPE lineType;

        public Line(MyVector3D A, MyVector3D B, LINETYPE lineType)
        {
            this.lineType = lineType;
            this.A = A;
            this.B = B;

            v = B - A;
        }
        
        public Line(MyVector3D A, MyVector3D B)
        {
            this.lineType = lineType;
            this.A = A;
            this.B = B;

            v = B - A;

            lineType = LINETYPE.SEGMENT;
        }

        public MyVector3D Lerp(float t)
        {
            if (lineType == LINETYPE.SEGMENT)
            {
                t=Mathf.Clamp(t, 0, 1);
            }
            else if (lineType == LINETYPE.RAY && t < 0)
            {
                t = 0;
            }

            float xt = A.x + v.x * t;
            float yt = A.y + v.y * t;
            float zt = A.z + v.z * t;

            return new MyVector3D(xt, yt, zt);
        }

        public static bool IsLineSegIntersecting(Line l1, Line l2, out MyVector3D intersect)
        {
            intersect = new MyVector3D(0, 0, 0);
            if (MyMath.Dot(l1.v, l2.v.Perp()) == 0)
            {
                return false;
            }
            
            var cVector = l2.A - l1.A;
            
            var t = MyMath.Dot(cVector, l2.v.Perp()) / MyMath.Dot(l2.v.Perp(), l1.v);
            var s = MyMath.Dot(cVector, l1.v.Perp()) / MyMath.Dot(l1.v, l2.v.Perp());

            if (t < 0 || t > 1 || s < 0 || s > 1) return false;

            intersect = l1.A + l1.v * t;
            return true;
        }
        
        public float IntersectAt(Plane p)
        {
            var planeNormal = MyMath.Cross(p.v, p.u);
            var planeToLine = A - p.A;

            var t = -MyMath.Dot(planeNormal, planeToLine) / MyMath.Dot(v, planeNormal);


            return t;

        }

        public float IntersectAt(Line l)
        {
            var cVector = l.A - A;
            
            var t = MyMath.Dot(cVector, l.v.Perp()) / MyMath.Dot(l.v.Perp(), v);

            return t;

        }
        
        public void Draw(float width, Color color)
        {
            MyVector3D.DrawLine(A,B,width,color);
        }
    }

}

