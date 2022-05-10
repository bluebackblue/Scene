

/** BlueBack.Scene.Samples.SetNextScene
*/
namespace BlueBack.Scene.Samples.SetNextScene
{
	/** SceneA
	*/
	public sealed class SceneA : BlueBack.Scene.Scene_Base
	{
		/** scene
		*/
		private BlueBack.Scene.Scene scene;

		/** fadein_time
		*/
		public bool fadein_flag;
		public float fadein_time;

		/** time
		*/
		private float time;

		/** constructor
		*/
		public SceneA(BlueBack.Scene.Scene a_scene)
		{
			//scene
			this.scene = a_scene;
		}

		/** [BlueBack.Scene.Scene_Base]シーン名。
		*/
		public string GetSceneName()
		{
			return "SceneA";
		}

		/** [BlueBack.Scene.Scene_Base]シーン変更。
		*/
		public void SceneChange()
		{
			//fadein
			this.fadein_flag = true;
			this.fadein_time = 0.0f;

			//time
			this.time = UnityEngine.Time.realtimeSinceStartup;
		}

		/** [BlueBack.Scene.Scene_Base]UnityUpdate
		*/
		public void UnityUpdate(BlueBack.Scene.PhaseType a_phase)
		{
			if(a_phase == PhaseType.Running){
				//フェードイン。
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
						new SceneB(this.scene),
						new ChangeAction_Item_Base[]{
							//シーンロード開始。
							BlueBack.Scene.ChangeAction_SingleLoaRequestNextUnityScene.Create(false),
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

