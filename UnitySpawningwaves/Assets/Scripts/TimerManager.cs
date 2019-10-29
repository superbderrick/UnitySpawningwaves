using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class TimerManager : MonoBehaviour
    {
        private static ArrayList timers = new ArrayList (); 
        public static bool isPlaying = true; 


        private void Update() {
            foreach (Timer t in timers)
                t.Update(Time.deltaTime);
        }

        public static void Init() {
            if (GameObject.Find("Timer Manager") != null)
                return; 
            GameObject timerManager = new GameObject("Timer Manager");
            timerManager.AddComponent<TimerManager>();
            Object.DontDestroyOnLoad(timerManager);
        }

        public static void SetupTimer(Timer t){
            timers.Add (t);
        }

        public static void Pause() {

        }
    }
}