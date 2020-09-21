using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiReportService.Data.Interfaces;
using WebApiReportService.Data.Models;

namespace WebApiReportService.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IReport _report; // экземпляр интерфейса для создания отчтета

        public ReportController(IReport report)
        {
            _report = report; //получаем все данные
        }


        /*так как у меня проблемы с fronted - реализацией под Web API, так как не успел еще разобраться, решил для достижения результата немного съехать с курса и показать отчет на основе MVC */

        [HttpGet]//форма, запускается по умолчанию, адрес localhost:<port>/api/report - выдает миниатюрную форму для заполнения входных данных
        public ViewResult Form() //шаблон Form.cshtml
        {
           return View();
        }

        /*попытка реализации post метода, но к сожалению безуспешно*/
        [HttpPost("{jsonData}")]
        public ViewResult PostReport([FromBody] string JsonData)
        {
            InputAtributData data = JsonConvert.DeserializeObject<InputAtributData>(JsonData); //получаем данные на входе в виде json, конвертируем их в тип для входных данных
            var report = _report.GetReport(data); //обрабатываем и создаем отчет
            return View(report); //передаем в шаблон и там выводим
        }

        /*попытка вывода отчета в шаблоне в папке View данного проекта*/
        //шаблон PostReport.cshtml
    }
}
