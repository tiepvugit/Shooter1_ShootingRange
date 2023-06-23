using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollSwitcher : MonoBehaviour
{
    [SerializeField]
    private Rigidbody[] rigidbodies;
    [SerializeField]
    private Animator animator;


    [ContextMenu("Retrieve Rigidbodies")]
    private void RetrieveRigidbodies()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    [ContextMenu("Clear Ragdoll")]
    private void ClearRogdoll()
    {
        DestroyComponents<CharacterJoint>();
        DestroyComponents<Rigidbody>();
        DestroyComponents<Collider>();
    }

    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll() => SetRagdoll(true);
    [ContextMenu("Disable Ragdoll")]
    public void DisableRagdoll() => SetRagdoll(false);

    private void SetRagdoll(bool active)
    {
        animator.enabled = !active;
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = !active;
        }
    }


    private void DestroyComponents<T>() where T : Component
    {
        var components = GetComponentsInChildren<T>();
        for (var i = components.Length - 1; i >= 0; i--)
        {
            DestroyImmediate(components[i]);
        }
    }



}
