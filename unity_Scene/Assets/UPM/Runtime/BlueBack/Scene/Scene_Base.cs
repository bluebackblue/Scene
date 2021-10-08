

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief コンフィグ。
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

		/** [BlueBack.Scene.Scene_Base]前シーン。終了。初回。
		*/
		void BeforeSceneEndFirst();

		/** [BlueBack.Scene.Scene_Base]前シーン。終了。
		*/
		void BeforeSceneEnd();

		/** [BlueBack.Scene.Scene_Base]前シーン。終了。ラスト。
		*/
		void BeforeSceneEndLast();

		/** [BlueBack.Scene.Scene_Base]カレントシーン。開始。初回。
		*/
		void CurrentSceneStartFirst();

		/** [BlueBack.Scene.Scene_Base]カレントシーン。開始。

			a_is_sceneloadend	: シーンの読み込みが完了したかどうか。 
			return == true		: CurrentSceneRunningへの遷移を許可。

		*/
		bool CurrentSceneStart(bool a_is_sceneloadend);

		/** [BlueBack.Scene.Scene_Base]カレントシーン。実行。

			return == true : CurrentSceneEndFirstへの遷移を許可。

		*/
		bool CurrentSceneRunning();

		/** [BlueBack.Scene.Scene_Base]カレントシーン。終了。初回。
		*/
		void CurrentSceneEndFirst();

		/** [BlueBack.Scene.Scene_Base]カレントシーン。終了。

			return == true : シーン遷移を許可。

		*/
		bool CurrentSceneEnd();

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		void UnityUpdate();

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		void UnityLateUpdate();

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		void UnityFixedUpdate();
	}
}

