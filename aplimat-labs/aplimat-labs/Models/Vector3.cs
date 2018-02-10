using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs
{
    public class Vector3
    {
        public float x, y, z;
        
        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vector3(double _x, double _y, double _z)
        {
            x = (float)_x;
            y = (float)_y;
            z = (float)_z;
        }

        public static Vector3 operator +(Vector3 rhs, Vector3 lhs) //rhs = right hand side 
        {
            return new Vector3(rhs.x + lhs.x,
                rhs.y + lhs.y,
                rhs.z + lhs.z);
        }

        public static Vector3 operator -(Vector3 rhs, Vector3 lhs) //rhs = right hand side 
        {
            return new Vector3(rhs.x - lhs.x,
                rhs.y - lhs.y,
                rhs.z - lhs.z);
        }

        public static Vector3 operator *(Vector3 left, float scalar)
        {
            return new Vector3(left.x * scalar,
                left.y * scalar,
                left.z * scalar);
        }

        public static Vector3 operator /(Vector3 left, float scalar)
        {
            return new Vector3(left.x / scalar,
                left.y / scalar,
                left.z / scalar);
        }

        public float GetMagnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }
    }
}
