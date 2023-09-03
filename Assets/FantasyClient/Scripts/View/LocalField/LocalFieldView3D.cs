using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalFieldView3D : View3DBase
{
    public const float BLOCK_SIZE = 2.0f;

    private GameObject _fieldObject = null;

    private GameObject _cursor = null;
    private List<List<Force>> _forceList = new List<List<Force>>();

    public void LoadField()
    {
        const string LOCAL_FIELD_PATH = "3D/LocalField/{0:D8}/L_Fld_{0:D8}";
        GameObject obj = ResourceManager.LoadOnView<GameObject>(string.Format( LOCAL_FIELD_PATH, 1 ));
        _fieldObject = Instantiate<GameObject>(obj);
        _fieldObject.transform.SetParent(transform);

        _cursor = Instantiate<GameObject>( ResourceManager.LoadOnView<GameObject>("3D/LocalField/Common/SelectCursor") );
        _cursor.transform.SetParent(transform);

    }

    public void LoadForces()
    {
        {
            Force force = new GameObject("MyForce").AddComponent<Force>();
            force.transform.SetParent(transform);
            force.Create();

            List<Force> forceList = new List<Force>();
            forceList.Add(force);
            _forceList.Add(forceList);
        }
        {
            Force force = new GameObject("EnemyForce").AddComponent<Force>();
            force.transform.SetParent(transform);
            force.Create();

            List<Force> forceList = new List<Force>();
            forceList.Add(force);
            _forceList.Add(forceList);
        }

    }

    public void GetPosToBlock(Vector3 pos, out int x, out int z)
    {
        x = (int)(pos.x / BLOCK_SIZE);
        z = (int)(pos.z / BLOCK_SIZE);
    }

    public void GetBlockToPos(int x, int z, out Vector3 pos )
    {
        pos.x = x * BLOCK_SIZE;
        pos.y = 0;
        pos.z = z * BLOCK_SIZE;
    }


}
