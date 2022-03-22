using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    private ActionBasedController controller;
    [SerializeField] private Hand hand;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    void Update()
    {
        hand.setGrip(controller.selectAction.action.ReadValue<float>());
        hand.setTrigger(controller.activateAction.action.ReadValue<float>());

    }
}
