using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Wiki_Hitler
{
	class DataProcesor
	{

		private List<string> Names = new List<string>();
		private List<string> Links = new List<string>();

		private Root Data = new Root();

		IDataWorker dataWorker;
		public DataProcesor(IDataWorker _dataWorker)
		{
			Data = JsonConvert.DeserializeObject<Root>(_dataWorker.GetData());
			dataWorker = _dataWorker; // выглядит както не очень


			foreach (var item in Data.item)
			{
				Names.Add(item.name);
				foreach (var link in item.links)
				{
					Links.Add(link);
				}
			}
			DublClean(ref Links);
		}

		public void ProcesNewData(string _name, List<string> _links)
		{
			//переделать для проверки только совпадений?


			Names.Add(_name);
			foreach (var item in _links)
			{
				Links.Add(item);
			}

			ItemHitlerJson itemHitler = new ItemHitlerJson() { name = _name, links = _links, layer = 99 };

			foreach (var link in _links)
			{

				if (Names.Exists(x => x.Equals(link)))
				{
					foreach (var itemH in Data.item)
					{
						if (itemH.name == link)
						{
							if (itemH.layer + 1 < itemHitler.layer)
							{
								itemHitler.layer = itemH.layer + 1;
							}
						}
					}

					break;
				}

			}
			Data.item.Add(itemHitler);
			System.Console.WriteLine("procesed");

		}

		public void PackData()
		{

			DataLayerCheker();
			string test = JsonConvert.SerializeObject(Data);

			dataWorker.SafeData(test);
		}

		void DataLayerCheker()
		{
			//как-то сильно много вложености

			foreach (var item in Data.item)
			{
				foreach (var link in item.links)
				{
					foreach (var itemCheck in Data.item)
					{
						if (itemCheck.name == link)
						{
							if (itemCheck.layer + 1 < item.layer)
							{
								item.layer = itemCheck.layer + 1;
							}
						}
					}
				}
			}
		}

		public List<string> GetPureLinks()
		{

			List<string> temp = new List<string>();
            if (Links.Count > 100)
            {
				temp = Links.GetRange(0, 99);
			}
            else
            {
				temp.AddRange(Links);
            }
			temp.RemoveAll(item => Names.Contains(item));

			return temp;

		}

		public void GetPureLinks(ref List<string> dirtyList)
		{
			DublClean( ref dirtyList);
			dirtyList.RemoveAll(item => Names.Contains(item));
			System.Console.WriteLine("\n\nlink purefide \n\n");
		}
		
		void DublClean (ref List<string> list)
		{
			List <string> temp = list.Distinct().ToList();
			list.Clear();
			list.AddRange(temp);
			
		}

	}
}
