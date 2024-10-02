using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerifClass
{
    public string sayername;
    public string text;
    public float time;
    public int serifeventnumber = 0;
    public string buttontext;

    public SerifClass(string _name, string _text, float _time, int _number, string _buttontext)
    {
        sayername = _name;
        text = _text;
        time = _time;
        serifeventnumber = _number;
        buttontext = _buttontext;
    }
}
public class SerifList : MonoBehaviour
{
    public List<SerifClass> seriflist = new List<SerifClass>()
    {
       new SerifClass("あたな：","危なかった、ここはどこだ？寒いな。",2.0f,1,"AIサポーター智子に指揮センターに連絡させる"),

       new SerifClass("あたな：","智子、指揮センターに連絡してくれ。",2.0f,0,null),
       new SerifClass("智子：","指揮センターへの連絡を試みています。",2.0f,0,null),
       new SerifClass("智子：","警告、ここはX事件の生化学ウイルス流出現場です。",2.0f,0,null),
       new SerifClass("智子：","安全にご注意ください。",2.0f,1,"装備チェック"),

       new SerifClass("あたな：","うん、智子、装備のチェックをして。",3.0f,0,null),
       new SerifClass("智子：","了解です。",2.0f,0,null),
       new SerifClass("智子：","では、まず少し移動してみましょう。",1.0f,2,null),
       new SerifClass("智子：","問題はなさそうです。",2.0f,0,null),
       new SerifClass("智子：","次に武器の状態を確認しましょう。",2.0f,0,null),
       new SerifClass("智子：","照準は可能ですか？",1.0f,3,null),

       new SerifClass("智子：","無事みたいですね。",2.0f,0,null),
       new SerifClass("智子：","ではこれから武器のチェックです。",2.0f,0,null),
       new SerifClass("智子：","照準して撃ってみましょう。",1.0f,4,null),

       new SerifClass("智子：","警告。近くに未確認生物が接近しています。警戒を強めてください",5.0f,6,null),
       new SerifClass(" "," ",2.0f,0,null),
       new SerifClass("智子：","修正。生物ではなく、X事件の犠牲者たちです。",2.0f,0,null),
       new SerifClass("智子：","彼らはすでにゾンビ化しています、ご注意ください",2.0f,0,null),
       new SerifClass(" "," ",0.0f,7,null),

       new SerifClass("智子：","シールドが損傷したそうです",2.0f,0,null),
       new SerifClass("智子：","シールドチャージしてください",1.0f,5,null),



       new SerifClass("不明：","シ…シ…、（電流の音）おい、おい、聞こえるか ",2.0f,8,null),

       new SerifClass("指揮センター：","シ…こちらは…シ…指揮センター……聞こえるなら……返事してくれ ",2.0f,1,"返事する"),

       new SerifClass("あなた：","はい、聞こえる ",2.0f,0,null),
       new SerifClass("指揮センター：","やっと連絡がついた。大丈夫か？",2.0f,1,"まあ…"),

       new SerifClass("指揮センター：","お前が墜落した場所は非常に危険だ、早く離れろ。",2.0f,0,null),
       new SerifClass("指揮センター：","その近くに軍事基地があるんだ、それがX事件の旧跡だ",2.0f,0,null),
       new SerifClass("指揮センター：","そこには運搬ロケットがあるはずだ。運が良ければ、それを使って脱出できる。",4.0f,0,null),
       new SerifClass("指揮センター：","今、そこの座標を送る。注意して行動しろ。",2.0f,9,"了解"),

       new SerifClass(" "," ",1.0f,10,null),//テレポート待ち時間一秒      //敵を倒す待ち時間

       new SerifClass(" "," ",1.0f,11,null),

















        new SerifClass("","クリア",999.0f,0, "" ),
    };

















}
