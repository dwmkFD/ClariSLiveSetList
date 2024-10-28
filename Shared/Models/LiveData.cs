using MudBlazor;
using System.Reflection.Metadata;

namespace ClariSLiveSetList.Shared.Models
{
    public class LiveData
    {
        public string Title { get; set; }
        public string Place { get; set; }
        public DateTime Date;
        public string AddInfo { get; set; }
        public List<string> SetList = new List<string>();

        public LiveData( string t, string p, DateTime d, string ai, params string[] setlist )
        {
            Title = t;
            Place = p;
            Date = d;
            AddInfo = ai;
            foreach( string sl in setlist )
            {
                SetList.Add( sl );
            }
        }
    }

    public class LiveDataManager
    {
        private List<LiveData> LiveList = new List<LiveData>();

        public List<LiveData>? GetLiveData( string title )
        {
            try {
                var val = LiveList.Where( x => x.Title == title ).ToList();
                return ( val );
            } catch ( Exception e ) {
                return ( null );
            }
        }

        public LiveDataManager()
        {
            LiveList.Add( new LiveData( "ClariS 1st Live ～扉の先へ～", "Zepp Tokyo（東京都）", new DateTime( 2015, 7, 31), "", "reunion", "Clear Sky", "irony", "border", "CLICK", "STEP", "Reflect", "アネモネ", "YUMENOKI", "pastel", "Wake Up", "rainy day", "nexus", "ナイショの話", "ルミナス", "眠り姫", "コイノミ", "encore", "カラフル", "double_encore", "コネクト" ) );
        }
    }

}
