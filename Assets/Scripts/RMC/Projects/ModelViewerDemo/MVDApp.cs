using UnityEngine;

namespace RMC.Projects.ModelViewerDemo
{
	public class MVDApp : MonoBehaviour
	{
		//  Fields ----------------------------------------------
		[SerializeField]
		private MVDController _mvdController = null;

		//  Unity Methods ---------------------------------------
		protected void Awake ()
		{
			_mvdController.Initialize();
		}
	}
}