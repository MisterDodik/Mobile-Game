using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    public Transform flashlight;

    public Slider energySlider;
    public RectTransform spentDelay;
    float maxDelaySliderWidth=200;
    float spent;

    public float batteryExpiration=5;
    bool flashLightActive=false;

    bool isDecaying = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spentDelay =  GetComponent<RectTransform>();
        onCancel();
    }
    private void Update()
    {
        if(flashLightActive)
        {
            if ((spentDelay.anchoredPosition.x - spent * 2) >= -maxDelaySliderWidth)
            {
                spent += Time.deltaTime * batteryExpiration;          
                spentDelay.sizeDelta = new Vector2(spent * 2, spentDelay.sizeDelta.y);       
            }
            else
            {
                onCancel();
            }

        }
    }
    public void onMove(Vector2 input)
    {
        if (energySlider.value <= 0 || isDecaying)
            return;
        
        flashLightActive = true;

        flashlight.gameObject.SetActive(true);

        Vector3 mouseRealPos = Camera.main.ScreenToWorldPoint((new Vector3(input.x, input.y, 43)));

        Vector3 curPos = flashlight.transform.position;

        curPos.x = mouseRealPos.x;
        flashlight.transform.position = curPos;

        playerController.instance.flashlightActive();

    }
    public void onCancel()
    {
        //spentDelay.anchoredPosition = new Vector2(spentDelay.anchoredPosition.x - spent * 2, spentDelay.anchoredPosition.y);
        //spentDelay.sizeDelta = new Vector2(0, spentDelay.sizeDelta.y);

        //energySlider.value -= spent;
        //spent = 0;
        //flashLightActive = false;

        StartCoroutine(slowDecay());

        flashlight.gameObject.SetActive(false);
        playerController.instance.flashlightDisabled();
    }
  
    IEnumerator slowDecay()
    {
        isDecaying = true;
        float percent = 100;
        float speedSize = 1/percent * spentDelay.sizeDelta.x;

        spentDelay.anchoredPosition = new Vector2(spentDelay.anchoredPosition.x - spent * 2, spentDelay.anchoredPosition.y);
        energySlider.value -= spent;
        spent = 0;
        flashLightActive = false;
        spentDelay.localRotation = Quaternion.Euler(0, 0, 180);

        float t = 0;
        while (spentDelay.sizeDelta.x > 0)
        {
            // t+=0.05f;
            spentDelay.sizeDelta = new Vector2(spentDelay.sizeDelta.x - speedSize, spentDelay.sizeDelta.y);
            // spentDelay.sizeDelta = Vector2.Lerp(new Vector2(spentDelay.sizeDelta.x, spentDelay.sizeDelta.y), new Vector2(0, spentDelay.sizeDelta.y), t * Time.deltaTime);
            yield return null;
        }

        spentDelay.localRotation = Quaternion.Euler(0, 0, 0);

        isDecaying = false;

        //while (!endConditionPos || !endConditionSize)
        //{
        //    if (spentDelay.anchoredPosition.x > endPos)
        //    {
        //        spentDelay.anchoredPosition = new Vector2(spentDelay.anchoredPosition.x - speedPos, spentDelay.anchoredPosition.y);
        //        print((endConditionPos, spentDelay.anchoredPosition.x, endPos));
        //    }
        //    else
        //        endConditionPos = true;

        //    if(spentDelay.sizeDelta.x > endSize)
        //    {
        //        spentDelay.sizeDelta = new Vector2(spentDelay.sizeDelta.x-speedSize, spentDelay.sizeDelta.y);
        //    }
        //    else
        //        endConditionSize = true;

        //    yield return null;
        //}
    }
}
