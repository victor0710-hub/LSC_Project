using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlaceHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Platform;
    [SerializeField] TextMeshProUGUI Counter;

    [SerializeField] int Level_Allowed_Platforms;

 
    private Vector2 MousePosition;
    private SpriteRenderer SpriteR;

    private bool CanPlaceIt = true;

    
    // Update is called once per frame
    private void Start()
    {
        SpriteR = GetComponent<SpriteRenderer>();

       

    }
    void Update()
    {
        PlaceHolder_Follow();

        if (CanPlaceIt)
        {
            ClickPlacer();
        }
       

        Counter.text = Level_Allowed_Platforms.ToString();

    }

    private void PlaceHolder_Follow()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = MousePosition;
    }
    private void ClickPlacer()
    {
        if(Level_Allowed_Platforms>0 )
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 ClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(Platform, ClickPosition, Quaternion.identity);
                Level_Allowed_Platforms--;
            }
          //  SpriteR.color = new Color32(108, 166, 216, 255);
        }
        else if(Level_Allowed_Platforms<=0)
        {
            SpriteR.color = Color.red;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            CanPlaceIt = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanPlaceIt = true;
    }
}
