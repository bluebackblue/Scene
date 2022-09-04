

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
		/** [BlueBack.Scene.Scene_Base]ユニティーシーン名。取得。
		*/
		string GetUnitySceneName();

		/** [BlueBack.Scene.Scene_Base]シーンインデックス。取得。

			任意の値。

		*/
		int GetSceneIndex();

		/** [BlueBack.Scene.Scene_Base]シーン開始。

			a_prev_scene : 前のシーン。

		*/
		void SceneStart(BlueBack.Scene.Scene_Base a_prev_scene);

		/** [BlueBack.Scene.Scene_Base]シーン終了。

			a_next_scene : 次のシーン。

		*/
		void SceneEnd(BlueBack.Scene.Scene_Base a_next_scene);

		/** [BlueBack.Scene.Scene_Base]UnityUpdate
		*/
		void UnityUpdate(BlueBack.Scene.Step a_step);

		/** [BlueBack.Scene.Scene_Base]UnityFixedUpdate
		*/
		void UnityFixedUpdate(BlueBack.Scene.Step a_step);

		/** [BlueBack.Scene.Scene_Base]UnityLateUpdate
		*/
		void UnityLateUpdate(BlueBack.Scene.Step a_step);
	}
}

