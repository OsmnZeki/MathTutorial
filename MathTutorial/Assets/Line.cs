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
    
    }

}

