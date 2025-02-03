using UnityEngine;
using UnityEngine.UI;

public class magnetSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject arc;
    public float maxAngle = 360;

    Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = arc.transform.position;
    }

    public void onChange()
    {
        float angle = slider.value * maxAngle;
        arc.transform.rotation = Quaternion.Euler(0, 0, angle);
        
        Vector3 start= arc.transform.position;
        start.z = startPos.z;

        arc.transform.position = start;
    }
}
