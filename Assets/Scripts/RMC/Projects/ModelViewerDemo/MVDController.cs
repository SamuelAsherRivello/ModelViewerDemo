using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace RMC.Projects.ModelViewerDemo
{
   public class MVDController : MonoBehaviour
   {
      //  Properties ------------------------------------------

      //  Fields ----------------------------------------------
      [SerializeField]
      private MVDView _mvdView = null;

      [SerializeField]
      private MVDModel _mvdModel = null;

      private bool _isPressed = false;

      //  Initialization --------------------------------------
      public void Initialize()
      {
         _mvdView.OnAnimationChange.AddListener(MVDView_OnAnimationChanged);
         _mvdView.OnColorChange.AddListener(MVDView_OnColorChanged);

         SetCharacterView(0);
         MVDView_OnAnimationChanged(0);
      }

      //  Methods ---------------------------------------------
      private void SetCharacterView(int index)
      {
         _mvdView.SetCharacterView(_mvdModel.MVDModelData.CharacterViews[index]);
      }

      //  Event Handlers --------------------------------------
      private void MVDView_OnAnimationChanged(int index)
      {
         Color color = _mvdModel.MVDModelData.BackgroundColors[index];

         _mvdView.SetBackgroundColor(color);
         _mvdView.SetCharacterAnimation(index);
      }

      private void MVDView_OnColorChanged(int index)
      {
         _mvdView.SetCharacterColor(index);
      }

      public void OnPointerPositionChanged (CallbackContext context)
      {
         if (_isPressed)
         {
            Vector2 positionDelta = context.ReadValue<Vector2>();

            Vector2 positionDeltaWithSpeed = new Vector2(
               positionDelta.normalized.x * _mvdModel.MVDModelData.RotationSwipeSpeed.x,
               positionDelta.normalized.y * _mvdModel.MVDModelData.RotationSwipeSpeed.y);

            if (positionDelta.magnitude < 10)
            {
               _mvdView.RotateCharacterBy(new Vector3(positionDeltaWithSpeed.y, -positionDeltaWithSpeed.x, 0),
                  _mvdModel.MVDModelData.RotationDeltaSpeed);
            }
         }
      }

      public void OnPointerPressed(CallbackContext context)
      {
         _isPressed = context.control.IsPressed();
      }
   }
}
