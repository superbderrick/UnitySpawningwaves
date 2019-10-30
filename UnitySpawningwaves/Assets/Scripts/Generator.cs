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
    public int cycleCount;
    
    private Timer mTimer;
    

    void Start ()
    {
        SetupTimer();
    }

    private void SetupTimer()
    {
        mTimer = new Timer(cycleCount);
        mTimer.Play();
        
        mTimer.OnTimerEnd += EndTimer;
        
    }

    private void Update()
    {
        mTimer.Update(Time.deltaTime);
    }

    
    void EndTimer()
    {
        Debug.Log("EndTimer" + mTimer.Time);
        
        StartCoroutine (SpawnWaves ());
        mTimer.ResetPlay();
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

    private void OnDestroy()
    {
        if (mTimer != null)
        {
            mTimer.Pause();
            mTimer = null;
        }
    }
}
