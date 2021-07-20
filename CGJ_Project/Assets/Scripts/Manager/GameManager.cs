using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
public class GameManager
{
    // Start is called before the first frame update
    public bool _isDead; //������������Ϸ����
    public bool _isRopeBroken; //���ӱ����Ͻ���
    public bool _isCrash; //��ײ�ϰ���
    public bool _isFall; //�˵�����
    public bool _isOutofGas; //ȼ�����Ĵ�������
    public bool _isOutofTrack; //�𳵳������
    public bool _isHit; //��ײ��
    public bool _isWin;
    //�����¼����ж��Ƿ��������
    public bool onEventsListening() {
        if (_isRopeBroken || _isCrash || _isFall || _isOutofGas || _isOutofTrack)
        {
            _isDead = true;
        }
        else {
            _isDead = false;
        }
        return _isDead;
    }
}
