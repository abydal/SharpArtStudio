using System;
using System.Threading.Tasks;

namespace SharpArtStudio
{
    internal static class NoiseFunctions
    {
        public static byte[] NormalizeToRgb2D(float[][] grayImage, int width, int height)
        {
            byte[] buffer = new byte[width * height * 4];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    int position = (i * width + j) * 4;

                    byte value = (byte)(grayImage[i][j] * 255);

                    buffer[position] = value;
                    buffer[position + 1] = value;
                    buffer[position + 2] = value;
                    buffer[position + 3] = 255;
                }
            return buffer;
        }

        public static byte[] NormalizeToRgb2D(float[,] grayImage, int width, int height)
        {
            byte[] buffer = new byte[width * height * 4];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    int position = (i * width + j) * 4;

                    byte value = (byte)(grayImage[i,j] * 255);

                    buffer[position] = value;
                    buffer[position + 1] = value;
                    buffer[position + 2] = value;
                    buffer[position + 3] = 255;
                }
            return buffer;
        }

        public static byte[] NormalizeToRgb1D(float[] grayImage, int width, int height, int offset, float scale)
        {
            byte[] buffer = new byte[width * height * 4];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    int position = (i * width + j) * 4;

                    int value = (int)(grayImage[j] * scale);

                    if (height - i < value + offset)
                    {
                        //black
                        buffer[position] = 0;
                        buffer[position + 1] = 0;
                        buffer[position + 2] = 0;
                        buffer[position + 3] = 255;
                    }
                    else
                    {
                        //white
                        buffer[position] = 255;
                        buffer[position + 1] = 255;
                        buffer[position + 2] = 255;
                        buffer[position + 3] = 255;
                    }

                }
            return buffer;
        }

        public static float[] Noise1D(int size)
        {
            Random rand = new Random(1);
            var noise = new float[size];
            for (int i = 0; i < size; i++)
                noise[i] = (float)rand.NextDouble();

            return noise;
        }

        public static float[][] Noise2D(int width, int height)
        {
            Random rand = new Random(1);

            var noise = new float[width][];
            for (int i = 0; i < width; i++)
            {
                noise[i] = new float[height];
                for (int j = 0; j < height; j++)
                    noise[i][j] = (float)rand.NextDouble();
            }

            return noise;
        }

        public static float[] PerlinNoise1D(float[] noise, int width, int octaves, float fBias)
        {
            float[] output = new float[width];

            for(int x = 0; x < width; x++)
            {
                float fNoise = 0.0f;
                float fScale = 1.0f;
                float fScaleAccumulate = 0;

                for(int o = 0; o < octaves; o++)
                {
                    int nPitch = width >> o;
                    int nSample1 = (x / nPitch) * nPitch;
                    int nSample2 = (nSample1 + nPitch) % width;

                    float fBlend = (x - nSample1) / (float)nPitch;
                    float fSample = (1.0f - fBlend) * noise[nSample1] + fBlend * noise[nSample2];
                    fNoise += fSample * fScale;
                    fScaleAccumulate += fScale;
                    fScale = fScale / fBias;
                }
                output[x] = fNoise / fScaleAccumulate; 
            }
            return output;
        }

        public static float Interpolate(float x0, float x1, float alpha)
        {
            return x0 * (1 - alpha) + alpha * x1;
        }

        public static float[][] GeneratSmoothNoise(float[][] noise, int width, int height, int octaves)
        {
            float[][] smoothNoise = new float[width][];
            int samplePeriod = 1 << octaves;
            float sampleFrequency = 1.0f / samplePeriod;

            for (int i = 0; i < width; i++)
            {
                //calculate the horizontal sampling indices
                int sample_i0 = (i / samplePeriod) * samplePeriod;
                int sample_i1 = (sample_i0 + samplePeriod) % width; //wrap around
                float horizontal_blend = (i - sample_i0) * sampleFrequency;

                smoothNoise[i] = new float[height];

                for (int j = 0; j < height; j++)
                {

                    //calculate the vertical sampling indices
                    int sample_j0 = (j / samplePeriod) * samplePeriod;
                    int sample_j1 = (sample_j0 + samplePeriod) % height; //wrap around
                    float vertical_blend = (j - sample_j0) * sampleFrequency;

                    //blend the top two corners
                    float top = Interpolate(noise[sample_i0][sample_j0],
                        noise[sample_i1][sample_j0], horizontal_blend);

                    //blend the bottom two corners
                    float bottom = Interpolate(noise[sample_i0][sample_j1],
                        noise[sample_i1][sample_j1], horizontal_blend);

                    //final blend
                    smoothNoise[i][j] = Interpolate(top, bottom, vertical_blend);
                }
            }

            return smoothNoise;
        }

        public static float[][] PerlinNoise2D(float[][] noise, int width, int height, int octaves, float fBias)
        {

            float[][] output = new float[width][];

            for (int x = 0; x < width; x++)
            {
                output[x] = new float[height];
                for (int y = 0; y < height; y++)
                {
                    float fNoise = 0.0f;
                    float fScale = 2.0f;
                    float fScaleAccumulate = 0;

                    for (int o = 0; o < octaves; o++)
                    {
                        int nPitch = width >> o;
                        int nSampleX1 = (x / nPitch) * nPitch;
                        int nSampleY1 = (y / nPitch) * nPitch;

                        int nSampleX2 = (nSampleX1 + nPitch) % width;
                        int nSampleY2 = (nSampleY1 + nPitch) % height;

                        float fBlendX = (x - nSampleX1) / (float)nPitch;
                        float fBlendY = (y - nSampleY1) / (float)nPitch;

                        float fSampleT = (1.0f - fBlendX) * noise[nSampleX1][nSampleY1] + fBlendX * noise[nSampleX2][nSampleY1];
                        float fSampleB = (1.0f - fBlendX) * noise[nSampleX1][nSampleY2] + fBlendX * noise[nSampleX2][nSampleY2];

                        fNoise += (fBlendY * (fSampleB - fSampleT) + fSampleT) * fScale;
                        fScaleAccumulate += fScale;
                        fScale = fScale / fBias;
                    }
                    output[x][y] = fNoise / fScaleAccumulate;
                }
            }
            return output;
        }

        internal static byte[] DrawVoronoi(vec2[] points, int width, int height)
        {
            byte[] buffer = new byte[width * height * 4];
            var t = DateTime.Now.Second;
            var maxMinDist = 0.0f;
            var minMinDist = 0.0f;
            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    vec3 color = new vec3();
                    var minDist = 100.0f;
                    vec2 uv = (2*new vec2(x, y) - new vec2(width,height))/height;
                          
                    if (false)
                    {
                        float cellIndex = 0.0f;
                        float m = 0;
                        for (int i = 0; i < points.Length; i++)
                        {
                            vec2 n = points[i]*2 - 1 ;
                            vec2 p = vec2.Sin(n*t);

                            float d = vec2.Length(uv - p);
                            m += SmoothStep(0.02f, 0.01f, d);

                            if (d < minDist)
                            {
                                cellIndex = i;
                                minDist = d;
                            }
                        }
                        color = new vec3(minDist, minDist, minDist);
                    }
                    else
                    {
                        uv *= points.Length;
                        vec2 gv = vec2.Fract(uv) - .5f;
                        vec2 id = vec2.Floor(uv);
                        
                        for(float i = -1.0f; i <= 1; i++)
                            for (float j = -1.0f; j <= 1; j++)
                            {
                                vec2 offset = new vec2(i, j);

                                vec2 n = vec2.N22(id + offset);
                                vec2 p = offset + vec2.Sin(n*t)*.25f;
                                float length = vec2.Length(gv - p);

                                if (length < minDist)
                                {
                                    minDist = length;
                                }
                            }

                        color = new vec3(1.0f-(minDist*0.3f), minDist, minDist);
                    }

                    int position = (y * width + x) * 4;

                    int red, green, blue;

                    Color.HsvToRgb(90*minDist, minDist < 0.7 ? 1 : 0.5, 1, out red, out green, out blue);

                    buffer[position] = (byte)(blue); //blue
                    buffer[position + 1] = (byte)(green); //green
                    buffer[position + 2] = (byte)(red); // red
                    buffer[position + 3] = 255;
                }
            });
            return buffer;
        }

        internal static vec2[]RandomPoints(int count)
        {
            Random rand = new Random(1);
            var noise = new vec2[count] ;
            for (int i = 0; i < count; i++)
                noise[i] = new vec2((float)rand.NextDouble(),(float)rand.NextDouble());

            return noise;
        }

        internal static float SmoothStep(float edge0, float edge1, float x)
        {
            // Scale, bias and saturate x to 0..1 range
            x = Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
            // Evaluate polynomial
            return x * x * (3 - 2 * x);
        }

        internal static float Clamp(float x, float lowerlimit, float upperlimit)
        {
            if (x < lowerlimit)
                x = lowerlimit;
            if (x > upperlimit)
                x = upperlimit;
            return x;
        }
    }
}
