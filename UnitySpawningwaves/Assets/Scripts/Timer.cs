using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class Timer
    {
     private float time = 0f;
	public float endTime;
	public delegate void TimerFunction () ;
	public event TimerFunction OnTimerEnd;
	public event TimerFunction OnTimerUpdate;
	private TimerState state = TimerState.PAUSED;
	private bool isReversed = false;


	public Timer (float endTime){
	//	TimerManager.SetupTimer (this);
		this.endTime = endTime;
	}


	public Timer (float endTime, TimerFunction function) : this (endTime){
		OnTimerEnd += function;
	}


	public Timer(float endTime, bool isAlreadyFinished) : this (endTime){
		if (isAlreadyFinished) {
			time = endTime;
			state = TimerState.FINISHED;
		}
	}


	public Timer ( float endTime, TimerFunction function, bool isAlreadyFinished) : this (endTime, isAlreadyFinished){
		OnTimerEnd += function;
	}

	

	public void Reset () {
		state = TimerState.PAUSED;
		time = 0f;
	}

	public void Pause (){
		state = TimerState.PAUSED;
	}
	
	public bool IsFinished () {
		return state == TimerState.FINISHED;
	}
	
	
	public bool IsStarted() {
		return state == TimerState.UPDATING;
	}
	
	public void Play () {
		state = TimerState.UPDATING;
	}
	
	public void ResetPlay(){
		Reset ();
		Play ();
	}

	public void Update(float delta){
		if (state == TimerState.UPDATING ){
			if (OnTimerUpdate != null)
				OnTimerUpdate();
			Time = isReversed ? Time - delta : Time + delta;
		}
	}

	public float EndTime{
		get { return endTime;}
		set {
			Reset ();
			endTime = value;
		}
	}

	public bool IsReversed {
		get{ return isReversed; }
		set{ isReversed = value; }
	}

	public float Time {
		get {
			return time;
		}
		set {
			if (state == TimerState.UPDATING) {
				if (value >= endTime) {
					time = endTime;
					state = TimerState.FINISHED;
					if (OnTimerEnd != null)
						OnTimerEnd ();
				}
				else if (value <= 0){
					time = 0;
					state = TimerState.PAUSED;
				}
				else
					time = value;
			}
		}
	}

	public float GetPercentage(){
		return Time / EndTime;
	}

	public float GetPercentageLeft(){
		return 1 - (Time / EndTime);
	}

	public float GetTimeLeft(){
		return EndTime - Time;
	}

    }
}

public enum TimerState {
	PAUSED,
	FINISHED,
	UPDATING
};