using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float followSpeed;
    public Transform target;
    public float yOffset;
    public float depth;

    // Update is called once per frame
    private void Update()
    {
        var position = target.position;
        var newPos = new Vector3(position.x, position.y, depth);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}