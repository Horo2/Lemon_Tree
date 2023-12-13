using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cell : MonoBehaviour
{
    public Material litMaterial; // Material for the lit cell
    public Material unlitMaterial; // Material for the unlit cell

    public bool isLit = false;
    private MeshRenderer meshRenderer;
    private XRSimpleInteractable interactable;
    private Transform originalPos;


    
    public Action OnCellChanged { get; internal set; }

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        interactable = GetComponent<XRSimpleInteractable>();
        
        interactable.firstHoverEntered.AddListener(OnHoverEnter);
        interactable.lastHoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(OnSelectEnter);
        interactable.selectExited.AddListener(OnSelectExited);
    }


    private void Start()
    {
        originalPos = this.gameObject.transform;
        
    }

    private void Update()
    {
        transform.position = originalPos.position;
    }

    private void OnHoverEnter(HoverEnterEventArgs arg0)
    {
        // Highlight the cell or provide feedback when hovered in VR
        // Example: Change scale, color, or add a glow effect
        // This method is called when the controller hovers over the cell
    }

    private void ToggleCell()
    {
        isLit = !isLit;
        meshRenderer.material = isLit ? litMaterial : unlitMaterial;
        OnCellChanged?.Invoke();
        
        
    }

    private void OnHoverExit(HoverExitEventArgs arg0)
    {
        // Reset the visual feedback when the hover ends
        // This method is called when the controller stops hovering over the cell
    }

    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        // Toggle the cell when it's selected (e.g., grabbed or touched)
        interactable.interactionLayers = LayerMask.GetMask(); // Set an empty layer mask
        ToggleCell();
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // Re-enable grabbing and movement
        interactable.interactionLayers = LayerMask.GetMask("Default"); // Set the default layer
    }
}