using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Extensions
{
    public static Vector2 ToUnityVector2(this DevMath.Vector2 v)
    {
        return new Vector2(v.x, v.y);
    }
    public static Vector3 ToUnityVector3(this DevMath.Vector3 v)
    {
        return new Vector3(v.x, v.y, v.z);
    }

    public static DevMath.Vector2 ToDevMath(this Vector2 v)
    {
        return new DevMath.Vector2(v.x, v.y);
    }

    public static Matrix4x4 ToUnity(this DevMath.Matrix4x4 m)
    {
        throw new NotImplementedException();
    }

    public static DevMath.Matrix4x4 ToDevMath(this Matrix4x4 m)
    {
        throw new NotImplementedException();
    }
}
