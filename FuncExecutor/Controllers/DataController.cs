using FuncExecutor.Data;
using FuncExecutor.Models;
using FuncExecutor.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FuncExecutor.Controllers
{
    public class DataController : ControllerBase
    {
        ApplicationContext _context;
        public DataController(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        [HttpPost("/save-form")]
        public IActionResult SaveForm([FromBody] FormDataDto formData)
        {
            if (formData == null)
            {
                return BadRequest();
            }

            foreach (var row in formData.Rows)
            {
                _context.Values.Add(new ValueModel()
                {
                    CreatedAt = DateTime.Now,
                    FormName = formData.FormName,
                    IndicatorId = row.IndicatorId,
                    Value =row.Value,
                });
                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpPost("/add-indicator")]
        public IActionResult AddIndicator([FromBody] IndicatorModel indicator)
        {
            if (indicator == null)
            {
                return BadRequest();
            }

            _context.Indicators.Add(new IndicatorModel()
            {
                CreatedAt = DateTime.Now,
                Code = indicator.Code,
                Description = indicator.Description,
                TypeDescr = indicator.TypeDescr,
                Func = indicator.Func
            });

            int lastInicatorId = _context.Indicators.OrderByDescending(x => x.Id).First().Id + 1;
            _context.Values.Add(new ValueModel()
            {
                CreatedAt = DateTime.Now,
                IndicatorId = lastInicatorId,
                FormName = "Form 1",
                Value = null
            });
            
            _context.SaveChanges();

            return Ok();
        }
    }
}
