using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasManager
{
    public int gas_all; //燃气总量
    public int gas_consume;//每秒燃气消耗量
    public int gas_box;

    private float timer;

    public GasManager(int _gasAll,int _gasConsume,int _gasBox) {
        gas_all = _gasAll;
        gas_consume = _gasConsume;
        gas_box = _gasBox;
        timer = 0;
    }

    public void gasConsuming(int ratio) {
        if (timer >= 1.0f)
        {
            gas_all -= gas_consume * ratio;
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public bool gasCurrent() {
        return gas_all <= 0;
    }

    public void gasAdding() {
        gas_all += gas_box;
    }

}
