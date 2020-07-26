using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RMC.Projects.ModelViewerDemo
{
	public class MVDView : MonoBehaviour
	{

		//  Fields ----------------------------------------------
		public UnityEvent<int> OnAnimationChange = new UnityEvent<int>();
		public UnityEvent<int> OnColorChange = new UnityEvent<int>();

		//  Fields ----------------------------------------------
		[SerializeField]
		private Transform _characterViewParent = null;

		[SerializeField]
		private BackgroundView _backgroundView = null;

		[SerializeField]
		private CanvasView _canvasView = null;

		private CharacterView _characterView = null;
		private List<Renderer> _backgroundRenderers = null;

		//  Initialization ---------------------------------------
		private void Initialize ()
		{
			for (int i = 0; i <_canvasView.AnimationButtons.Count; i++)
         {
				Button animationButton = _canvasView.AnimationButtons[i];

				int index = i;
				animationButton.onClick.AddListener(() =>
				  {
					  CanvasView_OnAnimationButtonClicked(index);
				  });
			}

			for (int i = 0; i < _canvasView.ColorButtons.Count; i++)
			{
				Button colorButton = _canvasView.ColorButtons[i];

				int index = i;
				colorButton.onClick.AddListener(() =>
				{
					CanvasView_OnColorButtonClicked(index);
				});
			}

			_backgroundRenderers = _backgroundView.GetComponentsInChildren<Renderer>().ToList<Renderer>();

		}

      //  Unity Methods ---------------------------------------
      protected void Awake()
		{
			Initialize();
		}

		//  Methods ---------------------------------------------
		public void SetCharacterView(CharacterView characterViewPrefab)
		{
			_characterViewParent.transform.position = new Vector3(0, 0, 0);
			_characterViewParent.transform.localScale = new Vector3(1, 1, 1);
			_characterViewParent.transform.rotation = Quaternion.identity;

			_characterView = Instantiate<CharacterView>(characterViewPrefab);
			_characterView.transform.SetParent(_characterViewParent);

			// Adjust to accomodate various sources/artists
			_characterView.transform.Rotate(_characterView.DefaultRotation);
			_characterView.transform.localScale = _characterView.DefaultScale;
			_characterView.transform.position = _characterView.DefaultPosition;
		}

		public void SetCharacterColor(int index)
		{
			_characterView.SetCharacterColor(index);

		}

		public void SetBackgroundColor(Color color)
		{
			_backgroundView.SetBackgroundColor(color);
		}

		public void RotateCharacterBy(Vector3 rotation)
		{
			_characterViewParent.Rotate(rotation, Space.World);
		}

		//  Event Handlers  --------------------------------------
		private void CanvasView_OnAnimationButtonClicked(int index)
		{
			OnAnimationChange.Invoke(index);
		}

		private void CanvasView_OnColorButtonClicked(int index)
		{
			OnColorChange.Invoke(index);
		}
	}
}