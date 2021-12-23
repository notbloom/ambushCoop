// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// public class CardAnimationView : MonoBehaviour
// {
//     public DeckAnimator deckAnimator;
//     [Header("Targets")]    
//     public Quaternion rotation;
//     public Vector3 position;
//
//     [Header("Damping")]    
//     public float rotSmooth = .2f;
//     public float _positionDamp = .2f;
//
//     public Vector4 _smoothRotationVelocity;
//     public Vector3 _smoothVelocity;
//
//     [Header("Drag and Drop")]
//     Vector3 positionOnStartDrag;
//     bool dragging = false;
//     public bool playing = false;
//     float distance;
//     [Header("Populate View")]
//     public TextMeshPro title;
//     public TextMeshPro description;
//     public TextMeshPro cost;
//     public ScriptableCard card;
//     void Start()
//     {
//             
//     }
//     public void PopulateView(string cardID)
//     {
//         card = GlobalRepositorySystem.Card(cardID);
//         title.text = card.title;
//         description.text = card.description;
//         cost.text = card.cost.ToString();
//     }
//
//
//     void OnMouseEnter() {
//         deckAnimator.highlightedCard = this;
//     }
//     void OnMouseDown() {
//         if(playing)
//             return;
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        
//         distance = Vector3.Distance(transform.position, Camera.main.transform.position);
//         Vector3 rayPoint = ray.GetPoint(distance);
//
//         positionOnStartDrag = transform.position - rayPoint;
//         dragging = true;        
//     }    
//     void OnMouseDrag()
//     {
//         if(playing)
//             return;
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        
//         Vector3 rayPoint = ray.GetPoint(distance);
//         transform.position = rayPoint + positionOnStartDrag;
//     }
//     void OnMouseUp() {
//         dragging = false;
//     }
//     void OnMouseExit() {
//         if (deckAnimator.highlightedCard == this) {
//             deckAnimator.highlightedCard = null;
//         }
//     }
//     void Update()
//     {
//         if(playing)
//             return;
//
//         if (dragging) {
//             if (transform.position.y >= deckAnimator.playThreshold.position.y) {
//                 deckAnimator.PlayCard(this);
//                 dragging = false;
//             }
//             return;
//         }
//         
//         //rectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
//         if (position != transform.position || rotation.eulerAngles != transform.eulerAngles)
//         {
//             transform.position = Vector3.SmoothDamp(transform.position, position, ref _smoothVelocity, _positionDamp);
//             Quaternion newRotation;
//             newRotation.x = Mathf.SmoothDamp(transform.rotation.x, rotation.x, ref _smoothRotationVelocity.x, rotSmooth);
//             newRotation.y = Mathf.SmoothDamp(transform.rotation.y, rotation.y, ref _smoothRotationVelocity.y, rotSmooth);
//             newRotation.z = Mathf.SmoothDamp(transform.rotation.z, rotation.z, ref _smoothRotationVelocity.z, rotSmooth);
//             newRotation.w = Mathf.SmoothDamp(transform.rotation.w, rotation.w, ref _smoothRotationVelocity.w, rotSmooth);
//
//             transform.rotation = newRotation;
//         }
//     }
//     public void Position(int i, int n, int middleAnchor, float spacing){
//         var x = middleAnchor - (n - 1) / 2 * spacing + i*spacing;
//     }
// }
