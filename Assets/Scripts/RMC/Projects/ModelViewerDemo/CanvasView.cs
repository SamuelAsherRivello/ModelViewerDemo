using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RMC.Projects.ModelViewerDemo
{
	public class CanvasView : MonoBehaviour
	{
		//  Properties ------------------------------------------
		public List<Button> AnimationButtons { get { return _animationButtons; } }
		public List<Button> ColorButtons { get { return _colorButtons; } }

		//  Fields ----------------------------------------------
		[SerializeField]
		private List<Button> _animationButtons = null;

		[SerializeField]
		private List<Button> _colorButtons = null;
	}
}