

/** BlueBack.Scene.Samples.SetNextScene
*/
namespace BlueBack.Scene.Samples.SetNextScene
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** Start
		*/
		private void Start()
		{
			UnityEngine.GameObject.DontDestroyOnLoad(UnityEngine.GameObject.Find("Canvas"));
			UnityEngine.GameObject.Find("Image").GetComponent<UnityEngine.UI.Image>().material.SetFloat("visible",1.0f);

			UnityEngine.GameObject.DontDestroyOnLoad(this.gameObject);
			BlueBack.Scene.Scene t_scene = new BlueBack.Scene.Scene();

			t_scene.SetNextScene(
				new SceneA(t_scene),
				new ChangeAction_Item_Base[]{
					//シーンロード開始。
					BlueBack.Scene.ChangeAction_SingleLoaRequestNextUnityScene.CreateActionBox(false),
					//シーンロード待ち。
					BlueBack.Scene.ChangeAction_WaitActivationNextUnityScene.CreateActionBox(0),
				}
			);
		}
	}
}

