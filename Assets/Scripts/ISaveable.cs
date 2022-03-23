using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    //JSON esetén kellene
    //public void Save();

    public void Load(ISaveable data);
}
