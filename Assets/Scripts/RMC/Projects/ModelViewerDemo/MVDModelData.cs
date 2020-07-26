using System.Collections.Generic;
using UnityEngine;

namespace RMC.Projects.ModelViewerDemo
{
	[CreateAssetMenu (fileName = "MVDModelData", menuName = "RMC/Projects/ModelViewerDemo/MVDModelData", order = 0)]
	public class MVDModelData : ScriptableObject
	{
		//  Fields ----------------------------------------------
		public List<CharacterView> CharacterViews { get { return _characterViews; } }
		public Vector2 RotationSpeed { get { return _rotationSpeed; } }

      public List<Color> BackgroundColors { get { return _backgroundColors; } }

      //  Fields ----------------------------------------------
      [SerializeField]
		private List<CharacterView> _characterViews = null;

		[SerializeField]
		private List<Color> _backgroundColors = null;

		[SerializeField]
		private Vector2 _rotationSpeed = new Vector2(1, 1);

	}
}