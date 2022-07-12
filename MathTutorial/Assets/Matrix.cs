using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
   float[] values;
   int rows;
   int cols;

   public Matrix(int rows, int cols, float[] values)
   {
      this.rows = rows;
      this.cols = cols;
      this.values = new float[rows * cols];
      Array.Copy(values,this.values,rows*cols);
   }

   public MyVector3D AsVector()
   {
      if (rows == 4 && cols == 1)
      {
         return new MyVector3D(values[0], values[1], values[2], values[3]);
      }

      return null;
   }

   public MyVector3D GetColsByVector(int c)
   {
      if (cols != 4 || rows != 4)
      {
         return null;
      }

      MyVector3D result = new MyVector3D(
         values[c],
         values[cols+c],
         values[2*cols + c],
         values[3*cols +c]
      );

      return result;
   }

   public static Matrix TranslateMatrix(MyVector3D translateVector)
   {
      float[] values =
      {
         1, 0, 0, translateVector.x,
         0, 1, 0, translateVector.y,
         0, 0, 1, translateVector.z,
         0, 0, 0, 1,
      };
      Matrix translateMatrix = new Matrix(4, 4, values);
      return translateMatrix;
   }

   public static Matrix ScaleMatrix(MyVector3D scale)
   {
      float[] values =
      {
         scale.x, 0, 0, 0,
         0, scale.y, 0, 0,
         0, 0, scale.z, 0,
         0, 0, 0, 1,
      };
      Matrix scaleMatrix = new Matrix(4, 4, values);
      return scaleMatrix;
   }

   public static Matrix EulerRotationMatrix(MyVector3D angles, bool clockWiseX, bool clockWiseY,
      bool clockWiseZ)
   {
      if (clockWiseX)
      {
         angles.x = 2 * Mathf.PI - angles.x;
      }
      if (clockWiseY)
      {
         angles.y = 2 * Mathf.PI - angles.y;
      }
      if (clockWiseZ)
      {
         angles.z = 2 * Mathf.PI - angles.z;
      }

      float[] xRollValues =
      {
         1, 0, 0, 0,
         0, Mathf.Cos(angles.x), -Mathf.Sin(angles.x), 0,
         0, Mathf.Sin(angles.x), Mathf.Cos(angles.x), 0,
         0, 0, 0, 1,
      };
        
      float[] yRollValues =
      {
         Mathf.Cos(angles.y), 0, Mathf.Sin(angles.y), 0,
         0, 1, 0, 0,
         -Mathf.Sin(angles.y), 0, Mathf.Cos(angles.y), 0,
         0, 0, 0, 1,
      };
        
      float[] zRollValues =
      {
         Mathf.Cos(angles.z), -Mathf.Sin(angles.z), 0, 0,
         Mathf.Sin(angles.z), Mathf.Cos(angles.z), 0, 0,
         0, 0, 1, 0,
         0, 0, 0, 1,
      };

      Matrix xRollMatrix = new Matrix(4, 4, xRollValues);
      Matrix yRollMatrix = new Matrix(4, 4, yRollValues);
      Matrix zRollMatrix = new Matrix(4, 4, zRollValues);

      Matrix rotatedMatrix = zRollMatrix * yRollMatrix * xRollMatrix;
      return rotatedMatrix;
   }

   public override string ToString()
   {
      string matrix = "";

      for (int r = 0; r < rows; r++)
      {
         for (int c = 0; c < cols; c++)
         {
            matrix += values[r * cols + c] + " ";

         }

         matrix += "\n";
      }
      
      return matrix;
   }

   public static Matrix operator +(Matrix m1, Matrix m2)
   {
      if (m1.rows != m2.rows || m1.cols != m2.cols) return null;

      Matrix result = new Matrix(m1.rows, m1.cols, m1.values);
      var size = m1.rows * m1.cols;
      for (int i = 0; i < size; i++)
      {
         result.values[i] += m2.values[i];
      }

      return result;
   }

   public static Matrix operator *(Matrix m1, Matrix m2)
   {
      if (m1.cols != m2.rows) return null;

      float[] resultValues = new float[m1.rows * m2.cols];
      for (int i = 0; i < m1.rows; i++)
      {
         for (int j = 0; j < m2.cols; j++)
         {
            for (int k = 0; k < m1.cols; k++)
            {
               resultValues[i * m2.cols + j] += m1.values[i * m1.cols + k] *
                                                m2.values[k * m2.cols + j];
            }
         }
      }

      Matrix resultMatrix = new Matrix(m1.rows, m2.cols, resultValues);
      return resultMatrix;
   }
   
   public static Matrix operator *(Matrix m1, MyVector3D vector)
   {
      Matrix vectorMatrix = new Matrix(4, 1, vector.AsFloats());
      return m1*vectorMatrix;
   }
}
