

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** ChangeAction_Box
	*/
	public class ChangeAction_Box<ID> : ChangeAction_Box_Base
	{
		/** instance
		*/
		public ChangeAction_Base<ID> instance;

		/** id
		*/
		public ID id;

		/** constructor
		*/
		public ChangeAction_Box(ChangeAction_Base<ID> a_instance,ID a_id)
		{
			//instance
			this.instance = a_instance;

			//id
			this.id = a_id;
		}

		/** [ChangeAction_Base]Change
		*/
		public void Change(Scene a_scene)
		{
			if(this.instance != null){
				this.instance.Change(this.id,a_scene);
			}
		}

		/** [ChangeAction_Base]Action

			return == true : 完了。

		*/
		public bool Action(Scene a_scene)
		{
			if(this.instance != null){
				return this.instance.Action(this.id,a_scene);
			}
			return true;
		}
	}
}

