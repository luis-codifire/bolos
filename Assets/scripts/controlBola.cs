using UnityEngine;

public class controlBola : MonoBehaviour
{
    public float fuerzaLanzar = 50f;
    public float rotationSpeed = 50f;
    public KeyCode teclaLanzar = KeyCode.Space;
    private bool lanzada = false;
    private Rigidbody rb;
    public Transform flechaTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lanzada)
        {
            float rotationInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
            if (Input.GetKeyDown(teclaLanzar))
            {
                LanzarBola();
            }
            UpdateFlechaRotation();
        }
    }

    private void LanzarBola()
    {
        rb.AddForce(transform.forward * fuerzaLanzar, ForceMode.Impulse);
        lanzada = true;
        // Desactivando la flecha
        if (flechaTransform != null)
        {
            flechaTransform.gameObject.SetActive(false);
        }
    }

    private void UpdateFlechaRotation()
    {
        if (flechaTransform != null)
        {
            Vector3 flechaRotation = flechaTransform.eulerAngles;
            flechaRotation.y = flechaTransform.eulerAngles.y;
            flechaTransform.eulerAngles = flechaRotation;
        }
    }
}
