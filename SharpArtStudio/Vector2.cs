using System;

namespace SharpArtStudio
{
    internal struct vec2
    {
        public vec2 (float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float x;
        public float y;

        public static vec2 operator +(vec2 a, vec2 b)  => new vec2( a.x + b.x, a.y + b.y);
        public static vec2 operator +(vec2 a, int b)   => new vec2( a.x + b, a.y + b);
        public static vec2 operator -(vec2 a, vec2 b)  => new vec2( a.x - b.x, a.y - b.y);
        public static vec2 operator -(vec2 a, int b)   => new vec2( a.x - b, a.y - b);
        public static vec2 operator -(vec2 a, float b) => new vec2( a.x - b, a.y - b);
        public static vec2 operator *(vec2 a, vec2 b)  => new vec2( a.x * b.x, a.y * b.y);
        public static vec2 operator *(vec2 a, float b) => new vec2( a.x * b, a.y * b);
        public static vec2 operator *(int a, vec2 b)   => new vec2( b.x * a, b.y * a );
        public static vec2 operator /(vec2 a, float b) => new vec2( a.x / b, a.y / b);
        public static vec2 operator /(vec2 a, int b)   => new vec2( a.x / b, a.y / b );

        public static float Dot(vec2 v, vec2 w)
        {
            return v.x * w.x + v.y * w.y;
        }

        public static float Length(vec2 v)
        {
            return (float)Math.Sqrt(Dot(v,v));
        }

        public static vec2 Sin(vec2 v)
        {
            return new vec2((float)Math.Sin(v.x), (float)Math.Sin(v.y));
        }

        public static float Distance(vec2 v1, vec2 v2)
        {
            return Length(v1 - v2);
        }

        public static vec2 Floor(vec2 v)
        {
            return new vec2((float)Math.Floor(v.x), (float)Math.Floor(v.y));
        }

        public static vec2 Fract(vec2 v)
        {
            return v - Floor(v);
        }

        public static vec2 N22(vec2 p)
        {
            vec3 a = vec3.Fract(new vec3(p.x, p.y, p.x) * new vec3(123.34f, 234.34f, 345.65f));
            a += vec3.Dot(a, a + 43.45f);
            return Fract(new vec2(a.x * a.y, a.y * a.z));
        }
    }
}
