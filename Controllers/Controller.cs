using MVC_CarMarket.Services;
using MVC_CarMarket.View;
using System;

namespace MVC_CarMarket.Controllers
{
    public class Controller
    {
        private Display display =  new Display();
        private Service service = new Service();

        public void Start()
        {
            service.LoadData();
            display.ShowMainMenu();
        }
    }
}
