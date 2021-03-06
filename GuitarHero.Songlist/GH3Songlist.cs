using GuitarHero.Setlist;
using GuitarHero.Tier;
using ns14;
using ns18;
using ns20;
using ns21;
using ns22;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GuitarHero.Songlist
{
	[Serializable]
	public class GH3Songlist : SortedDictionary<string, GH3Song>
	{
		[NonSerialized]
		public Dictionary<int, GH3Setlist> gh3SetlistList = new Dictionary<int, GH3Setlist>();

		[NonSerialized]
		public Dictionary<int, GHLink> dictionary_1 = new Dictionary<int, GHLink>();

		[NonSerialized]
		public zzCollection214<string, int> class214_0 = new zzCollection214<string, int>();

		public int CustomBitMask;

		public bool HideUsed;

		public bool HideUnEditable;

		public static List<int> IgnoreSongs = new List<int>(new int[]
		{
			QbSongClass1.smethod_9("synctest"),
			QbSongClass1.smethod_9("mutetest"),
			QbSongClass1.smethod_9("synctestplaytoaudio"),
			QbSongClass1.smethod_9("synctestaudioandvisual"),
			QbSongClass1.smethod_9("tutorial_1b"),
			QbSongClass1.smethod_9("tutorial_1c"),
			QbSongClass1.smethod_9("tutorial_1d"),
			QbSongClass1.smethod_9("tutorial_1e"),
			QbSongClass1.smethod_9("tutorial_2a"),
			QbSongClass1.smethod_9("tutorial_2b"),
			QbSongClass1.smethod_9("tutorial_2c"),
			QbSongClass1.smethod_9("tutorial_3a"),
			QbSongClass1.smethod_9("tutorial_3b"),
			QbSongClass1.smethod_9("tutorial_3c"),
			QbSongClass1.smethod_9("tutorial_3d"),
			QbSongClass1.smethod_9("tutorial_4c"),
			QbSongClass1.smethod_9("tutorial_4e"),
			QbSongClass1.smethod_9("credits"),
			QbSongClass1.smethod_9("kingsandqueenscredits"),
			QbSongClass1.smethod_9("timrapptest")
		});

		public GH3Songlist(zzGenericNode1 class308_0, GH3Songlist gh3Songlist_0)
		{
			this.findEditableSongs(class308_0, gh3Songlist_0);
		}

		public void Add(GH3Song gh3Song_0)
		{
			if (!base.ContainsKey(gh3Song_0.getSongName()))
			{
				base.Add(gh3Song_0.getSongName(), gh3Song_0);
				QbSongClass1.smethod_9(gh3Song_0.getSongName());
			}
		}

		public void method_0(GH3Song gh3Song_0, bool bool_0)
		{
			if (!base.ContainsKey(gh3Song_0.getSongName()))
			{
				base.Add(gh3Song_0.getSongName(), gh3Song_0);
				QbSongClass1.smethod_9(gh3Song_0.getSongName());
				return;
			}
			if (base[gh3Song_0.getSongName()].isEditable() && bool_0)
			{
				base[gh3Song_0.getSongName()].vmethod_0(gh3Song_0);
			}
		}

		public List<int> method_1(GH3Song gh3Song_0)
		{
			List<int> list = new List<int>();
			foreach (int current in this.gh3SetlistList.Keys)
			{
				foreach (GH3Tier current2 in this.gh3SetlistList[current].method_0())
				{
					if (current2.method_0().Contains(gh3Song_0))
					{
						current2.method_0().Remove(gh3Song_0);
						if (!list.Contains(current))
						{
							list.Add(current);
						}
					}
				}
			}
			base.Remove(gh3Song_0.getSongName());
			return list;
		}

		public GH3Song[] getSongs()
		{
			List<GH3Song> songList = new List<GH3Song>(base.Values);
			if (songList.Count != 0)
			{
				if (this.HideUsed)
				{
					foreach (GH3Setlist current in this.gh3SetlistList.Values)
					{
						foreach (GH3Tier current2 in current.method_0())
						{
							foreach (GH3Song current3 in current2.method_0())
							{
								if (songList.Contains(current3))
								{
									songList.Remove(current3);
								}
							}
						}
					}
				}
				if (this.HideUnEditable)
				{
					foreach (GH3Song current4 in base.Values)
					{
						if (!current4.isEditable())
						{
							songList.Remove(current4);
						}
					}
				}
				foreach (GH3Song current5 in base.Values)
				{
					if (!current5.isVisible())
					{
						songList.Remove(current5);
					}
				}
			}
			return songList.ToArray();
		}

		public bool method_3(string string_0)
		{
			return base.ContainsKey(string_0);
		}

		public GH3Setlist method_4(string string_0, StructurePointerRootNode class266_0)
		{
			GH3Setlist gH3Setlist = new GH3Setlist(class266_0.method_7(), this);
			gH3Setlist.method_3(string_0);
			this.gh3SetlistList.Add(class266_0.int_0, gH3Setlist);
			return gH3Setlist;
		}

		public GHLink method_5(string string_0, StructurePointerRootNode class266_0)
		{
			GHLink gHLink = new GHLink(string_0, class266_0.method_7());
			this.dictionary_1.Add(class266_0.int_0, gHLink);
			return gHLink;
		}

		public void method_6(StructureArrayNode class292_0)
		{
			foreach (StructureHeaderNode @class in class292_0.Nodes)
			{
				int num = @class.method_5<TagStructureNode>(new TagStructureNode("tag")).method_10();
				if (this.dictionary_1.ContainsKey(num))
				{
					this.class214_0.Add(@class.method_5<UnicodeStructureNode>(new UnicodeStructureNode("text")).method_8(), num);
				}
			}
		}

		public StructureArrayNode method_7()
		{
			StructureArrayNode @class = new StructureArrayNode();
			foreach (string current in this.class214_0.Keys)
			{
				@class.method_3(new StructureHeaderNode(new List<zzUnkNode294>
				{
					new TagStructureNode("tag", this.class214_0[current]),
					new UnicodeStructureNode("text", current)
				}));
			}
			return @class;
		}

		public string method_8(int int_0)
		{
			foreach (int current in this.dictionary_1.Keys)
			{
				if (this.dictionary_1[current].setlist == int_0)
				{
					return this.class214_0.method_0(current);
				}
			}
			return "No Name";
		}

		public int method_9(string string_0)
		{
			return this.dictionary_1[this.class214_0[string_0]].setlist;
		}

		public int method_10(int int_0)
		{
			return this.dictionary_1[int_0].setlist;
		}

		public GH3Setlist method_11(int int_0)
		{
			return this.gh3SetlistList[this.dictionary_1[int_0].setlist];
		}

		public void findEditableSongs(zzGenericNode1 class308_0, GH3Songlist gh3Songlist_0)
		{
			StructureHeaderNode @class = class308_0.method_5<StructurePointerRootNode>(new StructurePointerRootNode("permanent_songlist_props")).method_7();
			bool flag = class308_0.method_5<TagStructureNode>(new TagStructureNode("band")) != null;
			base.Clear();
			foreach (StructurePointerNode class2 in @class.Nodes)
			{
				GH3Song gH3Song = flag ? new GHASong(class2) : new GH3Song(class2);
				if (gh3Songlist_0 != null)
				{
					gH3Song.setEditable(!gh3Songlist_0.method_3(gH3Song.getSongName()));
				}
				gH3Song.setVisible(!GH3Songlist.IgnoreSongs.Contains(class2.int_0));
				this.Add(gH3Song);
			}
		}

		public void method_13(zzGenericNode1 class308_0)
		{
			List<int> list = new List<int>();
			List<zzUnkNode294> list2 = new List<zzUnkNode294>();
			foreach (string current in base.Keys)
			{
				list.Add(QbSongClass1.smethod_9(current));
				list2.Add(base[current].vmethod_5());
			}
			((TagArray)class308_0.method_5<ArrayPointerRootNode>(new ArrayPointerRootNode("gh3_songlist")).method_7()).method_12(list);
			class308_0.method_5<StructurePointerRootNode>(new StructurePointerRootNode("permanent_songlist_props")).method_7().method_9(list2);
		}
	}
}
