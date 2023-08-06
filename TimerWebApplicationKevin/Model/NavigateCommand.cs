using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerWebApplicationKevin.Model
{
    public class NavigateCommand
    {
        private readonly Navigation navi;

        public NavigateCommand(Navigation navigateCommand)
        {
            this.navi = navigateCommand;
        }
        public void Execute() 
        {
            
        }
    }
}
