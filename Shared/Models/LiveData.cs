using MudBlazor;
using System.Reflection.Metadata;

namespace ClariSLiveSetList.Shared.Models
{
    public class LiveData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public DateTime Date;
        public string AddInfo { get; set; }
        public List<string> SetList = new List<string>();
        public List<string> SetListEncore = new List<string>();
        public List<string> SetListDoubleEncore = new List<string>();

        public LiveData( int id, string t, string p, DateTime d, string ai, params string[] setlist )
        {
            Id = id;
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

        public List<LiveData>? GetLiveData( int id )
        {
            try {
                var val = LiveList.Where(x => x.Id == id).ToList();
                return ( val );
            } catch ( Exception e ) {
                return ( null );
            }
        }

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
            LiveList.Add( new LiveData(  1, "ClariS 1st Live ～扉の先へ～", "Zepp Tokyo（東京都）", new DateTime( 2015, 7, 31), "", "reunion", "Clear Sky", "irony", "border", "CLICK", "STEP", "Reflect", "アネモネ", "YUMENOKI", "pastel", "Wake Up", "rainy day", "nexus", "ナイショの話", "ルミナス", "眠り姫", "コイノミ", "encore", "カラフル", "double_encore", "コネクト" ) );
            LiveList.Add( new LiveData(  2, "ClariS 1st Tour ～夢の1ページ…～", "Zepp Nagoya（愛知県）", new DateTime(2016, 3, 6), "", "本当は", "Prism", "irony", "ハルラ", "カイト", "Dreamin’", "CLICK", "STEP", "border", "pastel", "nexus", "恋磁石", "YUMENOKI", "pieces", "カラフル", "with you", "アネモネ", "プロミス", "サヨナラは言わない", "グラスプ", "ひらひら ひらら", "encore", "ナイショの話", "コネクト" ) );
            LiveList.Add( new LiveData(  3, "ClariS 1st Tour ～夢の1ページ…～", "Zepp Namba（大阪府）", new DateTime(2016, 3, 12), "", "Prism", "irony", "ハルラ", "カイト", "Dreamin’", "CLICK", "STEP", "border", "pastel", "恋磁石", "YUMENOKI", "カラフル", "with you", "アネモネ", "プロミス", "サヨナラは言わない", "ひらひら ひらら", "encore", "ルミナス", "コネクト" ) );
            LiveList.Add( new LiveData(  4, "ClariS 1st Tour ～夢の1ページ…～", "Zepp Tokyo（東京都）", new DateTime(2016, 3, 19), "1日目", "本当は", "Prism", "irony", "ハルラ", "カイト", "Dreamin’", "CLICK", "STEP", "border", "pastel", "nexus", "恋磁石", "YUMENOKI", "pieces", "カラフル", "with you", "アネモネ", "プロミス", "サヨナラは言わない", "グラスプ", "ひらひら ひらら", "encore", "ナイショの話", "コネクト" ) );
            LiveList.Add( new LiveData(  5, "ClariS 1st Tour ～夢の1ページ…～", "Zepp Tokyo（東京都）", new DateTime(2016, 3, 20), "2日目", "本当は", "Prism", "irony", "ハルラ", "カイト", "Dreamin’", "CLICK", "STEP", "border", "pastel", "nexus", "恋磁石", "YUMENOKI", "pieces", "カラフル", "with you", "アネモネ", "プロミス", "サヨナラは言わない", "グラスプ", "ひらひら ひらら", "encore", "コネクト", "reunion", "graduation" ) );
            LiveList.Add( new LiveData(  6, "ClariS 1st HALL CONCERT in パシフィコ横浜国立大ホール ～星に願いを… 月に祈りを…～", "パシフィコ横浜国立大ホール（神奈川県）", new DateTime(2016, 9, 17), "1日目", "コネクト", "CLICK", "STEP", "Clear Sky", "Reflect", "irony", "Prism", "眠り姫", "恋磁石", "Pastel", "blossom", "アワイ オモイ", "Don’t cry", "Friends", "ルミナス", "Tik Tak", "Gravity", "アネモネ", "ドライフラワー", "カラフル", "encore", "border", "clever" ) );
            LiveList.Add( new LiveData(  7, "ClariS 1st HALL CONCERT in パシフィコ横浜国立大ホール ～星に願いを… 月に祈りを…～", "パシフィコ横浜国立大ホール（神奈川県）", new DateTime(2016, 9, 18), "1日目", "コネクト", "CLICK", "STEP", "Clear Sky", "Reflect", "irony", "nexus", "SECRET", "コイノミ", "Pastel", "blossom", "HANABI", "Don’t cry", "Pieces", "ルミナス", "Tik Tak", "Gravity", "アネモネ", "ドライフラワー", "カラフル", "encore", "ナイショの話", "clever", "reunion" ) );
            LiveList.Add( new LiveData(  8, "ClariS 1st 武道館コンサート ～2つの仮面と失われた太陽～", "日本武道館（東京都）", new DateTime(2017, 2, 10), "", "again", "YUMENOKI", "RESTART", "border", "ホログラム", "pastel", "blossom", "眠り姫", "CLICK", "コネクト", "ルミナス", "カラフル", "水色クラゲ", "このiは虚数", "アネモネ", "ウソツキ", "Gravity", "DROP（kz remix）", "irony", "Clear Sky", "STEP", "recall", "encore", "clever", "ナイショの話", "reunion" ) );
            LiveList.Add( new LiveData(  9, "ClariS 2nd HALL CONCERT in パシフィコ横浜国立大ホール ～さよならの先へ...はじまりのメロディ～", "パシフィコ横浜国立大ホール（神奈川県）", new DateTime(2017, 9, 16), "", "ヒトリゴト", "nexus", "プロミス", "Collage", "border -remix-", "Drawing", "Tik Tak", "CLICK", "ホログラム", "blossom", "again", "SECRET", "42nd STREET（カレンソロ）", "君の夢を見よう（クララソロ）", "Clear Sky", "reunion", "泣かないよ", "YUMENOKI", "サヨナラは言わない", "Prism", "カイト", "カラフル", "コネクト", "encore", "SHIORI", "Orange" ) );
            LiveList.Add( new LiveData( 10, "ClariS 3rd HALL CONCERT in 舞浜アンフィシアター ♪over the rainbow ～虹の彼方に～♬", "舞浜アンフィシアター（千葉県）", new DateTime(2018, 03, 29), "", "眠り姫", "Cloudy", "トパーズ", "ハルラ", "STEP", "graduation", "本当は（クララソロ）", "ヒトリゴト", "君の知らない物語", "blossom", "pastel", "eternally", "treasure", "recall（カレンソロ）", "ひらひら ひらら", "Butterfly Regret", "コネクト", "カラフル", "Dreamin’", "encore", "PRIMALove" ) );
            LiveList.Add( new LiveData( 11, "ClariS 3rd HALL CONCERT in 舞浜アンフィシアター ♪over the rainbow ～虹の彼方に～♬", "舞浜アンフィシアター（千葉県）", new DateTime(2018, 03, 30, 14, 0, 0 ), "", "眠り姫", "Cloudy", "トパーズ", "ハルラ", "STEP", "graduation", "本当は（クララソロ）", "ヒトリゴト", "赤いスイートピー", "blossom", "pastel", "eternally", "treasure", "recall（カレンソロ）", "ひらひら ひらら", "Butterfly Regret", "コネクト", "カラフル", "Dreamin’", "encore", "PRIMALove" ) );
            LiveList.Add( new LiveData( 12, "ClariS 3rd HALL CONCERT in 舞浜アンフィシアター ♪over the rainbow ～虹の彼方に～♬", "舞浜アンフィシアター（千葉県）", new DateTime(2018, 03, 30, 18, 30, 0), "", "眠り姫", "Cloudy", "トパーズ", "ハルラ", "STEP", "graduation", "本当は（クララソロ）", "ヒトリゴト", "sakura", "blossom", "pastel", "eternally", "treasure", "recall（カレンソロ）", "ひらひら ひらら", "Butterfly Regret", "コネクト", "カラフル", "Dreamin’", "encore", "PRIMALove" ) );
            LiveList.Add( new LiveData( 13, "ClariS 2nd Zepp Tour in 東名阪 ～Best of ClariS～", "Zepp Osaka Bayside（大阪府）", new DateTime(2018, 04, 29), "", "コネクト", "ルミナス", "カラフル", "again", "アネモネ-Wake Up remix- by kz", "clever", "Gravity", "SHIORI", "border", "ナイショの話", "ホログラム", "blossom-reunion remix- by kz", "CLICK", "STEP", "冬空花火", "nexus", "PRIMALove", "irony", "encore", "ヒトリゴト", "Clear Sky" ) );
            LiveList.Add( new LiveData( 14, "ClariS 2nd Zepp Tour in 東名阪 ～Best of ClariS～", "Zepp Nagoya（愛知県）", new DateTime(2018, 04, 30), "", "コネクト", "ルミナス", "カラフル", "again", "アネモネ-Wake Up remix- by kz", "clever", "Gravity", "SHIORI", "border", "ナイショの話", "ホログラム", "blossom-reunion remix- by kz", "CLICK", "STEP", "冬空花火", "nexus", "PRIMALove", "irony", "encore", "ヒトリゴト", "Prism" ) );
            LiveList.Add( new LiveData( 15, "ClariS 2nd Zepp Tour in 東名阪 ～Best of ClariS～", "Zepp Tokyo（東京都）", new DateTime(2018, 05, 02), "", "コネクト", "ルミナス", "カラフル", "again", "アネモネ-Wake Up remix- by kz", "clever", "Gravity", "SHIORI", "border", "ナイショの話", "ホログラム", "blossom-reunion remix- by kz", "CLICK", "STEP", "冬空花火", "nexus", "PRIMALove", "irony", "encore", "ヒトリゴト", "Clear Sky" ) );
            LiveList.Add( new LiveData( 16, "ClariS 2nd Zepp Tour in 東名阪 ～Best of ClariS～", "Zepp Tokyo（東京都）", new DateTime(2018, 05, 03), "", "コネクト", "ルミナス", "カラフル", "again", "アネモネ-Wake Up remix- by kz", "clever", "Gravity", "SHIORI", "border", "ナイショの話", "ホログラム", "blossom-reunion remix- by kz", "CLICK", "STEP", "冬空花火", "nexus", "PRIMALove", "irony", "encore", "ヒトリゴト", "イロドリ" ) );
            LiveList.Add( new LiveData( 17, "ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "三郷市文化会館大ホール（埼玉県）", new DateTime(2019, 03, 02), "", "Overture", "1/f", "ヒトリゴト", "SHIORI", "CheerS", "陽だまり", "distance", "パラレルワープ", "Last Squall", "TRAVEL", "PRIMALove", "Time Tunnel", "シニカルサスペンス", "Fairy Party", "Wake Up", "CLICK", "blossom", "キミとふたり", "ねがい", "Butterfly Regret", "恋磁石", "コネクト", "encore", "border", "flowery" ) );
            LiveList.Add( new LiveData( 18, "ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "昭和女子大学人見記念講堂（東京都）", new DateTime(2019, 03, 08), "", "Overture", "1/f", "ヒトリゴト", "SHIORI", "CheerS", "陽だまり", "distance", "パラレルワープ", "Last Squall", "TRAVEL", "PRIMALove", "Time Tunnel", "シニカルサスペンス", "Fairy Party", "Wake Up", "STEP", "ホログラム", "Don’t cry", "ねがい", "Butterfly Regret", "SECRET", "カラフル", "encore", "ナイショの話", "Orange" ) ) ;
            LiveList.Add( new LiveData( 19, "ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "昭和女子大学人見記念講堂（東京都）", new DateTime(2019, 03, 09, 12, 30, 0), "", "Overture", "1/f", "ヒトリゴト", "SHIORI", "CheerS", "陽だまり", "distance", "パラレルワープ", "Last Squall", "TRAVEL", "PRIMALove", "Time Tunnel", "シニカルサスペンス", "Fairy Party", "Wake Up", "CLICK", "blossom", "キミとふたり", "ねがい", "Butterfly Regret", "恋磁石", "コネクト", "encore", "border", "flowery" ) );
            LiveList.Add( new LiveData( 20, "ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "昭和女子大学人見記念講堂（東京都）", new DateTime(2019, 03, 09, 17, 0, 0), "", "Overture", "1/f", "ヒトリゴト", "SHIORI", "CheerS", "陽だまり", "distance", "パラレルワープ", "Last Squall", "TRAVEL", "PRIMALove", "Time Tunnel", "シニカルサスペンス", "Fairy Party", "Wake Up", "STEP", "ホログラム", "Don’t cry", "ねがい", "Butterfly Regret", "SECRET", "カラフル", "encore", "ナイショの話", "Orange" ) );
            LiveList.Add( new LiveData( 21, "ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "NHK大阪ホール（大阪府）", new DateTime(2019, 03, 17), "", "Overture", "1/f", "ヒトリゴト", "SHIORI", "CheerS", "陽だまり", "distance", "パラレルワープ", "Last Squall", "TRAVEL", "PRIMALove", "Time Tunnel", "シニカルサスペンス", "Fairy Party", "Wake Up", "CLICK", "blossom", "キミとふたり", "ねがい", "Butterfly Regret", "恋磁石", "コネクト", "encore", "border", "flowery" ) );
            LiveList.Add( new LiveData( 22, "ClariS 1st HALL CONCERT TOUR ～Fairy Party～", "中野サンプラザ（東京都）", new DateTime(2019, 04, 05), "", "Overture", "1/f", "ヒトリゴト", "SHIORI", "CheerS", "陽だまり", "distance", "パラレルワープ", "Last Squall", "TRAVEL", "PRIMALove", "Time Tunnel", "シニカルサスペンス", "Fairy Party", "Wake Up", "STEP", "ホログラム", "Don’t cry", "ねがい", "Butterfly Regret", "SECRET", "カラフル", "encore", "仮面ジュブナイル", "ナイショの話", "Orange" ) );
            LiveList.Add( new LiveData( 23, "ClariS LIVE Tour 2019 ～libero～", "仙台PIT（宮城県）", new DateTime(2019, 09, 28), "", "ナイショの話", "ダイアリー", "眠り姫", "recall", "アネモネ", "Gravity", "with you", "SHIORI", "again", "カイト", "ヒトリゴト", "pastel", "Fairy Party", "パラレルワープ", "Last Squall", "1/f", "このiは虚数", "Summer Delay", "PRIMALove", "clever", "シニカルサスペンス", "RESTART", "シグナル", "encore", "仮面ジュブナイル", "Diamonds", "Prism" ) );
            LiveList.Add( new LiveData( 24, "ClariS LIVE Tour 2019 ～libero～", "Zepp Nagoya（愛知県）", new DateTime(2019, 10, 05), "", "ナイショの話", "ダイアリー", "眠り姫", "YUMENOKI", "ルミナス", "Gravity", "with you", "SHIORI", "again", "Collage", "border", "Reflect", "eternally", "Wake Up", "ウソツキ", "HANABI", "Pieces", "Clear Sky", "メモリー", "I’m in love", "PRIMALove", "clever", "シニカルサスペンス", "RESTART", "シグナル", "encore", "仮面ジュブナイル", "secret base ～君がくれたもの～", "reunion" ) );
            LiveList.Add( new LiveData( 25, "ClariS LIVE Tour 2019 ～libero～", "Zepp Namba（大阪府）", new DateTime(2019, 10, 06), "", "ナイショの話", "ダイアリー", "眠り姫", "YUMENOKI", "ルミナス", "Gravity", "with you", "SHIORI", "again", "Collage", "border", "Reflect", "eternally", "Wake Up", "ウソツキ", "HANABI", "Pieces", "Clear Sky", "メモリー", "I’m in love", "PRIMALove", "clever", "シニカルサスペンス", "RESTART", "シグナル", "encore", "仮面ジュブナイル", "恋のバカンス", "reunion"));
            LiveList.Add( new LiveData( 26, "ClariS LIVE Tour 2019 ～libero～", "Zepp Tokyo（東京都）", new DateTime(2019, 10, 11), "", "ナイショの話", "ダイアリー", "眠り姫", "recall", "アネモネ", "Gravity", "with you", "SHIORI", "again", "カイト", "ヒトリゴト", "pastel", "Fairy Party", "パラレルワープ", "Last Squall", "1/f", "このiは虚数", "Summer Delay", "PRIMALove", "clever", "シニカルサスペンス", "RESTART", "シグナル", "encore", "仮面ジュブナイル", "タッチ", "Prism"));
            LiveList.Add( new LiveData( 27, "ClariS LIVE Tour 2019 ～libero～", "Zepp Tokyo（東京都）", new DateTime(2019, 10, 22), "", "ナイショの話", "ダイアリー", "眠り姫", "YUMENOKI", "ルミナス", "Gravity", "with you", "SHIORI", "again", "Collage", "border", "Reflect", "eternally", "Wake Up", "ウソツキ", "HANABI", "Pieces", "Clear Sky", "メモリー", "I’m in love", "PRIMALove", "clever", "シニカルサスペンス", "RESTART", "シグナル", "encore", "仮面ジュブナイル", "secret base ～君がくれたもの～", "reunion"));
            LiveList.Add( new LiveData( 28, "ClariS 10th Anniversary Precious LIVE ～Gift～", "neo bridge（ネオブリッジ）", new DateTime(2020, 10, 20), "", "irony", "CLICK", "Clear Sky", "again", "border", "仮面ジュブナイル", "コネクト", "アリシア", "ヒトリゴト", "SHIORI", "ルミナス", "アネモネ", "CheerS", "STEP", "reunion", "ナイショの話", "PRECIOUS" ) );
            LiveList.Add( new LiveData( 29, "Merry ClarismaS ～ひみつのサンタクロース～", "neo bridge（ネオブリッジ）", new DateTime(2020, 12, 24), "", "サンタが街にやってくる", "Fairy Party", "Wake Up", "eternally", "メリクリ（メドレー）", "last christmas（メドレー）", "white love（メドレー）", "すてきなホリデイ（メドレー）", "恋人がサンタクロース（メドレー）", "ひとつだけ", "冬空花火", "シグナル", "ウソツキ", "グラスプ", "カラフル", "Prism" ) );
            LiveList.Add( new LiveData( 30, "ClariS HALL CONCERT 2022 ～Twinkle Summer Dreams～", "LINE CUBE SHIBUYA（東京都）", new DateTime(2022, 08, 11, 13, 0, 0), "", "Twinkle Twinkle", "アリシア", "CLICK", "Fight!!", "新世界ビーナス", "瞳の中のローレライ", "Mermaid", "Summer Delay", "オルゴール", "アワイ オモイ", "ホログラム", "Masquerade", "シニカルサスペンス", "アイデンティティ", "missing you", "ALIVE", "コネクト", "Starry", "SHIORI", "ケアレス", "reunion", "encore", "ナイショの話", "PRECIOUS" ) );
            LiveList.Add( new LiveData( 31, "ClariS HALL CONCERT 2022 ～Twinkle Summer Dreams～", "LINE CUBE SHIBUYA（東京都）", new DateTime(2022, 08, 11, 18, 0, 0), "", "Twinkle Twinkle", "アリシア", "CLICK", "Fight!!", "新世界ビーナス", "瞳の中のローレライ", "Mermaid", "Summer Delay", "オルゴール", "アワイ オモイ", "ホログラム", "Masquerade", "シニカルサスペンス", "アイデンティティ", "missing you", "ALIVE", "コネクト", "Starry", "SHIORI", "ケアレス", "reunion", "encore", "ナイショの話", "PRECIOUS" ) );
            LiveList.Add( new LiveData( 32, "ClariS HALL CONCERT 2022 ～Twinkle Summer Dreams～", "神奈川県民ホール（神奈川県）", new DateTime(2022, 08, 13), "", "Twinkle Twinkle", "アリシア", "CLICK", "Fight!!", "新世界ビーナス", "瞳の中のローレライ", "Mermaid", "Summer Delay", "オルゴール", "Surely", "ホログラム", "Masquerade", "眠り姫", "アイデンティティ", "missing you", "ALIVE", "コネクト", "Starry", "SHIORI", "ケアレス", "reunion", "encore", "ナイショの話", "PRECIOUS") ) ;
            LiveList.Add( new LiveData( 33, "ClariS HALL CONCERT 2022 WINTER ～Let's Snow Parade!～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2022, 12, 16), "", "It’s showtime!!", "Fairy Party", "Sweet Holic", "ヒトリゴト", "Prism", "ウソツキ", "eternally", "ひとつだけ", "グラスプ", "スノーライト", "WHITE BREATH", "White Love", "ORION", "サイレント・イヴ", "Butterﬂy Regret", "Brave", "border", "again", "STEP", "コネクト", "カラフル", "encore", "仮面ジュブナイル", "ALIVE" ) );
            LiveList.Add( new LiveData( 34, "ClariS HALL CONCERT 2022 WINTER ～Let's Snow Parade!～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2022, 12, 17, 13, 0, 0), "", "It’s showtime!!", "Fairy Party", "Sweet Holic", "ヒトリゴト", "Prism", "ウソツキ", "eternally", "ひとつだけ", "グラスプ", "スノーライト", "WHITE BREATH", "White Love", "ORION", "サイレント・イヴ", "Butterﬂy Regret", "blossom", "border", "again", "irony", "コネクト", "カラフル", "encore", "仮面ジュブナイル", "ALIVE" ) );
            LiveList.Add( new LiveData( 35, "ClariS HALL CONCERT 2022 WINTER ～Let's Snow Parade!～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2022, 12, 17, 18, 0, 0), "", "It’s showtime!!", "Fairy Party", "Sweet Holic", "ヒトリゴト", "Prism", "ウソツキ", "eternally", "ひとつだけ", "グラスプ", "スノーライト", "WHITE BREATH", "White Love", "ORION", "サイレント・イヴ", "Butterﬂy Regret", "Brave", "border", "again", "STEP", "コネクト", "カラフル", "encore", "仮面ジュブナイル", "ALIVE" ) );
            LiveList.Add( new LiveData( 36, "ClariS Spring LIVE 2023 ～Neo Sparkle～", "Zepp Haneda（東京都）", new DateTime(2023, 05, 06), "", "ALIVE", "again", "ユニゾン", "border", "パラレルワープ", "シニカルサスペンス", "新世界ビーナス", "SHIORI", "nexus", "with you", "恋待かぐや", "ひらひら ひらら", "Surely", "ミントガム", "ヒトリゴト", "CLICK", "ナイショの話", "encore", "reunion", "コネクト", "double_encore", "淋しい熱帯魚" ) );
            LiveList.Add( new LiveData( 37, "ClariS Spring LIVE 2023 ～Neo Sparkle～", "Zepp Haneda（東京都）", new DateTime(2023, 05, 07), "", "ALIVE", "again", "ユニゾン", "border", "Neo Moon", "シニカルサスペンス", "Brave", "シグナル", "nexus", "with you", "恋待かぐや", "ひらひら ひらら", "Surely", "ミントガム", "ヒトリゴト", "CLICK", "ナイショの話", "encore", "reunion", "コネクト", "double_encore", "淋しい熱帯魚" ) );
            LiveList.Add( new LiveData( 38, "ClariS Autumn Live 2023 ～Arcanum～", "Zepp DiverCity（東京都）", new DateTime(2023, 11, 24), "", "ナイショの話", "ヒトリゴト", "コイセカイ", "君色", "irony", "nexus", "blossom", "treasure", "忘れてもいいよ", "カイト", "淋しい熱帯魚（メドレー）", "赤いスイートピー（メドレー）", "タッチ（メドレー）", "もういちど ルミナス（メドレー）", "コネクト", "ルミナス", "Gravity", "幻想恋慕", "恋磁石", "シニカルサスペンス", "border", "ALIVE", "encore", "ふぉりら" ) );
            LiveList.Add( new LiveData( 39, "ClariS Autumn Live 2023 ～Arcanum～", "Zepp DiverCity（東京都）", new DateTime(2023, 11, 25, 13, 0, 0), "", "ナイショの話", "ヒトリゴト", "コイセカイ", "君色", "irony", "Prism", "ホログラム", "treasure", "忘れてもいいよ", "カイト", "淋しい熱帯魚（メドレー）", "恋のバカンス（メドレー）", "Diamonds（メドレー）", "アイヲウタエ（メドレー）", "コネクト", "ルミナス", "Gravity", "幻想恋慕", "Sweet Holic", "シニカルサスペンス", "border", "ALIVE", "encore", "ふぉりら" ) );
            LiveList.Add( new LiveData( 40, "ClariS Autumn Live 2023 ～Arcanum～", "Zepp DiverCity（東京都）", new DateTime(2023, 11, 25, 18, 0, 0), "", "ナイショの話", "ヒトリゴト", "コイセカイ", "君色", "irony", "nexus", "blossom", "treasure", "忘れてもいいよ", "カイト", "淋しい熱帯魚（メドレー）", "赤いスイートピー（メドレー）", "タッチ（メドレー）", "もういちど ルミナス（メドレー）", "コネクト", "ルミナス", "Gravity", "幻想恋慕", "恋磁石", "シニカルサスペンス", "border", "ALIVE", "encore", "ふぉりら", "PRECIOUS" ) );
            LiveList.Add( new LiveData( 41, "ClariS SPRING TOUR 2024 ～Tinctura～", "Zepp Osaka Bayside（大阪府）", new DateTime(2024, 05, 25), "", "reunion", "ヒトリゴト", "アンダンテ", "Love is Mystery", "擬態", "Freaky Candy", "新世界ビーナス", "ハルラ（メドレー）", "桜咲く（メドレー）", "恋待ちかぐや（メドレー）", "サクラ・インカーネーション（メドレー）", "カラフル（クララソロ）", "アネモネ（カレンソロ）", "ALIVE", "トワイライト", "clever", "未来航路", "Wonder Night", "一期一会", "Blue Canvas", "CLICK", "ユニゾン", "コネクト", "encore", "border", "イロドリ" ) );
            LiveList.Add( new LiveData( 42, "ClariS SPRING TOUR 2024 ～Tinctura～", "広島クラブクアトロ（広島県）", new DateTime(2024, 05, 26), "", "ナイショの話", "ヒトリゴト", "アンダンテ", "Love is Mystery", "擬態", "Freaky Candy", "again", "ループ", "ミントガム", "graduation", "Bye-Bye Butterfly", "サクラ・インカーネーション", "ALIVE", "トワイライト", "未来航路", "Wonder Night", "君色", "STEP", "コネクト", "encore", "シニカルサスペンス", "Clear Sky" ) );
            LiveList.Add( new LiveData( 43, "ClariS Room Party ～Rhythm～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 05, 31), "", "ココロの引力", "Don't cry", "Pieces", "アナタニFIT", "アイデンティティ", "サヨナラは言わない", "シルシ" ) );
            LiveList.Add( new LiveData( 44, "ClariS SPRING TOUR 2024 ～Tinctura～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 06, 01, 13, 0, 0), "", "reunion", "ヒトリゴト", "アンダンテ", "Love is Mystery", "擬態", "Freaky Candy", "Masquerade", "新世界ビーナス", "ハルラ（メドレー）", "桜咲く（メドレー）", "恋待ちかぐや（メドレー）", "サクラ・インカーネーション（メドレー）", "カラフル（クララソロ）", "アネモネ（カレンソロ）", "ALIVE", "トワイライト", "SHIORI", "未来航路", "Wonder Night", "アサガオ", "一期一会", "Blue Canvas", "CLICK", "コネクト", "encore", "Prism", "border", "イロドリ" ) );
            LiveList.Add( new LiveData( 45, "ClariS SPRING TOUR 2024 ～Tinctura～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 06, 01, 18, 0, 0), "", "reunion", "ヒトリゴト", "アンダンテ", "Love is Mystery", "擬態", "Freaky Candy", "Masquerade", "ループ", "ミントガム（メドレー）", "graduation（メドレー）", "Bye-Bye Butterfly（メドレー）", "サクラ・インカーネーション（メドレー）", "カラフル（クララソロ）", "アネモネ（カレンソロ）", "ALIVE", "トワイライト", "SHIORI", "未来航路", "Wonder Night", "アサガオ", "一期一会", "Blue Canvas", "ふぉりら", "コネクト", "encore", "Prism", "border", "second story" ) );
            LiveList.Add( new LiveData( 46, "ClariS SPRING TOUR 2024 ～Tinctura～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 06, 02, 13, 0, 0), "", "reunion", "ヒトリゴト", "アンダンテ", "Love is Mystery", "擬態", "Freaky Candy", "Masquerade", "新世界ビーナス", "ハルラ（メドレー）", "桜咲く（メドレー）", "恋待ちかぐや（メドレー）", "サクラ・インカーネーション（メドレー）", "カラフル（クララソロ）", "アネモネ（カレンソロ）", "ALIVE", "トワイライト", "SHIORI", "未来航路", "Wonder Night", "アサガオ", "一期一会", "Blue Canvas", "CLICK", "ユニゾン", "encore", "Prism", "border", "イロドリ" ) );
            LiveList.Add( new LiveData( 47, "ClariS SPRING TOUR 2024 ～Tinctura～", "TOKYO DOME CITY HALL(東京都）", new DateTime(2024, 06, 02, 18, 0, 0), "", "reunion", "ヒトリゴト", "アンダンテ", "Love is Mystery", "擬態", "Freaky Candy", "Masquerade", "ループ", "ミントガム（メドレー）", "graduation（メドレー）", "Bye-Bye Butterfly（メドレー）", "サクラ・インカーネーション（メドレー）", "カラフル（クララソロ）", "アネモネ（カレンソロ）", "ALIVE", "トワイライト", "SHIORI", "未来航路", "Wonder Night", "アサガオ", "一期一会", "Blue Canvas", "ふぉりら", "コネクト", "encore", "Prism", "border", "second story" ) );
        }
    }

}
