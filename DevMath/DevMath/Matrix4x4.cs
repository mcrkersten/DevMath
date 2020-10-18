using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Matrix4x4
    {
        public float[][] m = new float[4][] { new float[4], new float[4], new float[4], new float[4] };

        public Matrix4x4()
        {
            
        }

        public static Matrix4x4 Identity
        {
            get { throw new NotImplementedException(); }
        }

        public float Determinant
        {
            get { throw new NotImplementedException(); }
        }

        public Matrix4x4 Inverse
        {
            get { throw new NotImplementedException(); }
        }

        public static Matrix4x4 Translate(Vector3 translation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 Rotate(Vector3 rotation)
        {
            //Er zijn 2 manieren om deze te berekenen
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateX(float rotation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateY(float rotation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateZ(float rotation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 Scale(Vector3 scale)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
            throw new NotImplementedException();
        }
    }
}
