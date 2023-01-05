using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class controller : MonoBehaviour
{
  [SerializeField]  private Rigidbody rb;
    float movementX;
    float movementY;
    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject goCount;
    //public GameObject winTextObject;
    int count = 0;
    public int max;

    public Transform respawnPoint;
    public MenuController menuController;


    private void Awake()
    {     
        countText = GameObject.Find("count").GetComponent<TextMeshProUGUI>();
        menuController = GameObject.Find("UI").GetComponent<MenuController>();
    }
    private void Update()
    {
        if(transform.position.y < - 10)
        {
            Respawn();
       }
    }
    void start()
    {
        count = 0;
        SetCountText();
        //winTextObject.SetActive(false);
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;   
        
     }

    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= max)
        {
            // Set the text value of your 'winText'
            //winTextObject.SetActive(true);
            menuController.WinGame();
        }
    }




    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("p"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            // Respawn();
            EndGame();

        }
    }
    void Respawn()
    {

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }
    void EndGame()
    {
        menuController.LoseGame();
        gameObject.SetActive(false);
    }
}



