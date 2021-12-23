using UnityEngine;

//以start和end中点，画一个半圆。
public class SlerpExample : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Vector3 offset;

    private Vector3 center;

    private void Start()
    {
        //弧线的中心,向下移动中心，垂直于弧线
        center = (start.position + end.position) * 0.5f - offset;
        Debug.DrawLine(center, start.position, Color.yellow, duration: 150);
        Debug.DrawLine(center, end.position, Color.yellow, duration: 150);
    }

    void Update()
    {
        //相对于中心在弧线上插值
        Vector3 riseRelCenter = start.position - center;
        Vector3 setRelCenter = end.position - center;

        var startPosition = transform.position;
        var endPosition = Vector3.Slerp(riseRelCenter, setRelCenter, Time.time*0.1f) + center;
        Debug.DrawLine(startPosition, endPosition, Color.red, duration: 150 );
        transform.position = endPosition;
    }
}
