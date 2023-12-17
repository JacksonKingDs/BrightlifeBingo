﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

namespace Transition
{
    public class CutoffMaskUI : Image
    {
        public override Material materialForRendering
        {
            get
            {
                Material material = new Material(base.materialForRendering);
                material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
                return material;
            }
        }
    }
}