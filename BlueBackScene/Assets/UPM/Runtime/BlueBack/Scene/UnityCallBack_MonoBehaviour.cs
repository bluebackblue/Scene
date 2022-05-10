

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** UnityCallBack_MonoBehaviour
	*/
	public sealed class UnityCallBack_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** unitycallback
		*/
		public UnityCallBack_Base unitycallback;

		/** Update
		*/
		private void Update()
		{
			if(this.unitycallback != null){
				this.unitycallback.UnityUpdate();
			}
		}

		/** LateUpdate
		*/
		private void FixedUpdate()
		{
			if(this.unitycallback != null){
				this.unitycallback.UnityFixedUpdate();
			}
		}

		/** LateUpdate
		*/
		private void LateUpdate()
		{
			if(this.unitycallback != null){
				this.unitycallback.UnityLateUpdate();
			}
		}
	}
}

