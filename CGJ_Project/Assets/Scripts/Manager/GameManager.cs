using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
public class GameManager
{
    // Start is called before the first frame update
    public bool _isDead; //人物死亡，游戏结束
    public bool _isRopeBroken; //绳子被拉断结束
    public bool _isCrash; //火车撞障碍物
    public bool _isFall; //人掉洞里
    public bool _isOutofGas; //燃气消耗殆尽结束
    public bool _isOutofTrack; //火车出轨结束
    public bool _isHit; //火车撞人
    public bool _isWin;
    //监听事件，判断是否出现死亡
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
