using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField]
        private UIInventoryItem itemPrefab;

        [SerializeField]
        private RectTransform contentPanel;

        [SerializeField]
        private UIInventoryDescription itemDescription;

        List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

        private void Awake()
        {
            Hide();
            itemDescription.ResetDescription();
        }

        public void InitializeInventoryUI(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                UIInventoryItem uiItem =
                    Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                uiItem.transform.SetParent(contentPanel);
                listOfUIItems.Add(uiItem);
                uiItem.OnItemClicked += HandleItemSelection;
                uiItem.OnItemBeginDrag += HandleBeginDrag;
                uiItem.OnItemDroppedOn += HandleSwap;
                uiItem.OnItemEndDrag += HandleEndDrag;
                uiItem.OnRightMouseBtnClick += HandleShowItemActions;
            }
        }

        private void HandleShowItemActions(UIInventoryItem obj)
        {
        }

        private void HandleEndDrag(UIInventoryItem obj)
        {
        }

        private void HandleSwap(UIInventoryItem obj)
        {
        }

        private void HandleBeginDrag(UIInventoryItem obj)
        {
        }

        private void HandleItemSelection(UIInventoryItem obj)
        {
            Debug.Log(obj.name);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            itemDescription.ResetDescription();
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            
        }
    }

}