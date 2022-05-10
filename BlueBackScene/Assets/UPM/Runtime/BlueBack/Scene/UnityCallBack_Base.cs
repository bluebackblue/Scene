

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** UnityCallBack_Base
	*/
	public interface UnityCallBack_Base
	{
		/** [BlueBack.Scene.UnityCallBack_Base]UnityUpdate
		*/
		void UnityUpdate();

		/** [BlueBack.Scene.UnityCallBack_Base]UnityFixedUpdate
		*/
		void UnityFixedUpdate();

		/** [BlueBack.Scene.UnityCallBack_Base]UnityLateUpdate
		*/
		void UnityLateUpdate();
	}
}

