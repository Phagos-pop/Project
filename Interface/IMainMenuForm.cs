﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Interface
{
    interface IMainMenuForm
    {
        void EnableAnimatedBackground();
        void OnFrameChanged(object sender, EventArgs e);
    }
}
