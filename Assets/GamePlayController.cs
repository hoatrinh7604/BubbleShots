using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    private float m_Time = 0;
    [SerializeField] SpawController[] listSpaws;

    // Update is called once per frame
    void Update()
    {
        m_Time += Time.deltaTime;

        if (m_Time > 30f)
        {
            ReduceTime();
            m_Time = 0;
        }
    }

    private void ReduceTime()
    {
        listSpaws = GetComponents<SpawController>();
        for(int i = 0; i < listSpaws.Length; i++)
        {
            listSpaws[i].ReduceDelayTime();
        }
    }
}
