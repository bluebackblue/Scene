

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
		private int scene_index;

		/** fadein_time
		*/
		public bool fadein_flag;
		public float fadein_time;

		/** time
		*/
		private float time;

		/** constructor
		*/
		public SceneB(BlueBack.Scene.Scene a_scene,int a_scene_index)
		{
			//scene
			this.scene = a_scene;
			this.scene_index = a_scene_index;
		}

		/** [BlueBack.Scene.Scene_Base]ユニティーシーン名。取得。
		*/
		public string GetUnitySceneName()
		{
			return "SceneB";
		}

		/** [BlueBack.Scene.Scene_Base]シーンインデックス。取得。

			任意の値。

		*/
		public int GetSceneIndex()
		{
			return this.scene_index;
		}

		/** [BlueBack.Scene.Scene_Base]シーン開始。

			a_prev_scene : 前のシーン。

		*/
		public void SceneStart(BlueBack.Scene.Scene_Base a_prev_scene)
		{
			//fadein
			this.fadein_flag = true;
			this.fadein_time = 0.0f;

			//time
			this.time = UnityEngine.Time.realtimeSinceStartup;
		}

		/** [BlueBack.Scene.Scene_Base]シーン終了。

			a_next_scene : 次のシーン。

		*/
		public void SceneEnd(BlueBack.Scene.Scene_Base a_next_scene)
		{
		}

		/** [BlueBack.Scene.Scene_Base]UnityUpdate
		*/
		public void UnityUpdate(BlueBack.Scene.PhaseType a_phase)
		{
			if(a_phase == PhaseType.Running){
				if(this.fadein_flag == true){
					this.fadein_time += UnityEngine.Time.deltaTime;
					float t_value = UnityEngine.Mathf.Clamp01(3.0f - this.fadein_time * 3);
					UnityEngine.GameObject.Find("Image").GetComponent<UnityEngine.UI.Image>().material.SetFloat("visible",t_value);
					if(t_value <= 0.0f){
						this.fadein_time = 0.0f;
						this.fadein_flag = false;
					}
				}

				float t_delta = UnityEngine.Time.realtimeSinceStartup - this.time;
				if(t_delta >= 3.0f){
					this.scene.SetNextScene(
						new SceneA(this.scene,0),
						new ChangeAction_Item_Base[]{
							//シーンロード開始。
							BlueBack.Scene.ChangeAction_SingleLoadRequestNextUnityScene.Create(false),
							//フェードアウト。
							SceneChangeAction_FadeOut.Create(),
							//シーンロード待ち。
							BlueBack.Scene.ChangeAction_WaitActivationNextUnityScene.Create(0),
						}
					);
				}
			}else{
				//シーン変更中。
			}
		}

		/** [BlueBack.Scene.Scene_Base]UnityFixedUpdate
		*/
		public void UnityFixedUpdate(BlueBack.Scene.PhaseType a_phase)
		{
		}

		/** [BlueBack.Scene.Scene_Base]UnityLateUpdate
		*/
		public void UnityLateUpdate(BlueBack.Scene.PhaseType a_phase)
		{
		}
	}
}

