using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBook : MonoBehaviour
{
    public Button book1Button, book2Button, book3Button;
    Inventory m_inventory;
    ShelfTrigger m_shelfTrigger;
    GameObject curBook;

    void Awake()
    {
        m_inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        m_shelfTrigger = GameObject.Find("ShelfTrigger (1)").GetComponent<ShelfTrigger>();
        book1Button.onClick.AddListener(() => ButtonClicked(1));
        book2Button.onClick.AddListener(() => ButtonClicked(2));
        book3Button.onClick.AddListener(() => ButtonClicked(3));
        Debug.Log("Books awake");
    }
    
    void grabBook(int identifier) {
        Debug.Log("Book clicked");
        curBook = GameObject.Find("book" + identifier + "side");
        if (curBook != null)
        {
            curBook.SetActive(false);
            m_inventory.itemGrabbed(int.Parse(curBook.name[4].ToString()) + 4);
            Debug.Log(m_shelfTrigger);
            m_shelfTrigger.changeActiveBooks(int.Parse(curBook.name[4].ToString()) - 1, -1);
        }
    }

    // public void OnBookClick(int identity) {
    //     grabBook(identity);
    // }
    
    void ButtonClicked(int identity)
    {
        grabBook(identity);
    }
}
