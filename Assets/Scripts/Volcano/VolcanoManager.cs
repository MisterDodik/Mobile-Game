using NUnit.Framework.Interfaces;
using UnityEngine;

public class VolcanoManager : MonoBehaviour
{
    float timer;
    public Transform firePos;
    public GameObject[] asteroids;
    public GameObject particles;
    public GameObject volcano;

    Vector3 startScale;
    Vector3 currScale;

    public Animator cameraAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startScale = volcano.transform.localScale;
        timer = 5f;

        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            spawnAsteroid();
            timer = Random.Range(2, 9);
        }

        if(volcano.transform.localScale != startScale)
        {
            currScale = volcano.transform.localScale;
            currScale.y = Mathf.Lerp(currScale.y, startScale.y, Time.deltaTime);
            volcano.transform.localScale = currScale;
        }
    }

    void spawnAsteroid()
    {

        Vector3 scale = volcano.transform.localScale;
        scale.y = 7;
        volcano.transform.localScale = scale;

        if(!particles.activeSelf)
            particles.SetActive(true);
        particles.GetComponent<ParticleSystem>().Play();

        int randomIndex = Random.Range(0, asteroids.Length);
        GameObject asteroid = (GameObject)Instantiate(asteroids[randomIndex], firePos.position, Quaternion.identity);

        cameraAnimator.SetTrigger("shake");
    }
}
