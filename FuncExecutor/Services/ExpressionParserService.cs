using FuncExecutor.Data;

namespace FuncExecutor.Services
{
    public class ExpressionParserService
    {
        ApplicationContext _context;

        public ExpressionParserService(ApplicationContext context)
        {
            _context = context;
        }

        // Функция преобразования выражения на исполняемое js-выражение
        // A + B -> parseFloat(document.querySelector('#value-1').value) + parseFloat(document.querySelector('#value-2').value)
        public string? Parse(string? expr)
        {
            if (String.IsNullOrEmpty(expr))
            {
                return null;
            }

            string newExpr = "";

            newExpr = ReplaceFunctions(expr);
            newExpr = ConvertToJS(newExpr);

            return newExpr;
        }

        // Функция замены наименований мат.функций из словаря Functions на аналогичные js-функции
        private string ReplaceFunctions(string expr)
        {
            string result = expr;

            foreach (var func in Functions)
            {
                if (result.Contains(func.Key))
                {
                    result = result.Replace(func.Key, func.Value);
                }
            }

            return result;
        }

        // Функция замены показателей, найденных в БД на соответствующие HTML-элементы
        private string ConvertToJS(string expr)
        {
            string js = expr;

            var indicators = _context.Indicators.ToList();

            foreach(var indicator in indicators)
            {
                var valueIds = _context.Values
                    .OrderByDescending(x => x.CreatedAt)
                    .Take(indicators.Count())
                    .Where(x => x.IndicatorId == indicator.Id)
                    .Select(x => x.Id);

                foreach(int id in valueIds)
                {
                    var value = $"parseFloat(document.querySelector('#value-{id}').value)";
                    js = js.Replace(indicator.Code, value);
                }
            }

            return js;
        }

        // Словарь доступных функций и их js-аналогов
        private static Dictionary<string, string> Functions = new Dictionary<string, string>()
        {
            {"Pow",  "Math.pow" },
            {"Sqrt", "Math.sqrt" },
            {"Sin",  "Math.sin" },
            {"Cos", "Math.cos" },
            {"Exp", "Math.exp" },
            {"Log", "Math.log" },
            {"Random", "Math.random" },
        };

    }
}
