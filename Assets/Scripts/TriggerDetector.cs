using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class TriggerDetector<T> : MonoBehaviour
{
	public bool _isActive = true;
	public string[] _affectedTags;
    public UnityEvent<T> OnTriggerEnterEv;
	public UnityEvent<T> OnTriggerStayEv;
	public UnityEvent<T> OnTriggerExitEv;

	private void OnTriggerEnter(Collider other)
	{
		if (_isActive && _affectedTags.Contains(other.tag)) OnTriggerEnterCallBack(other);
	}

	private void OnTriggerStay(Collider other)
	{
		if (_isActive && _affectedTags.Contains(other.tag)) OnTriggerStayCallBack(other);
	}

	private void OnTriggerExit(Collider other)
	{
		if (_isActive && _affectedTags.Contains(other.tag)) OnTriggerExitCallBack(other);
	}

	public abstract void OnTriggerEnterCallBack(Collider col);

	public abstract void OnTriggerStayCallBack(Collider col);

	public abstract void OnTriggerExitCallBack(Collider col);

	public void IsActiveSet(bool value) => _isActive = value;
}
