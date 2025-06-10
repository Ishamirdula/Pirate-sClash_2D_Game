using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    //[SerializeField] private int quantity;
    [SerializeField] private Sprite itemSprite;

    [TextArea][SerializeField] private string itemDescription;
    private InventoryManager inventoryManager;
    public ItemSlot[] itemSlot;



    void Start()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {    //quantity,
            AddItem(itemName, itemSprite, itemDescription);
            AudioManager.instance.Play("collect");
            Destroy(gameObject);
        }


    }
    // int quantity,
    public void AddItem(string itemName, Sprite itemSprite, string itemDescription)
    {

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            { // quantity,
                itemSlot[i].AddItem(itemName, itemSprite, itemDescription);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < this.itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

}