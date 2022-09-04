

/** BlueBack.Scene.Samples.SetNextScene
*/
namespace BlueBack.Scene.Samples.SetNextScene
{
	/** フェードアウト。
	*/
	public sealed class SceneChangeAction_FadeOut : BlueBack.Scene.ChangeAction.Execute_Base<SceneChangeAction_FadeOut.ID>
	{
		/** ID
		*/
		public enum ID{Default=0}

		/** Create
		*/
		public static ChangeAction.Item_Base Create()
		{
			return new BlueBack.Scene.ChangeAction.Item<SceneChangeAction_FadeOut.ID>(new SceneChangeAction_FadeOut(),SceneChangeAction_FadeOut.ID.Default);
		}

		/** time
		*/
		public float time;

		/** constructor
		*/
		private SceneChangeAction_FadeOut()
		{
		}

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Base<ID>]開始。
		*/
		public void Start(SceneChangeAction_FadeOut.ID a_id,ref BlueBack.Scene.Status a_status)
		{
			//time
			this.time = UnityEngine.Time.realtimeSinceStartup;
		}

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Base<ID>]アクション。

			return == true : 完了。

		*/
		public bool Action(SceneChangeAction_FadeOut.ID a_id,ref BlueBack.Scene.Status a_status)
		{
			float t_delta = UnityEngine.Time.realtimeSinceStartup - this.time;

			float t_value = UnityEngine.Mathf.Clamp01(t_delta * 3);
			UnityEngine.GameObject.Find("Image").GetComponent<UnityEngine.UI.Image>().material.SetFloat("visible",t_value);
			if(t_value >= 1.0f){
				return true;
			}

			return false;
		}
	}
}

