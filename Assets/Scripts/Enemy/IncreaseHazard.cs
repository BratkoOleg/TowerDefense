using UnityEngine;

public class IncreaseHazard : MonoBehaviour
{
    public float _time;
    void Update()
    {
        _time += Time.deltaTime;
    }
}
