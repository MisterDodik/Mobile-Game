using UnityEngine;
using UnityEngine.EventSystems;

public class OnSameColorMove : MonoBehaviour
{
    GameObject player;
    public float distance = 20f;
    public LayerMask quadLayer;

    public GameObject quad;
    Renderer rend;
    int pixWidth;
    int pixHeight;
    private Texture3D noiseTex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");




        rend = quad.GetComponent<MeshRenderer>();

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
            pixHeight = Mathf.Abs((int)(maxScreenPoint.y - minScreenPoint.y)) * (int)transform.localScale.y;

        }

        const int maxTextureSize = 2048;

        pixWidth = Mathf.Clamp(pixWidth, 1, maxTextureSize);
        pixHeight = Mathf.Clamp(pixHeight, 1, maxTextureSize);
        print((pixWidth, pixHeight));
        noiseTex = new Texture3D(pixWidth, pixHeight, 1,TextureFormat.RGB24, false);
        rend.materials[0].mainTexture = noiseTex;

      //  Camera.onPostRender += OnPostRenderCallback;
    }
    bool isPerformingScreenGrab = false;
    // Update is called once per frame
    void Update()
    {
        // When the user presses the Space key, perform the screen grab operation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPerformingScreenGrab = true;
        }
    }
    //void OnPostRenderCallback(Camera cam)
    //{
    //    print("cao");
    //    if (isPerformingScreenGrab)
    //    {
    //        // Check whether the Camera that just finished rendering is the one you want to take a screen grab from
    //        if (cam == Camera.main)
    //        {
    //            //// Define the parameters for the ReadPixels operation
    //            //Rect regionToReadFrom = new Rect(0, 0, Screen.width, Screen.height);
    //            //int xPosToWriteTo = 0;
    //            //int yPosToWriteTo = 0;
    //            //bool updateMipMapsAutomatically = false;

    //            //// Copy the pixels from the Camera's render target to the texture
    //            //noiseTex.ReadPixels(regionToReadFrom, xPosToWriteTo, yPosToWriteTo, updateMipMapsAutomatically);
    //            //noiseTex.
    //            //// Upload texture data to the GPU, so the GPU renders the updated texture
    //            //// Note: This method is costly, and you should call it only when you need to
    //            //// If you do not intend to render the updated texture, there is no need to call this method at this point
    //            //noiseTex.Apply();
    //            //Color pixelColor = noiseTex.GetPixel((int)player.transform.position.x, (int)player.transform.position.y);
    //            //Debug.Log($"Color at (pos): {pixelColor}");
    //            //// Reset the isPerformingScreenGrab state
    //            //isPerformingScreenGrab = false;
    //        }
    //    }
    //}
    public void RaycastTest()
    {
        return;
        //(player.transform.position, Vector3.forward, distance, quadLayer)
        RaycastHit hit;
        if(Physics.Raycast(player.transform.position, Vector3.forward, out hit, distance, quadLayer))
        {
            // print(hit.collider.gameObject.name);
            //print(hit.textureCoord);

            //noiseTex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0,0);
            //noiseTex.Apply();

            //Color pixelColor = noiseTex.GetPixel((int)hit.point.x, (int)hit.point.y);
            //Debug.Log($"Color at ({(int)hit.point.x}, {(int)hit.point.y}): {pixelColor}");
            //print(hit.point);
            //print(noiseTex.GetPixel((int)hit.point.x, (int)hit.point.y));
        }
    }
}
