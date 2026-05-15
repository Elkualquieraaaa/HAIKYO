using UnityEngine;

public class GlobalTime : MonoBehaviour
{

    public float Actualtime = 0;
    void Update()
    {
        Actualtime += Time.deltaTime;
    }
}
