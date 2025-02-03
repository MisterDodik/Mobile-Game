using System.Collections.Generic;
using UnityEngine;

public class gradientColor : MonoBehaviour
{
    // Width and height of the texture in pixels.
    public int pixWidth;
    public int pixHeight;

    // The origin of the sampled area in the plane.
    public float xOrg;
    public float yOrg;

    // The number of cycles of the basic noise pattern that are repeated
    // over the width and height of the texture.
    public float scale = 1.0F;

    private Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;

    List<Surface> surfaces;

    float yOffset = 0;
    public float offsetIncrement = 0.1f;
    void Start()
    {
        surfaces = new List<Surface>()
        {
            //{ new Surface(0, 0.25f, new Color(0, 1, 1), new Color(0, 1, 0.5f)) },
            //{ new Surface(0.25f, 0.5f, new Color(0, 1, 0.5f), new Color(0, 1, 0))},
            //{ new Surface(0.5f, 0.75f, new Color(0, 1, 0), new Color(1, 1, 0))},
            //{ new Surface(0.75f, 1f, new Color(1, 1, 0), new Color(1, 0, 0.2f))},

            //{ new Surface(0, 0.2f, new Color(1, 0.2f, 0.2f), new Color(1, 0.2f, 1)) },
            //{ new Surface(0.2f, 0.4f, new Color(1, 0.2f, 1), new Color(0.2f, 0.2f, 1))},
            //{ new Surface(0.4f, 0.6f, new Color(0.2f, 0.2f, 1), new Color(0.2f, 1f, 1))},
            //{ new Surface(0.6f, 0.8f, new Color(0.2f, 1f, 1), new Color(0.2f, 1f, 0.2f))},
            //{ new Surface(0.8f, 1f, new Color(0.2f, 1f, 1), new Color(1f, 1f, 0.2f))},

            { new Surface(0, 0.4f, new Color(1, 0.5f, 0.5f), new Color(1, 0, 0)) },
            { new Surface(0.4f, 0.7f, new Color(0.5f, 1, 1), new Color(0, 1, 1))},
            { new Surface(0.7f, 1f, new Color(1, 1, 0.5f), new Color(1, 1, 0))},
        };



        rend = GetComponent<MeshRenderer>();

        Camera mainCamera = Camera.main;

        if (rend != null && mainCamera != null)
        {
            // Get the bounds of the object in world space
            Bounds bounds = rend.bounds;

            // Convert the corners of the bounds to screen space
            Vector3 minScreenPoint = mainCamera.WorldToScreenPoint(bounds.min);
            Vector3 maxScreenPoint = mainCamera.WorldToScreenPoint(bounds.max);

            // Calculate width and height in pixels
            pixWidth = Mathf.Abs((int)(maxScreenPoint.x - minScreenPoint.x)) * (int)transform.localScale.x;
            pixHeight = Mathf.Abs((int)(maxScreenPoint.y - minScreenPoint.y))*(int)transform.localScale.y;

        }
        print((pixWidth, pixHeight));
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];

        rend.materials[0].mainTexture = noiseTex;
        //rend.material.mainTexture = noiseTex;

        CalcNoise();
    }


    //boje idu redom R G B. Prvo R od 0.2 do 1, pa onda G od 0.2 do 1, pa onda B od 1 do 0.2, pa onda R od 1 do 0.2 itd.
    //znaci idu redom R G B, ako je vrijednost 0.2 ide do 1 pa ide sljedeci, a ako je 1 onda ide do 0.2 pa onda sljedeci nastupa
    float r = 0.2f;
    float g = 0.2f;
    float b = 1f;


    void CalcNoise()
    {
        // For each pixel in the texture...
        for (float y = 0.0F; y < noiseTex.height; y++)
        {
            for (float x = 0.0F; x < noiseTex.width; x++)
            {
                float xCoord = xOrg + x / noiseTex.width * scale;
                float yCoord = yOrg + y / noiseTex.height * scale + yOffset;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);

                if (sample < 0.4f)
                //pix[(int)y * noiseTex.width + (int)x] = new Color(0, 1, 1); //0, 1, 0.5
                {
                    pix[(int)y * noiseTex.width + (int)x] = getColor(sample, 0);
                }
                else if (sample <= 0.7f)
                    //pix[(int)y * noiseTex.width + (int)x] = new Color(1, 0, 0.25f); //0, 1, 0.5  - 0 1 0
                    pix[(int)y * noiseTex.width + (int)x] = getColor(sample, 1);

                else
                    //pix[(int)y * noiseTex.width + (int)x] = new Color(0.6f, 1, 0);  // 0 1 0 -  1 1 0
                    pix[(int)y * noiseTex.width + (int)x] = getColor(sample, 2);

        
                //    pix[(int)y * noiseTex.width + (int)x] = new Color(1,1,1);
                // pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
                //if (sample < 0.25f)
                ////pix[(int)y * noiseTex.width + (int)x] = new Color(0, 1, 1); //0, 1, 0.5
                //{
                //    pix[(int)y * noiseTex.width + (int)x] = getColor(sample, 0);
                //    print(sample);
                //}
                //else if (sample >= 0.25f && sample <= 0.5f)
                //    //pix[(int)y * noiseTex.width + (int)x] = new Color(1, 0, 0.25f); //0, 1, 0.5  - 0 1 0
                //    pix[(int)y * noiseTex.width + (int)x] = getColor(sample, 1);

                //else if (sample >= 0.5f && sample <= 0.75f)
                //    //pix[(int)y * noiseTex.width + (int)x] = new Color(0.6f, 1, 0);  // 0 1 0 -  1 1 0
                //    pix[(int)y * noiseTex.width + (int)x] = getColor(sample, 2);

                //else if (sample >= 0.75f)
                //    //pix[(int)y * noiseTex.width + (int)x] = new Color(1, 1, 1); //1 1 0   - 1 0 0.2
                //    pix[(int)y * noiseTex.width + (int)x] = getColor(sample, 3);
                ////else
                ////    pix[(int)y * noiseTex.width + (int)x] = new Color(1,1,1);
                //// pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
            }
        }
        // Copy the pixel data to the texture and load it into the GPU.
        noiseTex.SetPixels(pix);
        noiseTex.Apply();

    }

    float normalize(float value, float min, float max)
    {
        if (value > max)
            return 1;
        else if (value < min)
            return 0;
        return (value - min) / (max - min);
    }
    Color getColor(float value, int index)
    {
        float normalized = normalize(value, surfaces[index].minHeight, surfaces[index].maxHeight);

        Color color = Color.Lerp(surfaces[index].minColor, surfaces[index].maxColor, normalized);
        //return surfaces[index].maxColor;
        return color;
    }
    //void Update()
    //{
    //  //  CalcNoise();
    //    yOffset += offsetIncrement;
    //}
    public class Surface
    {
        public float minHeight;
        public float maxHeight;
        public Color minColor;
        public Color maxColor;
        public Surface(float minHeight, float maxHeight, Color minColor, Color maxColor)
        {
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
            this.minColor = minColor;
            this.maxColor = maxColor;
        }
        
    }
}
