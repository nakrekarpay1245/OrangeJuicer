using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private GameObject particlePrefab;

    public static Collector collector;

    private void Awake()
    {
        if (!collector)
        {
            collector = this;
        }
    }

    public void CreateCollectorParticle(Vector3 particlePosition)
    {
        Destroy(Instantiate(particlePrefab, particlePosition, Quaternion.identity), 2);
    }

}
