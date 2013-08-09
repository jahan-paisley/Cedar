namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Domain.Resources;

    public static class HtmlHelperExtensionForDropDownList
    {
        public static MvcHtmlString DropDownListFor<TItem>(
            this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, bool?>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            string propname = htmlHelper.ViewData.Model.Item(expression);

            var selectList = new[]
                {
                    new SelectListItem { Text = StringResource.None, Value = "" },
                    new SelectListItem { Text = StringResource.Yes, Value = "True" },
                    new SelectListItem { Text = StringResource.No, Value = "False" },
                };
            if (metadata.Model == null)
            {
                selectList[0].Selected = true;
                selectList[1].Selected = false;
                selectList[2].Selected = false;
            }
            else if ((bool)metadata.Model)
            {
                selectList[0].Selected = false;
                selectList[1].Selected = true;
                selectList[2].Selected = false;
            }
            else
            {
                selectList[0].Selected = false;
                selectList[1].Selected = false;
                selectList[2].Selected = true;
            }
            return htmlHelper.DropDownList(propname, selectList);
        }

        public static MvcHtmlString DropDownListFor<TItem>(
            this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, bool>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            string propname = htmlHelper.ViewData.Model.Item(expression);

            var selectList = new[]
                {
                    
                    new SelectListItem { Text = StringResource.Yes, Value = "True" },
                    new SelectListItem { Text = StringResource.No, Value = "False" },
                };
            if (metadata.Model == null)
            {
                selectList[0].Selected = false;
                selectList[1].Selected = true;
            }
            else if ((bool)metadata.Model)
            {
                selectList[0].Selected = true;
                selectList[1].Selected = false;
            }
            else
            {
                selectList[0].Selected = false;
                selectList[1].Selected = true;
            }
            return htmlHelper.DropDownList(propname, selectList);
        }

        public static MvcHtmlString DropDownListFor<T>(this HtmlHelper htmlHelper, string name, T allListItems)
        {
            var propertyValue = htmlHelper.ViewData.Model.GetProperty(name);
            var selectListItems = (IEnumerable<SelectListItem>)allListItems;

            if (propertyValue.IsNotNull())
            {
                var listItems = from listItem in selectListItems
                                select
                                    new SelectListItem
                                        {
                                            Text = listItem.Text,
                                            Value = listItem.Text,
                                            Selected = (listItem.Text.Equals(propertyValue))
                                        };

                return htmlHelper.DropDownList(name, listItems);
            }
            else return htmlHelper.DropDownList(name, selectListItems);
        }

        public static MvcHtmlString DropDownListFor(this HtmlHelper htmlHelper, string name, string[] allListItems)
        {
            int i = 0;
            var listItems = from listItem in allListItems
                            select
                                new SelectListItem
                                {
                                    Text = listItem,
                                    Value = i++.ToString()
                                };
            return htmlHelper.DropDownList(name, listItems);
        }


        public static MvcHtmlString DropDownListFor<TItem>(
          this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, string>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            string propname = htmlHelper.ViewData.Model.Item(expression);
            IEnumerable<TItem> values = Enum.GetValues(typeof(TItem)).Cast<TItem>();
            IEnumerable<SelectListItem> items = values.Select(
                value =>
                {
                    return new SelectListItem
                        {
                            Selected = value.Equals(metadata.Model),
                            Text = value.ToString(),
                            Value = value.ToString()
                        };
                });

            return htmlHelper.DropDownList(propname, items);
        }

        public static MvcHtmlString DropDownListFor<TItem, TEnum>(
            this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, TEnum>> expression)
        {

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        
            IEnumerable<SelectListItem> items =
     values.Select(value =>
     {
         string resourceFor = HtmlHelperExtensionForResources.ResourceFor(typeof(EntityResource), typeof(TEnum).Name + "_" + value.ToString());
         return new SelectListItem { Selected = value.Equals(metadata.Model), Text = resourceFor, Value = value.ToString() };
     });

            return htmlHelper.DropDownListFor(expression, items);
        }

        public static MvcHtmlString DropDownListForRange<TItem>(
            this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, object>> expression, int start, int end)
        {
            string propname = htmlHelper.ViewData.Model.Item(expression);
            var selectListItems = Enumerable.Range(start, end - start)
                .Select(o => new SelectListItem { Text = o.ToString(), Value = o.ToString() });

            return htmlHelper.DropDownList(propname, selectListItems);
        }

        //public static MvcHtmlString DropDownListForModel<TItem>(
        //  this HtmlHelper<TItem> htmlHelper, object o) where TItem : class
        //{
        //    Dictionary<string, object> prop = ObjectHelper.Dump(o);
        //    IEnumerable<SelectListItem> items = prop.Select(
        //        value => new SelectListItem
        //                     {
        //                         Text = value.ToString(),
        //                         Value = value.ToString()
        //                     });

        //    return htmlHelper.DropDownList("property", items);
        //}
    }
}