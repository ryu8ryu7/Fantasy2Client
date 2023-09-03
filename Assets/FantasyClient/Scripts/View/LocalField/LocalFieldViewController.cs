using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalFieldViewController : ViewControllerBase
{
    private LocalFieldView3D _view3D = null;

    public override void InitializeView()
    {
        base.InitializeView();

        _view3D = _view3DBase as LocalFieldView3D;


        _view3D.LoadField();
        _view3D.LoadForces();
    }
}
