using UnityEngine;

namespace RMC.Projects.ModelViewerDemo
{
	public class MVDModel : MonoBehaviour
	{
		//  Fields ----------------------------------------------
		public MVDModelData MVDModelData { get { return _mvdModelData; } }

		//  Fields ----------------------------------------------
		[SerializeField]
		private MVDModelData _mvdModelData = null;
	}
}