using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RMC.Projects.ModelViewerDemo
{
	public class CharacterView : MonoBehaviour
	{
		//  Properties ------------------------------------------
		public Vector3 DefaultRotation { get { return _defaultRotation; } }
		public Vector3 DefaultScale { get { return _defaultScale; } }
		public Vector3 DefaultPosition { get { return _defaultPosition; } }
		public List<Color> CharacterColors { get { return _characterColors; } }

      //  Fields ----------------------------------------------
      [SerializeField]
		private SimpleAnimation _simpleAnimation = null;

		[SerializeField]
		private Vector3 _defaultRotation = new Vector3();

		[SerializeField]
		private Vector3 _defaultScale = new Vector3(1,1,1);

		[SerializeField]
		private Vector3 _defaultPosition = new Vector3(0, 0, 0);

		[SerializeField]
		private List<AnimationClip> _animationClips = null;

		[SerializeField]
		private List<Color> _characterColors = null;

		private List<Renderer> _renderers = null;

		//  Initialization  -----------------------------------
		private void Initialize()
		{
			_renderers = GetComponentsInChildren<Renderer>().ToList<Renderer>();

			foreach (AnimationClip animationClip in _animationClips)
         {
				_simpleAnimation.AddClip(animationClip, animationClip.name);
			}
		}

		//  Unity Methods ---------------------------------------
		protected void Awake()
		{
			Initialize();
		}

		//  Methods ---------------------------------------------
		public void SetAnimation(int index)
		{
			AnimationClip nextAnimationClip = _animationClips[index];

			_simpleAnimation.Play(nextAnimationClip.name);

			//Debug.Log($"SetAnimation() name={nextAnimationClip.name}.");
		}

		public void SetCharacterColor(int index)
		{
			Color color = CharacterColors[index];

			foreach (Renderer r in _renderers)
			{
				foreach (Material m in r.materials)
				{
					m.SetColor("_Color", color);
				}
			}
		}
	}
}