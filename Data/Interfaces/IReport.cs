using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiReportService.Data.Models;
using WebApiReportService.ViewModels;

namespace WebApiReportService.Data.Interfaces
{
    /*Интерфейс для составления отчета со входными данными*/
    public interface IReport
    {
        public ReportViewModel GetReport(InputAtributData InputData); // метод создания отчета на основе данных InputData
    }
}
