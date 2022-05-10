

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンフィグ。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** Scene_Base
	*/
	public interface Scene_Base
	{
		/** [BlueBack.Scene.Scene_Base]シーン名。
		*/
		string GetSceneName();

		/** [BlueBack.Scene.Scene_Base]シーン変更。
		*/
		void SceneChange();

		/** [BlueBack.Scene.Scene_Base]UnityUpdate
		*/
		void UnityUpdate(BlueBack.Scene.PhaseType a_phase);

		/** [BlueBack.Scene.Scene_Base]UnityFixedUpdate
		*/
		void UnityFixedUpdate(BlueBack.Scene.PhaseType a_phase);

		/** [BlueBack.Scene.Scene_Base]UnityLateUpdate
		*/
		void UnityLateUpdate(BlueBack.Scene.PhaseType a_phase);
	}
}

