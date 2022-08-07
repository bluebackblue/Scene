

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。変更アクション。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** ChangeAction_Item
	*/
	public sealed class ChangeAction_Item<ID> : ChangeAction_Item_Base
	{
		/** instance
		*/
		public ChangeAction_Base<ID> instance;

		/** id
		*/
		public ID id;

		/** constructor
		*/
		public ChangeAction_Item(ChangeAction_Base<ID> a_instance,ID a_id)
		{
			//instance
			this.instance = a_instance;

			//id
			this.id = a_id;
		}

		/** [ChangeAction_Item_Base]Change
		*/
		public void Change(Scene a_scene)
		{
			if(this.instance != null){
				this.instance.Change(this.id,a_scene);
			}
		}

		/** [ChangeAction_Item_Base]Action

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

