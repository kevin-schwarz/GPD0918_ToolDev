using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPD0918_ToolDev
{
    public class Events
    {

        public delegate void OnClick();

        public event OnClick onClickEvent;

        public void Click()
        {
            onClickEvent();
        }

        public void Test3()
        {
            onClickEvent += test2;
            Click();// test2 wird aufgerufen
            onClickEvent -= test2;
            Click();// test2 wird nicht aufgerufen.
        }

        public void test2()
        {

        }

    }
}
