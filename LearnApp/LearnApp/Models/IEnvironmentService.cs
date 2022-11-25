using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LearnApp.Services
{
    public interface IEnvironmentService
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
