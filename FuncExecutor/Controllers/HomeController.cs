using FuncExecutor.Data;
using FuncExecutor.Models;
using FuncExecutor.Models.ViewModels;
using FuncExecutor.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FuncExecutor.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;
        ExpressionParserService _parser;

        public HomeController(ApplicationContext applicationContext, ExpressionParserService expressionParser)
        {
            _context = applicationContext;
            _parser = expressionParser;
        }

        public IActionResult Index()
        {
            var values = _context.Values.OrderByDescending(x => x.CreatedAt).Take(_context.Indicators.Count());

            IQueryable<RowDataViewModel> rows = _context.Indicators.Join(
                values,
                i => i.Id,
                v => v.IndicatorId,
                (i, v) => new RowDataViewModel()
                {
                    IndicatorId = i.Id,
                    IndicatorCode = i.Code,
                    IndicatorDescription = i.Description,
                    IndicatorTypeDescr = i.TypeDescr,
                    IndicatorFunc = _parser.Parse(i.Func),
                    FormName = v.FormName ?? "",
                    ValueId = v.Id,
                    Value = v.Value
                });

            var result = rows.OrderBy(x => x.IndicatorId).ToList();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}