using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float movingSpeed;

    private void OnValidate() => characterController = GetComponent<CharacterController>();

    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        var direction = transform.right * hInput + transform.forward * vInput;
        //print($"right: {transform.right} - forward: {transform.forward}");
        characterController.SimpleMove(direction * movingSpeed);
    }
}
