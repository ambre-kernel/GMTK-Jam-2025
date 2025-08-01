using UnityEngine;

public class HulaController : MonoBehaviour
{
    [SerializeField] float deadZone = 0.5f;
    [SerializeField] float mass = 5f;
    [SerializeField] float groundHeight = 1.5f;
    [SerializeField] float maxHeight = 5f;

    public float turningSpeed = 0;
    public float targetSpeed = 20f;
    public Vector2 stickDir = Vector2.zero;

    private Menu controller;
    private float turnAngle = 0;
    private float turnLastAngle = 0;
    private float gravity = 0;
    private bool isFailing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = FindFirstObjectByType<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.useMouse)
        {
            stickDir = Camera.main.ScreenToViewportPoint(Input.mousePosition) * 2 - new Vector3(1, 1, 0);
        }
        else
        {
            stickDir.x = Input.GetAxisRaw("Horizontal");
            stickDir.y = Input.GetAxisRaw("Vertical");
        }

        if (!isFailing && transform.position.y > maxHeight)
        {
            isFailing = true;
        }
        else
        {
            if (Mathf.Abs(turningSpeed) < 1f || isFailing)
            {
                gravity += 9.81f * Time.deltaTime * 0.5f;
                transform.Translate(new Vector3(0, -gravity * Time.deltaTime, 0));
                gravity += 9.81f * Time.deltaTime * 0.5f;
            }
            else
            {
                float lift = (Mathf.Abs(turningSpeed) - targetSpeed) / mass * Time.deltaTime;
                transform.Translate(new Vector3(0, lift, 0));
                gravity = mass;
            }
        }


        if (transform.position.y <= groundHeight)
        {
            isFailing = false;
            transform.position = new Vector3(0, groundHeight, 0);
        }
    }

    private void FixedUpdate()
    {
        if ((!controller.useMouse && stickDir.magnitude < deadZone) || (controller.useMouse && stickDir.magnitude < deadZone/10f))
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
    }
}
