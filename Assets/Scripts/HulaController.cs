using UnityEngine;

public class HulaController : MonoBehaviour
{
    [SerializeField] bool useMouse = false;
    [SerializeField] bool isLeftStick = true;
    [SerializeField] float deadZone = .5f;
    [SerializeField] float fallSpeed = 5f;
    [SerializeField] float groundHeight = 1.5f;

    public Vector2 stickDir = Vector2.zero;
    private float turnAngle = 0;
    private float turnLastAngle = 0;
    public float turningSpeed = 0;
    public float targetSpeed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (useMouse)
        {
            stickDir = Camera.main.ScreenToViewportPoint(Input.mousePosition) * 2 - new Vector3(1, 1, 0);
        }
        else if (isLeftStick)
        {
            stickDir.x = Input.GetAxisRaw("Horizontal");
            stickDir.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            stickDir.x = Input.GetAxisRaw("Horizontal2");
            stickDir.y = Input.GetAxisRaw("Vertical2");
        }

        if (!useMouse && stickDir.magnitude < deadZone)
        {
            stickDir = Vector2.zero;
            turningSpeed = 0;
            turnLastAngle = 0;
        }
        else
        {
            turnAngle = Mathf.Atan2(-stickDir.y, stickDir.x) * Mathf.Rad2Deg;
            turningSpeed = turnLastAngle - turnAngle;
            if (turningSpeed > 180) turningSpeed -= 360;

            turnLastAngle = transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, turnAngle, 0);
        }

        if (turningSpeed == 0)
        {
            transform.Translate(new Vector3(0, -fallSpeed * Time.deltaTime), 0);
        }
        else
        {
            transform.Translate(new Vector3(0, (Mathf.Abs(turningSpeed) - targetSpeed) / fallSpeed * Time.deltaTime), 0);
        }

        if (transform.position.y <= groundHeight)
        {
            transform.position = new Vector3(0, groundHeight, 0);
        }
    }
}
