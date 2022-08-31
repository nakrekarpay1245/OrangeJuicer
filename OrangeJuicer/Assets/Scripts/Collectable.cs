using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Rigidbody rigidbodyComponent;
    private MeshRenderer meshRenderer;

    [SerializeField]
    private float moveForce;

    [SerializeField]
    private Material collectedMaterial;

    private Vector3 movePosition;

    public bool isCollected;

    private void Awake()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Manager.manager.IncreaseTotalCubeCount();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            // Debug.Log("Collect Area");

            if (!isCollected)
            {
                isCollected = true;
                meshRenderer.material = collectedMaterial;
                Manager.manager.IncreaseCollectedCubeCount();
                Collector.collector.CreateCollectorParticle(transform.position);
                MoveCollectArea(other.transform.parent.transform.position);
                gameObject.layer = 7;
            }
        }
    }

    public void MoveCollectArea(Vector3 position)
    {
        movePosition = position - transform.position;
        StartCoroutine(MoveRoutine(movePosition));
    }

    public IEnumerator MoveRoutine(Vector3 movePosition)
    {
        rigidbodyComponent.velocity = Vector3.zero;
        rigidbodyComponent.AddForce(movePosition * moveForce * 0.01f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.75f);
        rigidbodyComponent.isKinematic = true;
    }
}
