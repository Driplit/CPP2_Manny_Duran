using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using Unity.Collections;

public class PlayerController : MonoBehaviour
{
    const string IDLE = "Idle";
    const string WALK = "Walk";

    CustomAction input;
    NavMeshAgent agent;
    Animator animator;


    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask ClickableLayers;

    float lookRotationSpeed = 5f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();   

        input = new CustomAction();
        AssignInputs();
    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }
    void ClickToMove()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera not found!");
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, ClickableLayers))
        {
            agent.destination = hit.point;
            SpawnClickEffect(hit.point + new Vector3(0, 0.1f, 0));
        }
    }
    private void SpawnClickEffect(Vector3 position)
    {
        if (clickEffect != null)
        {
            ParticleSystem effect = Instantiate(clickEffect, position, clickEffect.transform.rotation);
            Destroy(effect.gameObject, effect.main.duration);
        }
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        FaceTarget();
        SetAnimations();
    }

    void FaceTarget()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            Vector3 direction = (agent.destination - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
        }
    }
    void SetAnimations()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && agent.velocity.magnitude < 0.1f)
        {
            animator.Play(IDLE);
        }
        else
        {
            animator.Play(WALK);
        }
    }





}
