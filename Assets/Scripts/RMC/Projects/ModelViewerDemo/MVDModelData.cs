using System.Collections.Generic;
using UnityEngine;

namespace RMC.Projects.ModelViewerDemo
{
	[CreateAssetMenu (fileName = "MVDModelData", menuName = "RMC/Projects/ModelViewerDemo/MVDModelData", order = 0)]
	public class MVDModelData : ScriptableObject
	{
		//  Fields ----------------------------------------------
		public List<CharacterView> CharacterViews { get { return _characterViews; } }
      public List<Color> BackgroundColors { get { return _backgroundColors; } }

		public Vector2 RotationSwipeSpeed { get { return _rotationSwipeSpeed; } }
		public float RotationDeltaSpeed { get { return _rotationDeltaSpeed; } }

      //  Fields ----------------------------------------------
      [SerializeField]
		private List<CharacterView> _characterViews = null;

		[SerializeField]
		private List<Color> _backgroundColors = null;

		[SerializeField]
		private Vector2 _rotationSwipeSpeed = new Vector2(1, 1);

		[SerializeField]
		private float _rotationDeltaSpeed = 0.01f;

	}
}