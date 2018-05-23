using AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Base
{
    public class BaseLauncher : ILauncher
    {
        private BaseModule _module;
        public void Init(BaseModule module)
        {
            _module = module;
        }

        public virtual void Show()
        {
            _module.ShowMainForm();
        }
    }
}
