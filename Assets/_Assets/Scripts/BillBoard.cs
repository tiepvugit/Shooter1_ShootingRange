using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private void OnValidate() => _camera = Camera.main;

    private void Start() => LookCamera();

    private void Update() => LookCamera();

    private void LookCamera() => transform.forward = -_camera.transform.forward;
}
