using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int repetitionCycleTime;
	public int repetitionCycleCount;
	public bool infiniteRepetition; 
	
    private Timer mTimer;
    private int repeatCount = 1;
    
    
    void Start ()
    {
        SetupTimer();
    }

    private void SetupTimer()
    {
        mTimer = new Timer(repetitionCycleTime);
        mTimer.Play();
        
        mTimer.OnTimerEnd += EndedTimer;
        
    }

    private void Update()
    {
        if(mTimer != null)
            mTimer.Update(Time.deltaTime);
    }

    
    void EndedTimer()
    {
        
        StartCoroutine (SpawnWaves ());

        if (repeatCount < repetitionCycleCount)
        {
            mTimer.ResetPlay();
            repeatCount++;    
        }
        else
        {
            FinishTimer();
        }
        
    }

    private void FinishTimer()
    {
        if (mTimer != null)
        {
            mTimer.Pause();
            mTimer = null;
        }
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
            
            break;
        }
    }

    private void OnDestroy()
    {
        FinishTimer();
    }
}
