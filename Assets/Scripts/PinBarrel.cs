using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PinBarrel : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private float cooldown = 0.25f;
    [SerializeField] private float grabThreshold = 0.5f;

    private readonly HashSet<XRDirectInteractor> _inside = new HashSet<XRDirectInteractor>();
    private readonly Dictionary<XRDirectInteractor, bool> _isGripping = new Dictionary<XRDirectInteractor, bool>();

    private bool _canSpawn = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out XRDirectInteractor interactor))
        {
            _inside.Add(interactor);
            if (!_isGripping.ContainsKey(interactor))
                _isGripping[interactor] = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out XRDirectInteractor interactor))
        {
            _inside.Remove(interactor);
            _isGripping[interactor] = false;
        }
    }

    private void Update()
    {
        if (!_canSpawn) return;

        foreach (var interactor in _inside)
        {
            if (interactor == null) continue;

            // If holding something, skip
            if (interactor.interactablesSelected.Count > 0)
                continue;

            // Read input through XRInputButtonReader
            float value = interactor.selectInput.ReadValue();
            bool isGrippingNow = value > grabThreshold;
            bool wasGripping = _isGripping[interactor];

            if (isGrippingNow && !wasGripping)
            {
                SpawnInHand(interactor);
                _isGripping[interactor] = true;
            }
            else if (!isGrippingNow && wasGripping)
            {
                _isGripping[interactor] = false;
            }
        }
    }

    private void SpawnInHand(XRDirectInteractor hand)
    {
        if (!_canSpawn) return;
        if (itemPrefab == null)
        {
            Debug.LogWarning("[BarrelItemSpawner] Item Prefab not assigned.");
            return;
        }

        _canSpawn = false;
        StartCoroutine(CooldownRoutine());

        Transform t = hand.attachTransform != null ? hand.attachTransform : hand.transform;
        GameObject newItem = Instantiate(itemPrefab, t.position, t.rotation);

        if (!newItem.TryGetComponent(out XRGrabInteractable grab))
        {
            Debug.LogWarning("[BarrelItemSpawner] Spawned object has no XRGrabInteractable.");
            return;
        }

        XRInteractionManager manager = hand.interactionManager;
        if (manager == null)
        {
            manager = FindObjectOfType<XRInteractionManager>();
            if (manager == null)
            {
                Debug.LogWarning("[BarrelItemSpawner] No XRInteractionManager found in scene.");
                return;
            }
        }

        // Force grab using interface-based API
        manager.SelectEnter(
            (IXRSelectInteractor)hand,
            (IXRSelectInteractable)grab
        );
    }

    private IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldown);
        _canSpawn = true;
    }
}
