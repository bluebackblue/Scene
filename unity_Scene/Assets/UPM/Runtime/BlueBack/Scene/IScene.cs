

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief コンフィグ。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** IScene
	*/
	public interface IScene
	{
		/** [BlueBack.Scene.IScene]シーン名。
		*/
		string GetSceneName();

		/** [BlueBack.Scene.IScene]前シーン。終了。初回。
		*/
		void BeforeSceneEndFirst();

		/** [BlueBack.Scene.IScene]前シーン。終了。
		*/
		void BeforeSceneEnd();

		/** [BlueBack.Scene.IScene]前シーン。終了。ラスト。
		*/
		void BeforeSceneEndLast();

		/** [BlueBack.Scene.IScene]カレントシーン。開始。初回。
		*/
		void CurrentSceneStartFirst();

		/** [BlueBack.Scene.IScene]カレントシーン。開始。

			a_is_sceneloadend	: シーンの読み込みが完了したかどうか。 
			return == true		: CurrentSceneRunningへの遷移を許可。

		*/
		bool CurrentSceneStart(bool a_is_sceneloadend);

		/** [BlueBack.Scene.IScene]カレントシーン。実行。

			return == true : CurrentSceneEndFirstへの遷移を許可。

		*/
		bool CurrentSceneRunning();

		/** [BlueBack.Scene.IScene]カレントシーン。終了。初回。
		*/
		void CurrentSceneEndFirst();

		/** [BlueBack.Scene.IScene]カレントシーン。終了。

			return == true : シーン遷移を許可。

		*/
		bool CurrentSceneEnd();

		/** [BlueBack.Scene.IScene]更新。
		*/
		void UnityUpdate();

		/** [BlueBack.Scene.IScene]更新。
		*/
		void UnityLateUpdate();

		/** [BlueBack.Scene.IScene]更新。
		*/
		void UnityFixedUpdate();
	}
}

