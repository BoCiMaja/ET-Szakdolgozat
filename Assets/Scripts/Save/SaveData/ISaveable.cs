using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    //JSON eset�n kellene
    //public void Save();

    public void Load(ISaveable data);
}
