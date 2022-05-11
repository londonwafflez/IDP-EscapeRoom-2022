// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
 
// public class ColorChange : MonoBehaviour {
//     PaintingScript paintingScript;

//     public int treeIdentity;
//     public Sprite oldTree;
//     public Sprite newTree;
//     SpriteRenderer spriteRenderer;

//     void Start() {
//         spriteRenderer = GetComponent<SpriteRenderer>();
//         //get trees 
//         for (int i = 0; i < 8; i++) {
//             trees[i] = GameObject.Find("Tree" + i);
//             trees[i].SetActive(false);
//         }
//     }

//     void OnMouseDown() {
//         if (spriteRenderer.sprite = oldTree) {
//             spriteRenderer.sprite = newTree; 
//         } else {
//             spriteRenderer.sprite = oldTree; 
//         }

//         paintingScript.treeClicked(treeIdentity);
//     }
// }