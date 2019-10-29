using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private Timer mTimer;

    void Start ()
    {
        //StartCoroutine (SpawnWaves ());
        
        mTimer = new Timer(5);
        mTimer.Play();
        mTimer.OnTimerUpdate += UpdateTimer;
        mTimer.OnTimerEnd += EndTimer;

    }

    private void Update()
    {
        mTimer.Update(Time.deltaTime);
    }

    void UpdateTimer()
    {
        
    }
    
    void EndTimer()
    {
        
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
        }
    }
}
