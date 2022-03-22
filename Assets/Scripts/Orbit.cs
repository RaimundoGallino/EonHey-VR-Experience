using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] public float xSpread;
    [SerializeField] public float zSpread;
    [SerializeField] public float yOffset;
    [SerializeField] public Transform centerPoint;
    
    [SerializeField] public float rotSpeed;
    [SerializeField] public bool rotateClockwise;
    
    private float _timer = 0f;
    void Update()
    {
        _timer += Time.deltaTime * rotSpeed;
        Rotate();
    }

    private void OnDrawGizmos()
    {
        _timer += Time.deltaTime * rotSpeed;
        Rotate();
    }

    void Rotate()
    {
        if (rotateClockwise)
        {
            float x = -Mathf.Cos(_timer) * xSpread;
            float z = Mathf.Sin(_timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
        else
        {
            float x = Mathf.Cos(_timer) * xSpread;
            float z = Mathf.Sin(_timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
    }
}
