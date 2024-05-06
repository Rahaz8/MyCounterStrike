
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] public Weapon w;
    private Vector2 direction;
    [SerializeField] float speed = 2.7f, sensetivity = 2, jumpheight = 2;
    private Vector2 pointer;
    private Vector3 cam;
    public bool onground = true;
    public bool pause = false;
    public bool crouch = false, walk = false;
    [SerializeField] GameObject menu;
    [SerializeField] Player player;
    [SerializeField] Victory v;

    private void Start()
    {
        cam = Camera.main.transform.localEulerAngles;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (pause || player.dead) return;
        var v = speed * (transform.forward * -direction.x + transform.right * direction.y).normalized;
        v.y = rb.velocity.y;
        rb.velocity = v;
        transform.eulerAngles += new Vector3(0, pointer.x * sensetivity, 0);
        cam.x += -pointer.y * sensetivity;
        cam.x = Mathf.Clamp(cam.x, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(cam);
    }
    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        walk = direction != Vector2.zero;
    }
    public void Look(InputAction.CallbackContext context)
    {
        pointer = context.ReadValue<Vector2>();
    }
    public void Crouch(InputAction.CallbackContext context)
    {
        if (pause || player.dead) return;
        if (context.canceled)

        {
            gameObject.GetComponent<CapsuleCollider>().height = 2;
            gameObject.GetComponent<CapsuleCollider>().center = new(0, 0, 0);
            Camera.main.transform.localPosition += new Vector3(0f, 0.5f, 0f);
            crouch = false;
        }
        else if (context.performed)
        {
            gameObject.GetComponent<CapsuleCollider>().height = 1;
            gameObject.GetComponent<CapsuleCollider>().center = new(0, -0.5f, 0);
            Camera.main.transform.localPosition -= new Vector3(0f, 0.5f, 0f);
            crouch = true;
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (pause || player.dead) return;
        if (context.performed && onground)
        {
            onground = false;
            rb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
        }
    }
    public void Fire(InputAction.CallbackContext context)
    {
        if (pause || player.dead) return;
        w.Shoot(context);
    }
    public void Reload(InputAction.CallbackContext context)
    {
        if (pause || player.dead) return;
        if (context.performed) w.Reload();
    }
    public void Pause(InputAction.CallbackContext context)
    {
        
        if (player.dead || (v!=null && v.won) ) return;
        if (context.performed)
        {
            if (pause)
            {
                menu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                pause = false;
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pause = true;
            }
        }
    }
}
