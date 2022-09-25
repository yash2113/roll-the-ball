using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class playerComponent : MonoBehaviour
{
    public float speed = 0f;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public TextMeshProUGUI countText;
    public GameObject winTextMessage;


    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextMessage.SetActive(false);
    }

    void SetCountText()
    {
        countText.text="Count"+count.ToString();
        if(count>=12)
        {
            winTextMessage.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

     void OnMove(InputValue movementValue )
    {
        Vector2 movementVector=movementValue.Get<Vector2>();
        movementX=movementVector.x;
        movementY=movementVector.y;
    }

     void FixedUpdate()
    {
      Vector3 movement=new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement*speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

}
