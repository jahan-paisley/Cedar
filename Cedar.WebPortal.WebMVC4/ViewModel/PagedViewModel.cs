using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using MvcContrib.Pagination;
using MvcContrib.UI.Grid;
using MvcContrib.Sorting;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Domain;
using Cedar.WebPortal.Service.Common;

namespace Cedar.WebPortal.WebMVC4.ViewModel
{
    public class PagedViewModel<T>
    {
        public ViewDataDictionary ViewData { get; set; }
        public IQueryable<T> Query { get; set; }
        public GridSortOptions GridSortOptions { get; set; }
        public string DefaultSortColumn { get; set; }
        public IPagination<T> PagedList { get; private set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }  
        public IServiceBase<T> Service{ get; set; }

        public PagedViewModel<T> AddFilter(Expression<Func<T, bool>> predicate)
        {
            Query = Query.Where(predicate);
            return this;
        }

        public PagedViewModel<T> AddFilter<TValue>(string key, TValue value, Expression<Func<T, bool>> predicate)
        {
            ProcessQuery(value, predicate);
            ViewData[key] = value;
            return this;
        }

        public PagedViewModel<T> AddFilter<TValue>(string keyField, object value, Expression<Func<T, bool>> predicate,
            IQueryable<TValue> query, string textField)
        {
            ProcessQuery(value, predicate);
            var selectList = query.ToSelectList(keyField, textField, value);
            ViewData[keyField] = selectList;
            return this;
        }

        public PagedViewModel<T> Setup()
        {
            if (string.IsNullOrWhiteSpace(GridSortOptions.Column))
            {
                GridSortOptions.Column = DefaultSortColumn;
            }

            PagedList = Query.OrderBy(GridSortOptions.Column, GridSortOptions.Direction)
                .AsPagination(Page ?? 1, PageSize ?? 10);
            return this;
        }

        private void ProcessQuery<TValue>(TValue value, Expression<Func<T, bool>> predicate)
        {
            if (value == null) return;
            if (typeof(TValue) == typeof(string))
            {
                if (string.IsNullOrWhiteSpace(value as string)) return;
            }
            //Query = Service.GetMany(predicate);
            Query = Query.Where(predicate);
        }
    }
}
