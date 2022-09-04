

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** Phase
	*/
	public sealed class Phase : System.IDisposable
	{
		/** constructor
		*/
		public Phase()
		{
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
		}

		/** UnityUpdate
		*/
		public void UnityUpdate(ref Status a_status)
		{
			if(a_status.updatemode == UpdateMode.UnityUpdate){
				this.ManualUpdate(ref a_status);
			}

			if(a_status.scene_current != null){
				a_status.scene_current.UnityUpdate(a_status.step);
			}
		}

		/** UnityFixedUpdate
		*/
		public void UnityFixedUpdate(ref Status a_status)
		{
			if(a_status.updatemode == UpdateMode.UnityFixedUpdate){
				this.ManualUpdate(ref a_status);
			}

			if(a_status.scene_current != null){
				a_status.scene_current.UnityFixedUpdate(a_status.step);
			}
		}

		/** UnityLateUpdate
		*/
		public void UnityLateUpdate(ref Status a_status)
		{
			if(a_status.updatemode == UpdateMode.UnityLateUpdate){
				this.ManualUpdate(ref a_status);
			}

			if(a_status.scene_current != null){
				a_status.scene_current.UnityLateUpdate(a_status.step);
			}
		}

		/** ManualUpdate
		*/
		public void ManualUpdate(ref Status a_status)
		{
			switch(a_status.step){
			case Step.Boot:
				{
					//起動。

					#if(DEF_BLUEBACK_DEBUG_LOG)
					DebugTool.Log(string.Format("{0} : {1}","Inner_Update",a_status.step));
					#endif

					if(a_status.request_scene != null){
						//リクエストあり。

						//scene
						a_status.scene_current = null;
						a_status.scene_next = a_status.request_scene;

						//action
						a_status.changeaction_index = 0;
						a_status.changeaction_list = a_status.request_changeaction_list;

						//request
						a_status.request_scene = null;
						a_status.request_changeaction_list = null;

						//phasetype
						a_status.step = Step.ChangeAction;

						//Change
						if(a_status.changeaction_list != null){
							if(a_status.changeaction_index < a_status.changeaction_list.Length){
								a_status.changeaction_list[a_status.changeaction_index].Start(ref a_status);
							}
						}
					}
				}break;
			case Step.ChangeAction:
				{
					#if(DEF_BLUEBACK_DEBUG_LOG)
					DebugTool.Log(string.Format("{0} : {1}","Inner_Update",a_status.step));
					#endif

					bool t_fix = false;

					//changeaction_list
					if(a_status.changeaction_list != null){
						if(a_status.changeaction_index < a_status.changeaction_list.Length){
							if(a_status.changeaction_list[a_status.changeaction_index].Action(ref a_status) == true){
								a_status.changeaction_index++;
								if(a_status.changeaction_index < a_status.changeaction_list.Length){
									a_status.changeaction_list[a_status.changeaction_index].Start(ref a_status);
								}else{
									t_fix = true;
								}
							}
						}else{
							t_fix = true;
						}
					}else{
						t_fix = true;
					}

					//fix
					if(t_fix == true){
						Scene_Base t_prev_scene = a_status.scene_current;

						//SceneEnd
						if(a_status.scene_current != null){
							a_status.scene_current.SceneEnd(a_status.scene_next);
						}

						//scene
						a_status.scene_current = a_status.scene_next;
						a_status.scene_next = null;

						//action
						a_status.changeaction_index = 0;
						a_status.changeaction_list = null;

						//phasetype
						a_status.step = Step.Running;

						//SceneStart
						a_status.scene_current.SceneStart(t_prev_scene);
					}
				}break;
			case Step.Running:
				{
					if(a_status.request_scene != null){
						//リクエストあり。

						//scene
						a_status.scene_next = a_status.request_scene;

						//action
						a_status.changeaction_index = 0;
						a_status.changeaction_list = a_status.request_changeaction_list;

						//request
						a_status.request_scene = null;
						a_status.request_changeaction_list = null;

						//phasetype
						a_status.step = Step.ChangeAction;

						//Change
						a_status.changeaction_list[a_status.changeaction_index].Start(ref a_status);
					}
				}break;
			}
		}
	}
}

