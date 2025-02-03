using System.Collections;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rb;

    float maxDamp = 2f;
    float minDamp = 0.35f;
    float startDamp;
    public float flashlightSpeed=0;
    bool flashLightActivated = false;

    /*              //this will be used if we want color change over time
    Color[] colors = new Color[3]
    {
        new Color(1f, 0.2f, 0.2f), new Color(0.25f, 0.65f, 1f), new Color(0.25f, 1f, 0.2f)
    };
    public int currColorIndex = 0;
    public Material material;
    float timer;
    float delay=5;
    float t = 0f; // Interpolation progress
    */

    public int currentElement=0;            //this is lets say fire and red obstacles will be beneficial for him
    public static playerController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startDamp = rb.linearDamping;

        /*   //this will be used if we want color change over time
        material.color = colors[currColorIndex];
        timer = delay;
        */

    }

    void Update()
    {
        /*       //this will be used if we want color change over time
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            t += Time.deltaTime / timer;
            material.color = Color.Lerp(colors[currColorIndex], colors[(currColorIndex + 1) % colors.Length], t);
        }
        else
        {
            t = 0f; // Reset interpolation progress
            currColorIndex = (currColorIndex + 1) % colors.Length; // Loop to the start if at the end
            timer = Random.Range(3, 10); // Randomize next timer
        }*/


    }

    //this is called by pipes
    public void changeSpeed(float percent)
    {
        if(!flashLightActivated)
            StartCoroutine(speedControl(percent));
    }
    IEnumerator speedControl(float percent)
    {
        float currDamp=rb.linearDamping;
        float tempDamp = (1 + percent / 100) * currDamp;

        if (tempDamp > startDamp && tempDamp > maxDamp)
            tempDamp = maxDamp;
        else if (tempDamp < startDamp && tempDamp < minDamp)
            tempDamp = minDamp;

        rb.linearDamping = tempDamp;

        yield return new WaitForSeconds(1.5f);
        //rb.linearDamping = Mathf.Lerp(currDamp, startDamp, Time.deltaTime);
        rb.linearDamping = startDamp;
    }

    //---reducing the size of the black hole ie speeding the player up :D
    public void flashlightActive()
    {
        flashLightActivated = true;
        rb.linearDamping = flashlightSpeed;
    }
    public void flashlightDisabled()
    {
        flashLightActivated = false;
        rb.linearDamping = startDamp;
    }
}
