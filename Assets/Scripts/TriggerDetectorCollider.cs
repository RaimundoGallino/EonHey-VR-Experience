using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetectorCollider : TriggerDetector<Collider>
{
    public override void OnTriggerEnterCallBack(Collider col)
	{
		OnTriggerEnterEv?.Invoke(col);
	}

	public override void OnTriggerStayCallBack(Collider col)
	{
		OnTriggerStayEv?.Invoke(col);
	}

	public override void OnTriggerExitCallBack(Collider col)
	{
		OnTriggerExitEv?.Invoke(col);
	}
}
