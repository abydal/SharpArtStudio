using System;

namespace SharpArtStudio
{
    internal struct vec3
    {
        public vec3 (float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float x;
        public float y;
        public float z;

        public static vec3 operator +(vec3 a, vec3 b)  => new vec3(a.x + b.x, a.y + b.y, a.z + b.z );
        public static vec3 operator +(vec3 a, float b) => new vec3(a.x + b, a.y + b, a.z + b );
        public static vec3 operator -(vec3 a, vec3 b)  => new vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static vec3 operator *(vec3 a, vec3 b)  => new vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        //public static vec3 operator *(vec3 a, float b) => new vec3(a.x * b, a.y * b, a.z * b);
        //public static vec3 operator *(vec3 a, int b)   => new vec3(a.x * b, a.y * b, a.z * b);
        public static vec3 operator /(vec3 a, float b) => new vec3(a.x / b, a.y / b, a.z / b);
        public static vec3 operator /(vec3 a, int b)   => new vec3(a.x / b, a.y / b, a.z / b);

        public static float Dot(vec3 v, vec3 w)
        {
            return v.x * w.x + v.y * w.y + v.z * w.z;
        }

        public static float Length(vec3 v)
        {
            return (float)Math.Sqrt(Dot(v,v));
        }

        public static vec3 Sin(vec3 v)
        {
            return new vec3((float)Math.Sin(v.x), (float)Math.Sin(v.y), (float)Math.Sin(v.z));
        }

        public static float Distance(vec3 v1, vec3 v2)
        {
            return Length(v1 - v2);
        }

        public static vec3 Floor(vec3 v)
        {
            return new vec3((float)Math.Floor(v.x), (float)Math.Floor(v.y),(float)Math.Floor(v.z));
        }

        public static vec3 Fract(vec3 v)
        {
            return v - Floor(v);
        }
    }
}
