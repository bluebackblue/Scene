

/** Samples.Scene.Exsample
*/
namespace Samples.Scene.Exsample
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** scene
		*/
		private BlueBack.Scene.Scene scene;

		/** canvas_gameobject
		*/
		private UnityEngine.GameObject canvas_gameobject;

		/** Start
		*/
		private void Start()
		{
			UnityEngine.GameObject.DontDestroyOnLoad(UnityEngine.GameObject.Find("Canvas"));
			UnityEngine.GameObject.Find("Image").GetComponent<UnityEngine.UI.Image>().material.SetFloat("visible",1.0f);

			UnityEngine.GameObject.DontDestroyOnLoad(this.gameObject);
			this.scene = new BlueBack.Scene.Scene();
			this.scene.SetNextScene(new SceneA(this.scene));
		}

		/** Update
		*/
		public void Update()
		{
			this.scene.Update();
			this.scene.UnityUpdate();
		}

		/** FixedUpdate
		*/
		public void FixedUpdate()
		{
			this.scene.UnityFixedUpdate();
		}

		/** LateUpdate
		*/
		public void LateUpdate()
		{
			this.scene.UnityLateUpdate();
		}
	}
}

