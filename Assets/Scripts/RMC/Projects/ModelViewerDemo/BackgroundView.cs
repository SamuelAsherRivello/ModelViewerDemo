using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RMC.Projects.ModelViewerDemo
{
	public class BackgroundView : MonoBehaviour
	{
		//  Properties ------------------------------------------

      //  Fields ----------------------------------------------
		private List<Renderer> _renderers = null;

		//  Initialization  -----------------------------------
		private void Initialize()
		{
			_renderers = GetComponentsInChildren<Renderer>().ToList<Renderer>();
		}

		//  Unity Methods ---------------------------------------
		protected void Awake()
		{
			Initialize();
		}

		//  Methods ---------------------------------------------
		public void SetBackgroundColor(Color color)
		{
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