using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Platform Types")]
    public GameObject breakablePlatform;
    public GameObject[] speedPlatform;
    public GameObject spikePlatform;
    public GameObject standardPlatform;

    [Header("Boundary Limits on X-Axis")]
    public float minimumX = -2f;
    public float maximumX = 2f;

    [Space]
    public float spawnRepeat;
    [SerializeField] private float platformCount = 0;

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnRepeat);
    }

    private void Spawn()
    {
        platformCount++;

        Vector3 pos = this.transform.position;
        pos.x = Random.Range(minimumX, maximumX);

        GameObject newPlatform = null;

        if(platformCount < 2)
        {
            Instantiate(standardPlatform, pos, Quaternion.identity, transform);
        }
        else if(platformCount == 2)
        {
            if(Random.Range(0, 2) > 0)
            {
                Instantiate(standardPlatform, pos, Quaternion.identity, transform);
            }
            else
            {
                newPlatform = Instantiate(speedPlatform[Random.Range(0, speedPlatform.Length)], pos, Quaternion.identity, transform);
            }
        }
        else if(platformCount == 3)
        {
            if (Random.Range(0, 2) > 0)
            {
                Instantiate(standardPlatform, pos, Quaternion.identity, transform);
            }
            else
            {
                newPlatform = Instantiate(spikePlatform, pos, Quaternion.identity, transform);
            }
        }
        else if (platformCount == 4)
        {
            if (Random.Range(0, 2) > 0)
            {
                Instantiate(standardPlatform, pos, Quaternion.identity, transform);
            }
            else
            {
                newPlatform = Instantiate(breakablePlatform, pos, Quaternion.identity, transform);
            }

            platformCount = 0;
        }
    }
}
