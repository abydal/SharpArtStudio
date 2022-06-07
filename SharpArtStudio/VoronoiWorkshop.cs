using System;

namespace SharpArtStudio
{
    class VoronoiWorkshop
    {
        internal struct vec2
        {
            public vec2(int x, int y) { this.x = x; this.y = y; }
            public int x;
            public int y;
            public static vec2 operator -(vec2 a, vec2 b) => new vec2(a.x - b.x, a.y - b.y);

            public static vec2 Null = new vec2(0, 0);
        }

        const float lineThickness = 3.0f;

        internal static vec2[,] GetPoints(int x, int y,  float cellWidth, float cellHeight, float jitter)
        {

            Random r = new Random();
            vec2[,] points = new vec2[x,y];
            for(int xd = 0; xd < x; xd++ )
            for(int yd = 0; yd < y; yd++)
                {
                    points[xd, yd] = new vec2((int)(xd * cellWidth + (int)(r.NextDouble() * cellWidth*jitter)), (int)(yd * cellHeight + (int)(r.NextDouble() * cellHeight*jitter)));
                }

            return points;
        }

        public static float[,] DrawVoronoi(int pixelWidth, int pixelHeight, int horizontalCells, int verticalCells, float jitter, bool drawPoints) 
        {
            float cellWidth = pixelWidth / horizontalCells;
            float cellHeight = pixelHeight / verticalCells;

            vec2[,] points = GetPoints(horizontalCells, verticalCells, cellWidth, cellHeight, jitter);

            float[,] voronoi = new float[pixelWidth, pixelHeight];

            for(int x = 0; x < pixelWidth; x++)
            for(int y = 0; y < pixelHeight; y++)
            {
                voronoi[x, y] = 1;
                (vec2 p1, vec2 p2) closestPoints = GetTwoClosestPoints(new vec2(x, y), points, cellWidth, cellHeight);

                if(PixelIsInMiddle(new vec2(x, y), closestPoints))
                {
                    voronoi[x, y] = 0;
                }
            }

            /*if(drawPoints)
                foreach(vec2 p in points)
                {
                    if (p.x == pixelWidth || p.x == 0 || p.y == pixelHeight || p.y == 0)
                        continue;

                    voronoi[p.x, p.y] = 0;
                    voronoi[p.x, p.y-1] = 0;
                    voronoi[p.x, p.y+1] = 0;
                    voronoi[p.x-1, p.y] = 0;
                    voronoi[p.x+1, p.y] = 0;
                }
            */
            return voronoi;
        }

        private static bool PixelIsInMiddle(vec2 pixel, (vec2 p1, vec2 p2) closestPoints)
        {
            var d1 = Math.Abs(Distance(pixel, closestPoints.p1));
            var d2 = Math.Abs(Distance(pixel, closestPoints.p2));
            var diff = Math.Abs(d1 - d2);
            return  diff  < lineThickness;
        }

        struct TwoClosestPoints
        {
            public TwoClosestPoints(vec2 pixel)
            {
                this.pixel = pixel;
                p1 = vec2.Null;
                p2 = vec2.Null;
                d1 = -1;
                d2 = -2;
            }
            private vec2 pixel;
            public vec2 p1, p2;
            public float d1, d2;

            public void CheckNewPoint(vec2 np)
            {
                float nd = Math.Abs(Distance(pixel, np));

                if (nd < d1 || d1 == -1)
                {
                    d2 = d1; d1 = nd;
                    p2 = p1; p1 = np;
                    return;
                }

                if (nd < d2 || d2 == -1)
                {
                    d2 = nd;
                    p2 = np;
                }
            }
        }

        private static (vec2 u, vec2 v) GetTwoClosestPoints(vec2 pixel, vec2[,] points, float cellWidth, float cellHeight)
        {
            int currentAreaX = (int)(pixel.x / cellWidth);
            int currentAreaY = (int)(pixel.y / cellHeight);

            TwoClosestPoints twoClosestPoints = new TwoClosestPoints(pixel);

            for(int x = -1; x < 2; x++)
            for(int y = -1; y < 2; y++)
                {
                    if (currentAreaX + x < 0 || currentAreaX + x >= points.GetLength(0))
                        continue;
                    if (currentAreaY + y < 0 || currentAreaY + y >= points.GetLength(1))
                        continue;

                    twoClosestPoints.CheckNewPoint(points[currentAreaX + x, currentAreaY + y]);
                }

            return (twoClosestPoints.p1, twoClosestPoints.p2);
        }

        private static float Distance(vec2 v1, vec2 v2)
        {
            return Length(v1 - v2);
        }

        private static float Length(vec2 v)
        {
            return (float)Math.Sqrt(Dot(v, v));
        }

        private static float Dot(vec2 v, vec2 w)
        {
            return v.x * w.x + v.y * w.y;
        }

    }
}
