using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private Transform target;
    private NavMeshAgent _agent;
    private Ray lastRay;
    private Camera mainCamera;
    private Animator _animator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent != null)
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }

            UpdateAnimator();
        }
    }

    private void MoveToCursor()
    {
        RaycastHit hit;
        Ray ray;
        //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hasHit)
        {
            _agent.destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        var velocity = _agent.velocity;
        var localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z/2f;
        _animator.SetFloat("forwardSpeed", speed);
    }
}
