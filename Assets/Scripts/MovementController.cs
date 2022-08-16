using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    InputControls inputControls;
    public float _moveSpeed;
    Vector3 movePosition = new Vector3();

    Coroutine MoveCoroutine;
    private void Awake()
    {
        inputControls = new InputControls();
        inputControls.MainMap.Enable();
        inputControls.MainMap.MoveControl.performed += MoveCharacter;
    }

    private void Start()
    {
        movePosition = transform.position;
        GameEvents.instance.speedUpCharacter += IncreaseSpeed;
        GameEvents.instance.slowDownCharacter += DecreaseSpeed;
    }


    void MoveCharacter(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(context.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<MapTileScript>() != null)
            {
                Vector3 hitPosition = hit.point;
                movePosition = new Vector3(hitPosition.x, transform.position.y, hitPosition.z);
                Debug.Log(movePosition);
                if (MoveCoroutine == null)
                {
                    MoveCoroutine = StartCoroutine(Move());
                }
                else
                {
                    StopCoroutine(MoveCoroutine);
                    MoveCoroutine = StartCoroutine(Move());
                }
            }    
        }
    }

    IEnumerator Move()
    {

        while (Vector3.Distance(transform.position, movePosition) > 0.01)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, _moveSpeed * Time.fixedDeltaTime);

            Debug.Log(_moveSpeed * Time.fixedDeltaTime);
            yield return null;
        }
    }

    private void IncreaseSpeed()
    {
        _moveSpeed += 2;
        Debug.Log(_moveSpeed);
    }

    private void DecreaseSpeed()
    {
        _moveSpeed -= 2;
        Debug.Log(_moveSpeed);
    }



}
