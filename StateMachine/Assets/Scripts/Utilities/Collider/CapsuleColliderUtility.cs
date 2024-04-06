using System;
using UnityEngine;

[Serializable]

public class CapsuleColliderUtility
{
    public CapsuleColliderData CapsuleColliderData { get; private set; }

    [field: SerializeField] public DefaultColliderData DefaultColliderData { get; private set; }

    [field: SerializeField] public SlopeData SlopeData { get; private set; }

    public void Inizialize(GameObject gameObject)
    {
        if (CapsuleColliderData != null)
            return;

        CapsuleColliderData = new CapsuleColliderData();
        CapsuleColliderData.Initialize(gameObject);
    }

    public void CalculateCapsuleColliderDimensions()
    {
        SetCapsuleColliderRadius(DefaultColliderData.Radius);
        SetCapsuleColliderHeight(DefaultColliderData.Height * (1f - SlopeData.StepHeightPercentage));
        RecalculateCapsuleColliderCenter();

        float halfColliderHeight = CapsuleColliderData.Collider.height / 2;

        if ( halfColliderHeight < CapsuleColliderData.Collider.radius)
        {
            SetCapsuleColliderRadius(halfColliderHeight);
        }
        CapsuleColliderData.UpdateColliderData();
    }

    public void SetCapsuleColliderRadius(float radius)
    {
        CapsuleColliderData.Collider.radius = radius;
    }

    public void SetCapsuleColliderHeight(float height)
    {
        CapsuleColliderData.Collider.height = height;
    }

    public void RecalculateCapsuleColliderCenter()
    {
        float capsuleHeightDiff = DefaultColliderData.Height - CapsuleColliderData.Collider.height;

        Vector3 newColliderCenter = new Vector3(0, DefaultColliderData.CenterY + (capsuleHeightDiff / 2), 0f);

        CapsuleColliderData.Collider.center = newColliderCenter;
    }
}
