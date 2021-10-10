

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** CallBack_MonoBehaviour
	*/
	public sealed class CallBack_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** scene
		*/
		public Scene scene;

		/** Update
		*/
		private void Update()
		{
			this.scene.OnUnityUpdate();
		}

		/** LateUpdate
		*/
		private void FixedUpdate()
		{
			this.scene.OnUnityFixedUpdate();
		}

		/** LateUpdate
		*/
		private void LateUpdate()
		{
			this.scene.OnUnityLateUpdate();
		}
	}
}

