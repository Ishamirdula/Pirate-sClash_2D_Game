using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // item data
    public string itemName;
    //public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    //item slot
    //[SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    //Item Description Slot
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;
    
    
    public GameObject selectedShader;
    public bool thisItemSelected;
    private Item item;



    private void Start()
    {
        item = GameObject.Find("Sprite").GetComponent<Item>();

    }

    // int quantity,
    public void AddItem(string itemName, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        //this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true; 


        //quantityText.text = quantity.ToString();
        //quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      if(eventData.button == PointerEventData.InputButton.Left)
      {
            OnLeftClick();
      }
      if (eventData.button == PointerEventData.InputButton.Right)
      {
            OnRightClick();
      }
    }

    public void OnLeftClick() 
    {
        
            this.item.DeselectAllSlots();
           

            selectedShader.SetActive(true);
            thisItemSelected = true;
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
            if (itemDescriptionImage.sprite == null)
                itemDescriptionImage.sprite = emptySprite;
        

    } 

    public void OnRightClick()
    {
       
    }


}
