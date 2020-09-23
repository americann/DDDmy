using DDD.WinForm.Common;
using DDD.WinForm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WinForm
{
    public partial class WeatherLatestVIew : Form
    {

        //データベースの接続先

        public WeatherLatestVIew()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ボタンを押したらデータを取得してラベルに値挿入
        /// この画面に知識がないか？あるとまずい。温度を取得したあとにRoundStringを実装しなくちゃいけない場合は
        /// 知っている人しか使えないコードになってしまう。
        /// 新しいメンバーが増えたときに教えなくてはいけないことが多いコードはクソ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LatestButton_Click(object sender, EventArgs e)
        {

            var dt = WeatherSQLite.GetLatest(Convert.ToInt32(AreaIdTextBox.Text));


           
        }


    }
}

//潜在的なBADポイント
////テストしやすいコード
///関数内で別の関数を呼び出していてもその関数がそこで完結していればOK
///
/// テストしにくいコード
/// 外部アクセスしているコード
/// 実際にファイルが存在しないとテストができないコード
/// 外部機器がないとテストができないコード
/// 解決策：インターフェースの利用、Moqなどのツールを利用する
///


//潜在的なBADポイント
//視点①：知識の所在、どこに知識があるか？
//ロジックは二種類、使う側と使われる側
//使う側に知識があるとドメインロジックが散らばる
//やばい
//値とロジックが別々のところにあるとは散らばっているということ
//CommonFuncとCommonConstを記憶していなければならない
//そうすると画面コードに直接単位などを記述してしまう。



//関数を共通関数クラスに移動
//固定値をCONSTクラスに移動
//？？？？
//複数人で開発を行うときにみんな作成した関数を使ってくれるか？
//100画面作成したときにちゃんとすべてのページで作成した関数が使われるか？？？
//今回は共通化とコンスト化だけを実装しただけ
//普通の人はこのレベルまでしか気づけない
//だからこそ我々はオブジェクト指向を学ばねばならない




//Badコード
//SQLが重複していないか？
//SQLの接続先、タイムアウト時間の設定が集約されているか？
//データ取得後の加工処理、単位の設定が集約されているか？
//一覧表示、単一表示で同じ処理を別々に書く必要があるか？
