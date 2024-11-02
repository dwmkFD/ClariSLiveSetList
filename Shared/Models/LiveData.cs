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
        public List<string> SetListEncore = new List<string>();
        public List<string> SetListDoubleEncore = new List<string>();

        public LiveData( string t, string p, DateTime d, string ai, params string[] setlist )
        {
            Title = t;
            Place = p;
            Date = d;
            AddInfo = ai;
            bool encore_flg = false;
            bool doubleencore_flg = false;

            foreach( string sl in setlist )
            {
                if (encore_flg == false)
                {
                    if (sl != "encore")
                        SetList.Add(sl);
                    else
                    {
                        encore_flg = true;
                        continue;
                    }
                }
                else if ( doubleencore_flg == false )
                {
                    if ( sl != "double_encore" )
                        SetListEncore.Add(sl);
                    else
                    {
                        doubleencore_flg = true;
                        continue;
                    }
                }
                else
                {
                    SetListDoubleEncore.Add(sl);
                }
            }
        }

        public bool HasTitle( string title )
        {
            foreach ( string sl in SetList )
            {
                if ( title == sl )
                    return ( true );
            }
            foreach ( string sl in SetListEncore )
            {
                if ( title == sl )
                    return ( true );
            }
            foreach ( string sl in SetListDoubleEncore )
            {
                if ( title == sl )
                    return ( true );
            }

            return ( false );
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

        public List<LiveData>? GetLiveData(string title, string place)
        {
            try
            {
                var val = LiveList.Where(x => x.Title == title).ToList();
                return ( val.Where( x => x.Place == place ).ToList() );
            }
            catch (Exception e)
            {
                return (null);
            }
        }

        public List<LiveData>? GetLiveData(string title, string place, DateTime date )
        {
            try
            {
                var val = LiveList.Where(x => x.Title == title).ToList();
                val = val.Where(x => x.Place == place).ToList();
                return ( val.Where( x=> x.Date == date ).ToList() );
            }
            catch (Exception e)
            {
                return (null);
            }
        }

        public List<LiveData>? GetLiveList( string title )
        {
            List<LiveData> retval = new List<LiveData>();
            foreach( LiveData data in LiveList )
            {
                if ( data.HasTitle( title ) )
                    retval.Add( data );
            }

            return ( retval.Count == 0 ? null : retval );
        }

        public LiveDataManager()
        {
            LiveList.Add( new LiveData( "ClariS 1st Live ～扉の先へ～", "Zepp Tokyo（東京都）", new DateTime( 2015, 7, 31), "", "reunion", "Clear Sky", "irony", "border", "CLICK", "STEP", "Reflect", "アネモネ", "YUMENOKI", "pastel", "Wake Up", "rainy day", "nexus", "ナイショの話", "ルミナス", "眠り姫", "コイノミ", "encore", "カラフル", "double_encore", "コネクト" ) );
            LiveList.Add( new LiveData( "ClariS 1st Tour ～夢の1ページ…～", "Zepp Nagoya（愛知県）", new DateTime(2016, 3, 6), "", "本当は", "Prism", "irony", "ハルラ", "カイト", "Dreamin’", "CLICK", "STEP", "border", "pastel", "nexus", "恋磁石", "YUMENOKI", "pieces", "カラフル", "with you", "アネモネ", "プロミス", "サヨナラは言わない", "グラスプ", "ひらひら ひらら", "encore", "ナイショの話", "コネクト" ) );
            LiveList.Add( new LiveData( "ClariS 1st Tour ～夢の1ページ…～", "Zepp Namba（大阪府）", new DateTime(2016, 3, 12), "", "Prism", "irony", "ハルラ", "カイト", "Dreamin’", "CLICK", "STEP", "border", "pastel", "恋磁石", "YUMENOKI", "カラフル", "with you", "アネモネ", "プロミス", "サヨナラは言わない", "ひらひら ひらら", "encore", "ルミナス", "コネクト" ) );
            LiveList.Add( new LiveData( "ClariS 1st Tour ～夢の1ページ…～", "Zepp Tokyo（東京都）", new DateTime(2016, 3, 19), "1日目", "本当は", "Prism", "irony", "ハルラ", "カイト", "Dreamin’", "CLICK", "STEP", "border", "pastel", "nexus", "恋磁石", "YUMENOKI", "pieces", "カラフル", "with you", "アネモネ", "プロミス", "サヨナラは言わない", "グラスプ", "ひらひら ひらら", "encore", "ナイショの話", "コネクト" ) );
            LiveList.Add( new LiveData( "ClariS 1st Tour ～夢の1ページ…～", "Zepp Tokyo（東京都）", new DateTime(2016, 3, 20), "2日目", "本当は", "Prism", "irony", "ハルラ", "カイト", "Dreamin’", "CLICK", "STEP", "border", "pastel", "nexus", "恋磁石", "YUMENOKI", "pieces", "カラフル", "with you", "アネモネ", "プロミス", "サヨナラは言わない", "グラスプ", "ひらひら ひらら", "encore", "コネクト", "reunion", "graduation" ) );
            LiveList.Add( new LiveData( "ClariS 1st HALL CONCERT in パシフィコ横浜国立大ホール ～星に願いを… 月に祈りを…～", "パシフィコ横浜国立大ホール（神奈川県）", new DateTime(2016, 9, 17), "1日目", "コネクト", "CLICK", "STEP", "Clear Sky", "Reflect", "irony", "Prism", "眠り姫", "恋磁石", "Pastel", "blossom", "アワイ オモイ", "Don’t cry", "Friends", "ルミナス", "Tik Tak", "Gravity", "アネモネ", "ドライフラワー", "カラフル", "encore", "border", "clever" ) );
            LiveList.Add( new LiveData( "ClariS 1st HALL CONCERT in パシフィコ横浜国立大ホール ～星に願いを… 月に祈りを…～", "パシフィコ横浜国立大ホール（神奈川県）", new DateTime(2016, 9, 18), "1日目", "コネクト", "CLICK", "STEP", "Clear Sky", "Reflect", "irony", "nexus", "SECRET", "コイノミ", "Pastel", "blossom", "HANABI", "Don’t cry", "Pieces", "ルミナス", "Tik Tak", "Gravity", "アネモネ", "ドライフラワー", "カラフル", "encore", "ナイショの話", "clever", "reunion" ) );
            LiveList.Add( new LiveData( "ClariS 1st 武道館コンサート ～2つの仮面と失われた太陽～", "日本武道館（東京都）", new DateTime(2017, 2, 10), "", "again", "YUMENOKI", "RESTART", "border", "ホログラム", "pastel", "blossom", "眠り姫", "CLICK", "コネクト", "ルミナス", "カラフル", "水色クラゲ", "このiは虚数", "アネモネ", "ウソツキ", "Gravity", "DROP（kz remix）", "irony", "Clear Sky", "STEP", "recall" ) );
            LiveList.Add( new LiveData( "ClariS 2nd HALL CONCERT in パシフィコ横浜国立大ホール ～さよならの先へ...はじまりのメロディ～", "パシフィコ横浜国立大ホール（神奈川県）", new DateTime(2017, 9, 16), "", "ヒトリゴト", "nexus", "プロミス", "Collage", "border -remix-", "Drawing", "Tik Tak", "CLICK", "ホログラム", "blossom", "again", "SECRET", "42nd STREET（カレンソロ）", "君の夢を見よう（クララソロ）", "Clear Sky", "reunion", "泣かないよ", "YUMENOKI", "サヨナラは言わない", "Prism", "カイト", "カラフル", "コネクト", "encore", "SHIORI", "Orange" ) );
            LiveList.Add( new LiveData("ClariS 3rd HALL CONCERT in 舞浜アンフィシアター ♪over the rainbow ～虹の彼方に～♬", "舞浜アンフィシアター（千葉県）", new DateTime(2018, 03, 29), "", "眠り姫", "Cloudy", "トパーズ", "ハルラ", "STEP", "graduation", "本当は（クララソロ）", "ヒトリゴト", "君の知らない物語", "blossom", "pastel", "eternally", "treasure", "recall（カレンソロ）", "ひらひら ひらら", "Butterfly Regret", "コネクト", "カラフル", "Dreamin’"));
            LiveList.Add( new LiveData("ClariS 3rd HALL CONCERT in 舞浜アンフィシアター ♪over the rainbow ～虹の彼方に～♬", "舞浜アンフィシアター（千葉県）", new DateTime(2018, 03, 30, 14, 0, 0 ), "", "眠り姫", "Cloudy", "トパーズ", "ハルラ", "STEP", "graduation", "本当は（クララソロ）", "ヒトリゴト", "赤いスイートピー", "blossom", "pastel", "eternally", "treasure", "recall（カレンソロ）", "ひらひら ひらら", "Butterfly Regret", "コネクト", "カラフル", "Dreamin’"));
            LiveList.Add( new LiveData("ClariS 3rd HALL CONCERT in 舞浜アンフィシアター ♪over the rainbow ～虹の彼方に～♬", "舞浜アンフィシアター（千葉県）", new DateTime(2018, 03, 30, 18, 30, 0), "", "眠り姫", "Cloudy", "トパーズ", "ハルラ", "STEP", "graduation", "本当は（クララソロ）", "ヒトリゴト", "sakura", "blossom", "pastel", "eternally", "treasure", "recall（カレンソロ）", "ひらひら ひらら", "Butterfly Regret", "コネクト", "カラフル", "Dreamin’"));
            LiveList.Add( new LiveData("ClariS 2nd Zepp Tour in 東名阪 ～Best of ClariS～", "Zepp Osaka Bayside（大阪府）", new DateTime(2018, 04, 29), "", "aaa"));
            LiveList.Add( new LiveData("ClariS 2nd Zepp Tour in 東名阪 ～Best of ClariS～", "Zepp Nagoya（愛知県）", new DateTime(2018, 04, 30), "", "aaa"));
            LiveList.Add( new LiveData("ClariS 2nd Zepp Tour in 東名阪 ～Best of ClariS～", "Zepp Tokyo（東京都）", new DateTime(2018, 05, 02), "", "aaa"));
            LiveList.Add(new LiveData("ClariS 2nd Zepp Tour in 東名阪 ～Best of ClariS～", "Zepp Tokyo（東京都）", new DateTime(2018, 05, 03), "", "aaa"));
            LiveList.Add(new LiveData("ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "三郷市文化会館大ホール（埼玉県）", new DateTime(2019, 03, 02), "", "aaa"));
            LiveList.Add(new LiveData("ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "昭和女子大学人見記念講堂（東京都）", new DateTime(2019, 03, 08), "", "aaa"));
            LiveList.Add(new LiveData("ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "昭和女子大学人見記念講堂（東京都）", new DateTime(2019, 03, 09), "", "aaa"));
            LiveList.Add(new LiveData("ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "NHK大阪ホール（大阪府）", new DateTime(2019, 03, 17), "", "aaa"));
            LiveList.Add(new LiveData("ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "中野サンプラザ（東京都）", new DateTime(2019, 04, 05), "", "aaa"));
            LiveList.Add(new LiveData("ClariS LIVE Tour 2019 ～libero～", "仙台PIT（宮城県）", new DateTime(2019, 09, 28), "", "aaa"));
            LiveList.Add(new LiveData("ClariS LIVE Tour 2019 ～libero～", "Zepp Nagoya（愛知県）", new DateTime(2019, 10, 05), "", "aaa"));
            LiveList.Add(new LiveData("ClariS LIVE Tour 2019 ～libero～", "Zepp Namba（大阪府）", new DateTime(2019, 10, 06), "", "aaa"));
            LiveList.Add(new LiveData("ClariS LIVE Tour 2019 ～libero～", "Zepp Tokyo（東京都）", new DateTime(2019, 10, 11), "", "aaa"));
            LiveList.Add(new LiveData("ClariS LIVE Tour 2019 ～libero～", "Zepp Tokyo（東京都）", new DateTime(2019, 10, 22), "", "aaa"));
            LiveList.Add(new LiveData("ClariS 10th Anniversary Precious LIVE ～Gift～", "neo bridge（ネオブリッジ）", new DateTime(2020, 10, 20), "", "aaa"));
            LiveList.Add(new LiveData("Merry ClarismaS ～ひみつのサンタクロース～", "neo bridge（ネオブリッジ）", new DateTime(2020, 12, 24), "", "aaa"));
            LiveList.Add(new LiveData("ClariS HALL CONCERT 2022 ～Twinkle Summer Dreams～", "LINE CUBE SHIBUYA（東京都）", new DateTime(2022, 08, 11), "", "aaa"));
            LiveList.Add(new LiveData("ClariS HALL CONCERT 2022 ～Twinkle Summer Dreams～", "LINE CUBE SHIBUYA（東京都）", new DateTime(2022, 08, 11), "", "aaa"));
            LiveList.Add(new LiveData("ClariS HALL CONCERT 2022 ～Twinkle Summer Dreams～", "神奈川県民ホール（神奈川県）", new DateTime(2022, 08, 13), "", "aaa"));
            LiveList.Add(new LiveData("ClariS HALL CONCERT 2022 WINTER ～Let's Snow Parade!～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2022, 12, 16), "", "aaa"));
            LiveList.Add(new LiveData("ClariS HALL CONCERT 2022 WINTER ～Let's Snow Parade!～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2022, 12, 17), "", "aaa"));
            LiveList.Add(new LiveData("ClariS HALL CONCERT 2022 WINTER ～Let's Snow Parade!～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2022, 12, 17), "", "aaa"));
            LiveList.Add(new LiveData("ClariS Spring LIVE 2023 ～Neo Sparkle～", "Zepp Haneda（東京都）", new DateTime(2023, 05, 06), "", "aaa"));
            LiveList.Add(new LiveData("ClariS Spring LIVE 2023 ～Neo Sparkle～", "Zepp Haneda（東京都）", new DateTime(2023, 05, 07), "", "aaa"));
            LiveList.Add(new LiveData("ClariS Autumn Live 2023 ～Arcanum～", "Zepp DiverCity（東京都）", new DateTime(2023, 11, 24), "", "aaa"));
            LiveList.Add(new LiveData("ClariS Autumn Live 2023 ～Arcanum～", "Zepp DiverCity（東京都）", new DateTime(2023, 11, 25), "", "aaa"));
            LiveList.Add(new LiveData("ClariS Autumn Live 2023 ～Arcanum～", "Zepp DiverCity（東京都）", new DateTime(2023, 11, 25), "", "aaa"));
            LiveList.Add(new LiveData("ClariS SPRING TOUR 2024 ～Tinctura～", "Zepp Osaka Bayside（大阪府）", new DateTime(2024, 05, 25), "", "aaa"));
            LiveList.Add(new LiveData("ClariS SPRING TOUR 2024 ～Tinctura～", "広島クラブクアトロ（広島県）", new DateTime(2024, 05, 26), "", "aaa"));
            LiveList.Add(new LiveData("ClariS Room Party ～Rhythm～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 05, 31), "", "aaa"));
            LiveList.Add(new LiveData("ClariS SPRING TOUR 2024 ～Tinctura～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 06, 01), "", "aaa"));
            LiveList.Add(new LiveData("ClariS SPRING TOUR 2024 ～Tinctura～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 06, 01), "", "aaa"));
            LiveList.Add(new LiveData("ClariS SPRING TOUR 2024 ～Tinctura～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 06, 02), "", "aaa"));
            LiveList.Add(new LiveData("ClariS SPRING TOUR 2024 ～Tinctura～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 06, 02), "", "aaa"));
        }
    }

}
