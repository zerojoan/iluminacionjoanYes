using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float turnSpeed = 3f; // Velocidad de giro de la cámara

    private Transform mainCameraTransform; // Referencia a la transformación de la cámara principal

    void Start()
    {
        // Obtener la transformación de la cámara principal
        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Obtener la entrada de los controles
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección de movimiento
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Aplicar movimiento al personaje
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);

        // Girar el personaje con el mouse o los controles de entrada horizontal
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed);

        // Girar la cámara horizontalmente con el mouse
        float mouseX = Input.GetAxis("Mouse X") * turnSpeed;
        mainCameraTransform.Rotate(Vector3.up, mouseX);
    }
}