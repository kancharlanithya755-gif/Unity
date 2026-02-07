
using UnityEngine;

using UnityEngine.InputSystem;
using TMPro;



public class Driver : MonoBehaviour
{
   [SerializeField] float currentSpeed = 10f;
   [SerializeField] float steerSpeed = 40f;
   [SerializeField] float boostSpeed = 10f;
   [SerializeField] float regularSpeed = 5f;

   [SerializeField] TMP_Text boostText;
   void Start()
   {
      boostText.gameObject.SetActive(false);
   }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Boost"))
      {
         currentSpeed = boostSpeed;
         boostText.gameObject.SetActive(true);
         Destroy(collision.gameObject);
      }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.collider.CompareTag("Worldcollision"))
      {
         currentSpeed = regularSpeed;
         boostText.gameObject.SetActive(false);
         
      }
      
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
      float move =0f;
      float steer = 0f;
      
      if (Keyboard.current.upArrowKey.isPressed)
      {
         move = 1f;
      }
      else if (Keyboard.current.downArrowKey.isPressed)
      {
         move = -1f;
      }
      
      if (Keyboard.current.leftArrowKey.isPressed)
      {
         steer = 1f;
      }
      else if (Keyboard.current.rightArrowKey.isPressed)
      {
         steer = -1f;
      }

      float moveAmount =move *currentSpeed * Time.deltaTime;
      float steerAmount =steer *steerSpeed * Time.deltaTime;
    
      transform.Translate(0, moveAmount, 0); 
       transform.Rotate(0, 0, steerAmount);
       
    }
}
