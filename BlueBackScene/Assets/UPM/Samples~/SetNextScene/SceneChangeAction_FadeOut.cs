

/** BlueBack.Scene.Samples.SetNextScene
*/
namespace BlueBack.Scene.Samples.SetNextScene
{
	/** フェードアウト。
	*/
	public sealed class SceneChangeAction_FadeOut : BlueBack.Scene.ChangeAction_Base<SceneChangeAction_FadeOut.ID>
	{
		/** ID
		*/
		public enum ID{Default=0}

		/** CreateActionBox
		*/
		public static ChangeAction_Box_Base CreateActionBox()
		{
			return new ChangeAction_Box<SceneChangeAction_FadeOut.ID>(new SceneChangeAction_FadeOut(),SceneChangeAction_FadeOut.ID.Default);
		}

		/** time
		*/
		public float time;

		/** constructor
		*/
		private SceneChangeAction_FadeOut()
		{
		}

		/** [Action_Base<ID>]Change
		*/
		public void Change(SceneChangeAction_FadeOut.ID a_id,Scene a_scene)
		{
			//time
			this.time = UnityEngine.Time.realtimeSinceStartup;
		}

		/** [Action_Base<ID>]Action

			return == true : 完了。

		*/
		public bool Action(SceneChangeAction_FadeOut.ID a_id,Scene a_scene)
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

