using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = -0.1f;
    public float currentRotationAngle;
    private bool isActivated = false;
    private bool rotateRight = true;
    private Rigidbody2D rb;
    public PlateformeMove2 plateforme;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        currentRotationAngle = transform.rotation.eulerAngles.z;
        Debug.Log(currentRotationAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            Debug.Log("isACTUPDT");
            if (rotateRight)
            {
                // Rotate towards the right
                currentRotationAngle -= rotationSpeed;
            }
            else
            {
                // Rotate towards the left
                currentRotationAngle += rotationSpeed;
            }
            currentRotationAngle = Mathf.Clamp(currentRotationAngle, -60f, 60f);
            transform.rotation = Quaternion.Euler(0, 0, currentRotationAngle);

            
        }
        if (Mathf.Approximately(currentRotationAngle, -60))
        {
            plateforme.up();
        }
        if (Mathf.Approximately(currentRotationAngle, 60))
        {
            plateforme.down();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireBoy") || collision.gameObject.CompareTag("WaterGirl"))
        {
            isActivated = true;
            // Determine the side of the collision
            rotateRight = collision.transform.position.x < transform.position.x;
            Debug.Log("Collision true. Rotate Right: " + rotateRight);
            Debug.Log("isACTCOLI");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireBoy") || collision.gameObject.CompareTag("WaterGirl"))
        {
            isActivated = false;
            Debug.Log("Collision false");
            Debug.Log("NOACT");
        }
    }
}