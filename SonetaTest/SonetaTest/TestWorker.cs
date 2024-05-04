using Soneta.Business;
using System;
using System.Collections.Generic;
using System.Text;
using SonetaTest;
using Soneta.Zadania;
using Soneta.Business.UI;


[assembly: Worker(typeof(TestWorker), typeof(Zadanie))]

namespace SonetaTest
{
    public class TestWorker : ContextBase
    {
        protected TestWorker(Context context) : base(context)
        {
        }

        [Action("TestWorkerGeekOut24",
         Target = ActionTarget.ToolbarWithText, Icon = ActionIcon.Asterix)]
        public MessageBoxInformation DoSmth()
        {
            return new MessageBoxInformation
            {
                Text = "Czy chcesz wyświetlić okno ostrzeżenia?",
                YesHandler = () => {
                    return new MessageBoxInformation
                    {
                        Type = MessageBoxInformationType.Warning,
                        Text = "To jest kolejne okno, które zawiera ostrzeżenie."                        
                    };
                }
            };
        }
    }
}
