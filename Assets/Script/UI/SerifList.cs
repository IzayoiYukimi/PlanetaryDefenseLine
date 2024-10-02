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
       new SerifClass("�����ȁF","��Ȃ������A�����͂ǂ����H�����ȁB",2.0f,1,"AI�T�|�[�^�[�q�q�Ɏw���Z���^�[�ɘA��������"),

       new SerifClass("�����ȁF","�q�q�A�w���Z���^�[�ɘA�����Ă���B",2.0f,0,null),
       new SerifClass("�q�q�F","�w���Z���^�[�ւ̘A�������݂Ă��܂��B",2.0f,0,null),
       new SerifClass("�q�q�F","�x���A������X�����̐����w�E�C���X���o����ł��B",2.0f,0,null),
       new SerifClass("�q�q�F","���S�ɂ����ӂ��������B",2.0f,1,"�����`�F�b�N"),

       new SerifClass("�����ȁF","����A�q�q�A�����̃`�F�b�N�����āB",3.0f,0,null),
       new SerifClass("�q�q�F","�����ł��B",2.0f,0,null),
       new SerifClass("�q�q�F","�ł́A�܂������ړ����Ă݂܂��傤�B",1.0f,2,null),
       new SerifClass("�q�q�F","���͂Ȃ������ł��B",2.0f,0,null),
       new SerifClass("�q�q�F","���ɕ���̏�Ԃ��m�F���܂��傤�B",2.0f,0,null),
       new SerifClass("�q�q�F","�Ə��͉\�ł����H",1.0f,3,null),

       new SerifClass("�q�q�F","�����݂����ł��ˁB",2.0f,0,null),
       new SerifClass("�q�q�F","�ł͂��ꂩ�畐��̃`�F�b�N�ł��B",2.0f,0,null),
       new SerifClass("�q�q�F","�Ə����Č����Ă݂܂��傤�B",1.0f,4,null),

       new SerifClass("�q�q�F","�x���B�߂��ɖ��m�F�������ڋ߂��Ă��܂��B�x�������߂Ă�������",5.0f,6,null),
       new SerifClass(" "," ",2.0f,0,null),
       new SerifClass("�q�q�F","�C���B�����ł͂Ȃ��AX�����̋]���҂����ł��B",2.0f,0,null),
       new SerifClass("�q�q�F","�ނ�͂��łɃ]���r�����Ă��܂��A�����ӂ�������",2.0f,0,null),
       new SerifClass(" "," ",0.0f,7,null),

       new SerifClass("�q�q�F","�V�[���h���������������ł�",2.0f,0,null),
       new SerifClass("�q�q�F","�V�[���h�`���[�W���Ă�������",1.0f,5,null),



       new SerifClass("�s���F","�V�c�V�c�A�i�d���̉��j�����A�����A�������邩 ",2.0f,8,null),

       new SerifClass("�w���Z���^�[�F","�V�c������́c�V�c�w���Z���^�[�c�c��������Ȃ�c�c�Ԏ����Ă��� ",2.0f,1,"�Ԏ�����"),

       new SerifClass("���Ȃ��F","�͂��A�������� ",2.0f,0,null),
       new SerifClass("�w���Z���^�[�F","����ƘA���������B���v���H",2.0f,1,"�܂��c"),

       new SerifClass("�w���Z���^�[�F","���O���ė������ꏊ�͔��Ɋ댯���A���������B",2.0f,0,null),
       new SerifClass("�w���Z���^�[�F","���̋߂��ɌR����n������񂾁A���ꂪX�����̋��Ղ�",2.0f,0,null),
       new SerifClass("�w���Z���^�[�F","�����ɂ͉^�����P�b�g������͂����B�^���ǂ���΁A������g���ĒE�o�ł���B",4.0f,0,null),
       new SerifClass("�w���Z���^�[�F","���A�����̍��W�𑗂�B���ӂ��čs������B",2.0f,9,"����"),

       new SerifClass(" "," ",1.0f,10,null),//�e���|�[�g�҂����Ԉ�b      //�G��|���҂�����

       new SerifClass(" "," ",1.0f,11,null),

















        new SerifClass("","�N���A",999.0f,0, "" ),
    };

















}
