using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLine : MonoBehaviour
{

    [SerializeField]
    LineRenderer lineRenderer;

    [SerializeField]
    CapsuleCollider2D capsuleCollider;

    [SerializeField]
    private float forceAmount = 10;

    private Vector2 forceDirection;
    private Vector3 startPosition;
    private Vector3 endPosition;

    [SerializeField]
    private float capsuleWidth = 1;
    [SerializeField]
    private float capsuleScaleModifier;
    [SerializeField]
    private float lifetime = 5;

    private float startForce;

    public void Initialise(Vector3 lStartPosition, Vector3 lEndPosition)
    {
        lineRenderer.SetPositions(new Vector3[] { lEndPosition, lStartPosition });

        capsuleCollider.size = new Vector2(Vector2.Distance(lStartPosition, lEndPosition) * capsuleScaleModifier, capsuleWidth);

        startPosition = lStartPosition;
        endPosition = lEndPosition;
    }

    private void Start()
    {
        startForce = forceAmount;
    }

    private void Update()
    {
        forceAmount -= 0.05f;
        lineRenderer.startWidth = capsuleWidth / (startForce / forceAmount);

        if (forceAmount < 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        startPosition = lineRenderer.GetPosition(0);
        endPosition = lineRenderer.GetPosition(1);

        forceDirection = startPosition - endPosition;

        if (forceDirection != Vector2.zero)
        {
            collision.attachedRigidbody.AddForce(forceDirection * forceAmount);
        }
    }
}
