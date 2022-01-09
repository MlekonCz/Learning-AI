using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAICar : MonoBehaviour {

	[SerializeField] private Transform goal;
	[SerializeField] private Text readout;

	[SerializeField] private float _acceleration = 5f;
	[SerializeField] private float _deceleration = 5f;
	[SerializeField] private float _minSpeed = 0;
	[SerializeField] private float _maxSpeed = 100f;
	[SerializeField] private float _rotationSpeed = 10.0f;

	private float _breakAngle = 20f;
	private float _currentSpeed = 0f;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 lookAtGoal = new Vector3(goal.position.x, 
										this.transform.position.y, 
										goal.position.z);
		Vector3 direction = lookAtGoal - this.transform.position;

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
												Quaternion.LookRotation(direction), 
												Time.deltaTime*_rotationSpeed);

		if (Vector3.Angle(goal.forward, this.transform.forward) > _breakAngle && _currentSpeed > 15f)
		{
			_currentSpeed = Mathf.Clamp(_currentSpeed - (_acceleration * Time.deltaTime), _minSpeed, _maxSpeed);
		}
		else
		{
			_currentSpeed = Mathf.Clamp(_currentSpeed + (_acceleration * Time.deltaTime), _minSpeed, _maxSpeed);
		}
		
		this.transform.Translate(0,0,_currentSpeed);
		AnalogueSpeedConverter.ShowSpeed(_currentSpeed, _minSpeed, _maxSpeed);
		if (readout)
		{
			readout.text = "" + (int)_currentSpeed;
		}
		
	}
}
