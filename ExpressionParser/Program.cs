/*
 * Т.к. связь один к одному
 * Indicator.Id <-> Value.IndicatorId
 * Для парсинга в момент подстановки можем использовать 
 * var expr = "A + B"
 * for indicator in context.Indicators.ToList() {
 *    if (indicator.TypeDescr == "manual") {
 *        value = @"document.querySelector('#value-{Indicator.Id}').valueAsNumber";
 *        expr.Replace(Indicator.Code, value);
 *    }
 * }
 * expr = "document.querySelector('#value-1').valueAsNumber + document.querySelector('#value-2').valueAsNumber";
 */