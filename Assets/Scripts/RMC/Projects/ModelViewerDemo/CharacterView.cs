using System;
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
		private Animator _animator = null;

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

		private AnimatorOverrideController _animatorOverrideController = null;
		private List<Renderer> _renderers = null;

		//  Initialization  -----------------------------------
		private void Initialize()
		{
			_renderers = GetComponentsInChildren<Renderer>().ToList<Renderer>();

			//
			_animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
			_animator.runtimeAnimatorController = _animatorOverrideController;
			SetAnimationIndex(0);

		}

		//  Unity Methods ---------------------------------------
		protected void Awake()
		{
			Initialize();
		}

		//  Methods ---------------------------------------------
		public void SetAnimationIndex(int index)
		{
			AnimationClip nextAnimationClip = _animationClips[index];
			_animatorOverrideController [nextAnimationClip.name] = nextAnimationClip;
			_animator.Play(nextAnimationClip.name);

			Debug.Log("playing: " + nextAnimationClip.name);
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