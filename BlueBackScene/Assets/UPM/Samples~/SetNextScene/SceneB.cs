

/** BlueBack.Scene.Samples.SetNextScene
*/
namespace BlueBack.Scene.Samples.SetNextScene
{
	/** SceneB
	*/
	public sealed class SceneB : BlueBack.Scene.Scene_Base
	{
		/** scene
		*/
		private BlueBack.Scene.Scene scene;

		/** time
		*/
		private float time;

		/** constructor
		*/
		public SceneB(BlueBack.Scene.Scene a_scene)
		{
			this.scene = a_scene;
			this.time = 0.0f;
		}

		/** [BlueBack.Scene.Scene_Base]シーン名。
		*/
		public string GetSceneName()
		{
			return "SceneB";
		}

		/** [BlueBack.Scene.Scene_Base]前シーン。終了。初回。
		*/
		public void BeforeSceneEndFirst()
		{
			UnityEngine.Debug.Log(this.GetType().ToString() + " : BeforeSceneEndFirst");
		}

		/** [BlueBack.Scene.Scene_Base]前シーン。終了。
		*/
		public void BeforeSceneEnd()
		{
			UnityEngine.Debug.Log(this.GetType().ToString() + " : BeforeSceneEnd");
		}

		/** [BlueBack.Scene.Scene_Base]前シーン。終了。ラスト。
		*/
		public void BeforeSceneEndLast()
		{
			UnityEngine.Debug.Log(this.GetType().ToString() + " : BeforeSceneEndLast");
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。開始。初回。
		*/
		public void CurrentSceneStartFirst()
		{
			UnityEngine.Debug.Log(this.GetType().ToString() + " : CurrentSceneStartFirst");
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。開始。

			a_is_sceneloadend	: シーンの読み込みが完了したかどうか。 
			return == true		: CurrentSceneRunningへの遷移を許可。

		*/
		public bool CurrentSceneStart(bool a_is_sceneloadend)
		{
			UnityEngine.Debug.Log(this.GetType().ToString() + " : CurrentSceneStart : " +  a_is_sceneloadend.ToString() + " : " + UnityEngine.Time.deltaTime.ToString());

			if(a_is_sceneloadend == false){
				this.time = 0.0f;
				UnityEngine.GameObject.Find("Image").GetComponent<UnityEngine.UI.Image>().material.SetFloat("visible",1.0f);
			}else{
				this.time += UnityEngine.Time.deltaTime;
				float t_value = UnityEngine.Mathf.Clamp01(1.0f - this.time * 3);
				UnityEngine.GameObject.Find("Image").GetComponent<UnityEngine.UI.Image>().material.SetFloat("visible",t_value);
				if(t_value <= 0.0f){
					this.time = 0.0f;
					return true;
				}
			}

			return false;
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。実行。
		*/
		public bool CurrentSceneRunning()
		{
			return true;
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。終了。初回。
		*/
		public void CurrentSceneEndFirst()
		{
			UnityEngine.Debug.Log(this.GetType().ToString() + " : CurrentSceneEndFirst");
			this.time = 0.0f;
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。終了。
		*/
		public bool CurrentSceneEnd()
		{
			UnityEngine.Debug.Log(this.GetType().ToString() + " : CurrentSceneEnd");

			this.time += UnityEngine.Time.deltaTime;

			float t_value = UnityEngine.Mathf.Clamp01(this.time * 3);
			UnityEngine.GameObject.Find("Image").GetComponent<UnityEngine.UI.Image>().material.SetFloat("visible",t_value);
			if(t_value >= 1.0f){
				return true;
			}
			return false;
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityUpdate()
		{
			UnityEngine.Debug.Log(this.GetType().ToString() + " : UnityUpdate");

			this.time += UnityEngine.Time.deltaTime;

			if(this.time > 1.0f){
				this.scene.SetNextScene(new SceneA(this.scene));
			}
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityLateUpdate()
		{
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityFixedUpdate()
		{
		}
	}
}

